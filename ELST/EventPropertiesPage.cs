using ELSTWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ELST;

public partial class EventPropertiesPage : Form
{
    public DataGridView dgv;
    public List<CustomEvent> events;
    public int index;

    public EventPropertiesPage(DataGridView _dgv, List<CustomEvent> _events, int _index)
    {
        dgv = _dgv;
        events = _events;
        index = _index;

        InitializeComponent();

        xmlViewCB.Checked = true;
        detailsLabel.Text = events[index].formattedXml;
    }

    private void xmlViewCB_CheckedChanged(object sender, EventArgs e)
    {
        // If xmlViewCB is checked, uncheck friendlyViewCB
        if (xmlViewCB.Checked)
        {
            friendlyViewCB.CheckedChanged -= friendlyViewCB_CheckedChanged; // Temporarily unsubscribe to avoid recursive call
            friendlyViewCB.Checked = false;
            friendlyViewCB.CheckedChanged += friendlyViewCB_CheckedChanged; // Re-subscribe after changing state
        }
        else
        {
            // Prevent xmlViewCB from being unchecked if friendlyViewCB is already unchecked
            if (!friendlyViewCB.Checked)
            {
                xmlViewCB.CheckedChanged -= xmlViewCB_CheckedChanged;
                xmlViewCB.Checked = true;
                xmlViewCB.CheckedChanged += xmlViewCB_CheckedChanged;
            }
        }
        detailsLabel.Text = events[index].formattedXml;
    }

    private void friendlyViewCB_CheckedChanged(object sender, EventArgs e)
    {
        if (friendlyViewCB.Checked)
        {
            xmlViewCB.CheckedChanged -= xmlViewCB_CheckedChanged; // Temporarily unsubscribe to avoid recursive call
            xmlViewCB.Checked = false;
            xmlViewCB.CheckedChanged += xmlViewCB_CheckedChanged; // Re-subscribe after changing state
        }
        else
        {
            // Prevent friendlyViewCB from being unchecked if xmlViewCB is already unchecked
            if (!xmlViewCB.Checked)
            {
                friendlyViewCB.CheckedChanged -= friendlyViewCB_CheckedChanged;
                friendlyViewCB.Checked = true;
                friendlyViewCB.CheckedChanged += friendlyViewCB_CheckedChanged;
            }
        }
        detailsLabel.Text = events[index].formattedXml;
    }
}
