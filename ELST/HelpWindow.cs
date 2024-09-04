using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELST;

public partial class HelpWindow : Form
{
    public HelpWindow()
    {
        InitializeComponent();

        string helpMessage = "  Menu:\n" +
                             "        File:\n" +
                             "            - Open log opens a file dialog to open a new file in the same window.\n" +
                             "            - Log Properties opens a window displaying information about the current log file(s).\n" +
                             "            - Export opens a window that allows you to export based on desired rows and fields.\n" +
                             "            - Exit will close the current window.\n" +
                             "        Analyze:\n" +
                             "            - Record Numbers will analyze event record numbers for anomalies such as missing, duplicate and out of order.\n" +
                             "            - Time will analyze event times for anomalies such as missing, duplicate and out of order.\n" +
                             "        Reset:\n" +
                             "            - Reset Cells will reset all of the cells to white.\n" +
                             "        See:\n" +
                             "            - Devices will open a window that allows you to see focused evvent data for each device.\n" +
                             "        Search:\n" +
                             "            - Search will open a window that allows you to search through all displayed events.\n" +
                             "        Configure:\n" +
                             "            - Columns will open a window that allows you to show, hide and reorder columns.\n" +
                             "        Time Control:\n" +
                             "            - There are two time controll boxes that auto populate to the oldest(left box) and the most recent(right box) event times.\n" +
                             "            - Type or click the dialog of either box to change the timeframe. This will hide all events outside of the selected timeframe.\n" +
                             "            - Click the \"Apply\" button to apply the changes made to the timeframe.\n" +
                             "            - Click the \"Reset\" button to revert to the original timeframe to include all events.\n" +
                             "  Devices:\n" +
                             "        - This section displays all of the devices found in the log file.\n" +
                             "        - Selecting or unselecting a device will show or hide the event.\n" +
                             "        - Click the \"Check All\" button to check and show all devices.\n" +
                             "        - Click the \"Uncheck All\" button to uncheck and hide all devices.\n" +
                             "  Events:\n" +
                             "        - Right click a selected row to view either the log or event properties.\n" +
                             "        - In the Event Properties window, you can cycle through different events and see their properties.\n" +
                             "  Status Labels:\n" +
                             "        - The first status strip show the number of events displayed vs the number of events in the file.\n" +
                             "        - The second status strip shows the full path of the opened file(s).";
        helpRTB.Text = helpMessage;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
