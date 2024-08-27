using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class FilterEvent
{
   public static List<CustomEvent> FilterEvents(List<CustomEvent> events, CustomEvent filter)
    {
        List<CustomEvent> filteredEvents = new List<CustomEvent>();

        foreach (CustomEvent e in events) 
        {
            if (e.Equals(filter))
            {
                filteredEvents.Add(e);
            }
        }
        return filteredEvents;
    }
}
