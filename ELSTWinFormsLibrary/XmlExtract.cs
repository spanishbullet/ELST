using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}

