using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ELSTWinFormsLibrary;

public class XmlExtract
{
    public static string GetField(string xml, string fieldName)
    {
        try
        {
            // Load XML document
            XDocument doc = XDocument.Parse(xml);

            // Namespace handling (important to match the XML namespace)
            XNamespace ns = "http://schemas.microsoft.com/win/2004/08/events/event";

            // Search for the field in <EventData> section
            XElement dataElement = doc.Descendants(ns + "EventData").Descendants(ns + "Data").FirstOrDefault(e => (string)e.Attribute("Name") == fieldName);

            return dataElement?.Value ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string FormatXml(string xml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        // Create a string writer to hold the formatted XML
        using (var stringWriter = new System.IO.StringWriter())
        {
            // Create an XML writer with proper settings
            using (var xmlTextWriter = new XmlTextWriter(stringWriter))
            {
                xmlTextWriter.Formatting = Formatting.Indented; // Indent the XML

                // Write the XML content into the XmlTextWriter
                xmlDoc.WriteTo(xmlTextWriter);

                // Output the formatted XML string
                return stringWriter.ToString();
            }
        }
    }

    public static string FormatFriendly(string xml)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            StringBuilder result = new StringBuilder();
            int maxLabelLength = GetMaxLabelLength(doc.DocumentElement, 0);

            ExtractNodeData(doc.DocumentElement, result, 0, maxLabelLength);
            return result.ToString();
        }
        catch (XmlException ex)
        {
            return $"Error parsing XML: {ex.Message}";
        }
    }

    private static void ExtractNodeData(XmlNode node, StringBuilder result, int indentLevel, int maxLabelLength)
    {
        string indent = new string(' ', indentLevel * 2);

        if (node.NodeType == XmlNodeType.Element)
        {
            result.AppendLine($"{indent}{node.Name}".PadRight(maxLabelLength + indent.Length) + $"{node.InnerText.Trim()}");

            foreach (XmlAttribute attribute in node.Attributes)
            {
                result.AppendLine($"{indent}  [ {attribute.Name}]".PadRight(maxLabelLength + indent.Length) + $"{attribute.Value}");
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                ExtractNodeData(childNode, result, indentLevel + 1, maxLabelLength);
            }
        }
    }

    private static int GetMaxLabelLength(XmlNode node, int indentLevel)
    {
        int maxLength = 0;
        string indent = new string(' ', indentLevel * 2);

        if (node.NodeType == XmlNodeType.Element)
        {
            maxLength = Math.Max(maxLength, indent.Length + node.Name.Length);

            foreach (XmlAttribute attribute in node.Attributes)
            {
                maxLength = Math.Max(maxLength, indent.Length + 2 + attribute.Name.Length);
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                maxLength = Math.Max(maxLength, GetMaxLabelLength(childNode, indentLevel + 1));
            }
        }

        return maxLength + 1; // Add 1 to create space between label and value
    }
}

