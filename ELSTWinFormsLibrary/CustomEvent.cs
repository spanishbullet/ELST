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

    public string formattedVbr0 { get; set; }

    public string xml {  get; }

    public string formattedXml { get; }

    public string machineName { get; }

    public string registryID { get; }

    public string diskID { get; }

    private string partitionTableBytes { get; }

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
        machineName = record.MachineName;
        xml = record.ToXml();
        formattedXml = XmlExtract.FormatXml(xml);

        // Parse the XML to extract desired fields
        capacity = XmlExtract.GetField(xml, "Capacity");
        manufacturer = XmlExtract.GetField(xml, "Manufacturer");
        model = XmlExtract.GetField(xml, "Model");
        revision = XmlExtract.GetField(xml, "Revision");
        serialNumber = XmlExtract.GetField(xml, "SerialNumber");
        parentId = XmlExtract.GetField(xml, "ParentId");
        vbr0 = XmlExtract.GetField(xml, "Vbr0");
        formattedVbr0 = FormatVbr0.Extract(vbr0);
        registryID = XmlExtract.GetField(xml, "RegistryId");
        diskID = XmlExtract.GetField(xml, "DiskId");
        partitionTableBytes = XmlExtract.GetField(xml, "PartitionTableBytes");

        if (string.IsNullOrEmpty(capacity))
        {
            action = "Unknown";  // Handle the null/empty case
        }
        else if (long.TryParse(capacity, out long capacityValue))
        {
            if (capacityValue == 0)
            {
                action = "Removed";  
            }
            else
            {
                if (int.TryParse(partitionTableBytes, out int  ptbValue))
                {
                    if (ptbValue == 0)
                    {
                        action = "Safely Ejected";
                    }
                    else
                    {
                        action = "Recognized";
                    }
                }
                else
                {
                    action = "Invalid";
                }
            }
        }
        else
        {
            action = "Invalid";  // Handle when capacity is not a valid number
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
        result.Add(TimeCreated);
        result.Add(manufacturer);
        result.Add(model);
        result.Add(serialNumber);
        result.Add(action);
        result.Add(capacity);
        result.Add(computer);
        result.Add(Id);
        result.Add(ProviderName);
        result.Add(Level);
        result.Add(Message);
        result.Add(recordNumber);
        result.Add(revision);
        result.Add(parentId);
        result.Add(processId);
        result.Add(threadID);
        result.Add(channel);
        result.Add(userID);
        result.Add(vbr0);
        result.Add(formattedVbr0);
        result.Add(machineName);
        result.Add(registryID);
        result.Add(diskID);

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
        result.Add(formattedVbr0);

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

    private string InterpretAction(int capacity, int partitionTableBytes)
    {
        string action = null;

        if (capacity == 0)
        {
            return "Removed";
        }
        else if (partitionTableBytes > 0)
        {
            return "Safely Ejected";
        }
        else
        {
            return "Recognized";
        }
    }
}