using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class Device
{    
    public string capacity { get; set; }

    public string manufacturer { get; }

    public string model { get; }

    public string revision { get; }

    public string serialNumber { get; }

    public string parentId { get; }

    public DateTime firstInOut { get; set; }

    public DateTime lastInOut { get; set; }

    public int appearances { get; set; }

    public List<CustomEvent> events { get; set; }

    public Device(CustomEvent customEvent)
    {
        events = new List<CustomEvent>();
        capacity = customEvent.capacity;
        manufacturer = customEvent.manufacturer;
        model = customEvent.model;
        revision = customEvent.revision;
        serialNumber = customEvent.serialNumber;
        parentId = customEvent.parentId;
        firstInOut = (DateTime)customEvent.TimeCreated;
        lastInOut = (DateTime)customEvent.TimeCreated;
        events.Add(customEvent);
        appearances = events.Count;
    }

    public void AddEvent(CustomEvent customEvent)
    {
        events.Add(customEvent);
        appearances++;
        if (long.Parse(capacity) == 0)
            capacity = customEvent.capacity;
        if (firstInOut >= customEvent.TimeCreated)
            firstInOut = (DateTime)customEvent.TimeCreated;
        else 
            lastInOut = (DateTime)customEvent.TimeCreated;
    }

    public List<string> GetAllAttributes()
    {
        List<string> result = new List<string>();
        result.Add(serialNumber);
        result.Add(manufacturer);
        result.Add(model);
        result.Add(firstInOut.ToString());
        result.Add(lastInOut.ToString());
        result.Add(appearances.ToString());
        result.Add(revision);
        result.Add(parentId);
        result.Add(capacity);


        return result;
    }

    public string Display()
    {
        string message = string.Join(",", this.GetAllAttributes());
        return message;
    }

    //returns true if both devices are the same. Used to see if there are events outside the current timeframe.
    public bool Equals(Device device)
    {
        if (events.Count == device.events.Count)
            return true;
        
        return false;
    }
}
