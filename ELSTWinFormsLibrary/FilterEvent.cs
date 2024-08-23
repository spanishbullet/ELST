using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class FilterEvent
{
    public int? Id { get; set; }
    public string ProviderName { get; set; }
    public string Message { get; set; }
    public DateTime? TimeCreated { get; set; }
    public string Level { get; set; }

    public string recordNumber { get; set; }

    public string capacity { get; set; }

    public string action { get; set; }

    public string manufacturer { get; set; }

    public string model { get; set; }

    public string revision { get; set; }

    public string serialNumber { get; set; }

    public string parentId { get; set; }

    public string vbr0 { get; set; }

    public string extractedVbr0 { get; set; }

    List<object> filters = new List<object>();


    public FilterEvent()
    {
        
    }

    public void ResetFilter()
    {
        Id = null;
        ProviderName = null;
        Message = null;
        TimeCreated = null;
        Level = null;
        recordNumber = null;
        capacity = null;
        recordNumber = null;
        action = null;
        manufacturer = null;
        model = null;
        revision = null;
        serialNumber = null;
        parentId = null;
        vbr0 = null;
        extractedVbr0 = null;
    }

    public List<object> GetFilters()
    {
        return filters;
    }

    public List<object> GetActiveFilters()
    {

        List<object> activeFilters = new List<object>();

        return activeFilters;
    }
}
