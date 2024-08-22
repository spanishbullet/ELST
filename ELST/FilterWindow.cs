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

namespace ELST;

public partial class FilterWindow : Form
{
    public FilterWindow(List<CustomEvent> _events)
    {
        events = _events;
        InitializeComponent();
    }

    private List<CustomEvent> events;

    private List<string> eventTypes = new List<string>();

    private string source;
    private bool excludeSource;

    private string Category;
    private bool excludeCategory;

    private string user;
    private bool excludeUser;

    private string computer;
    private bool excludeComputer;

    private string eventIDs;
    private bool excludeEventIDs;

    private string textInDescription;
    private bool regExp;
    private bool excludeTextInDescription;

    public void InitializeEventTypesCLB()
    {
        for (int i = 0; i < eventTypesCLB.Items.Count; i++)
        {
            eventTypes.Add(eventTypesCLB.Items[i].ToString());
            eventTypesCLB.SetItemChecked(i, true);
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void clearButton_Click(object sender, EventArgs e)
    {

    }
} 
