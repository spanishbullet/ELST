using System.Xml;
using System.Xml.Schema;

namespace ELSTWinFormsLibrary;

public class XmlValidator
{
    private static bool isValid = true;

    public static bool ValidateXml(string xml, string xsdPath)
    {
        // Assume the XML is valid initially
        bool isValid = true;

        // Load the XML schema
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add("", xsdPath);

        // Create an XmlReaderSettings object with the schema for validation
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas = schemaSet;
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += (sender, args) =>
        {
            // Set isValid to false if any validation error occurs
            isValid = false;
        };

        // Create an XmlReader object to read and validate the XML
        using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml), settings))
        {
            try
            {
                // Read and validate the XML
                while (reader.Read()) { }
            }
            catch (XmlException)
            {
                // If an XML parsing error occurs, set isValid to false
                isValid = false;
            }
        }

        return isValid;  // Return true if valid, false if invalid
    }
}

