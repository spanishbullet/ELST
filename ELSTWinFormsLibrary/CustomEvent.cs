using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.Security.Principal;

namespace ELSTWinFormsLibrary;

public class CustomEvent
{
    public int Id { get; }
    public string ProviderName { get; }
    public string Message { get; }
    public DateTime TimeCreated { get; }
    public string Level { get; }

    public string recordNumber { get; }

    public string capacity { get; }

    public string action { get; }

    public string manufacturer { get; }

    public string model { get; }

    public string revision { get; }

    public string serialNumber { get; }

    public string parentId { get; }

    public string vbr0 { get; }

    public string extractedVbr0 { get; }



    public CustomEvent(EventRecord record)
    {
        Id = (int)record.Id;
        ProviderName = record.ProviderName;
        Message = record.FormatDescription();
        TimeCreated = record.TimeCreated.HasValue ? record.TimeCreated.Value : DateTime.MinValue;
        Level = record.LevelDisplayName;
        recordNumber = record.RecordId.ToString();

        // Get the XML representation of the event
        string eventXml = record.ToXml();

        // Parse the XML to extract desired fields
        capacity = XmlExtract.GetField(eventXml, "Capacity");
        manufacturer = XmlExtract.GetField(eventXml, "Manufacturer");
        model = XmlExtract.GetField(eventXml, "Model");
        revision = XmlExtract.GetField(eventXml, "Revision");
        serialNumber = XmlExtract.GetField(eventXml, "SerialNumber");
        parentId = XmlExtract.GetField(eventXml, "ParentId");
        vbr0 = XmlExtract.GetField(eventXml, "Vbr0");
        extractedVbr0 = FormatVbr0.Extract(vbr0);

        if (long.Parse(capacity) != 0)
        {
            action = "Plugged In";
        }
        else
        {
            action = "Ejected";
        }
    }

    public string Display()
    {
        return recordNumber;
    }

    public List<object> GetAllAttributes()
    {
        List<object> result = new List<object>();
        result.Add(Id);
        result.Add(ProviderName);
        result.Add(Level);
        result.Add(Message);
        result.Add(recordNumber);
        result.Add(TimeCreated);
        result.Add(capacity);
        result.Add(action);
        result.Add(manufacturer);
        result.Add(model);
        result.Add(revision);
        result.Add(serialNumber);
        result.Add(parentId);
        result.Add(extractedVbr0);

        return result;
    }

    public List<string> GetUniqueAttributes()
    {
        List<string> result = new List<string>();
        result.Add(Id.ToString());
        result.Add(ProviderName);
        result.Add(Level);
        result.Add(Message);
        result.Add(recordNumber);
        result.Add(TimeCreated.ToString());
        result.Add(action);
        result.Add(extractedVbr0);

        return result;
    }

    public bool Equals(FilterEvent filterEvent)
    {
        //var filters = filterEvent.Filters;

        return false;
    }
}