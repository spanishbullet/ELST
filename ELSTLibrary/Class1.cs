using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;

namespace ELSTLibrary;

public class FormatVbr0
{
    public static byte[] convert(string hexString)
    {
        return Enumerable.Range(0, hexString.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                         .ToArray();
    }

    public static string Extract(string vbr0HexStr)
    {
        if (vbr0HexStr.Length == 0)
        {
            return "Empty";
        }
        //else if (vbr0HexStr.Length != 512)
        //{
        //    return "Unexpected Size";
        //}

        byte[] vbr0Data = convert(vbr0HexStr);

        // Extract 4-byte values at the given offsets
        uint valueAt43 = BitConverter.ToUInt32(vbr0Data, 0x43); // Little Endian
        uint valueAt64 = BitConverter.ToUInt32(vbr0Data, 0x64); // Little Endian
        uint valueAt48 = BitConverter.ToUInt32(vbr0Data, 0x48); // Little Endian

        // Output the values
        return $"0x43: 0x{valueAt43:X8}, 0x64: 0x{valueAt64:X8},  0x48: 0x{valueAt48:X8}";
    }
    
}

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