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
    public string ProviderName { get; set; }
    public Guid? guid { get; set; }
    public int? Id { get; set; }
    public string Level {  get; set; } 
    public string Message { get; set; }
    public DateTime? TimeCreated { get; set; }

    public string recordNumber { get; set; }

    public int? processId { get; set; }

    public int? threadID { get; set; }

    public string channel {  get; set; }

    public string computer {  get; set; }

    public SecurityIdentifier userID { get; set; }

    public string capacity { get; set; }

    public string action { get; set; }

    public string manufacturer { get; set; }

    public string model { get; set; }

    public string revision { get; set; }

    public string serialNumber { get; set; }

    public string parentId { get; set; }

    public string vbr0 { get; set; }

    public string extractedVbr0 { get; set; }

    public CustomEvent()
    {

    }

    public CustomEvent(EventRecord record)
    {
        Id = (int)record.Id;
        ProviderName = record.ProviderName;
        guid = record.RelatedActivityId;
        processId = record.ProcessId;
        threadID = record.ThreadId;
        channel = record.LogName;
        computer = record.MachineName;
        userID = record.UserId;
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
        //orders matter**************************
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
        result.Add(processId);
        result.Add(threadID);
        result.Add(channel);
        result.Add(computer);
        result.Add(userID);
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

    public bool Equals(CustomEvent filter)
    {
        for (int i = 0; i < this.GetAllAttributes().Count - 1; i++)
        {
            if (filter.GetAllAttributes()[i] != null)
            {
                if (filter.GetAllAttributes()[i] != this.GetAllAttributes()[i])
                {
                    return false;
                }
            }
        }

        return true;
    }
}