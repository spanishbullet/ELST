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
    public CustomEvent filter;
    public DataGridView dgv;
    public FilterWindow(DataGridView _dgv, CustomEvent _filter)
    {
        dgv = _dgv;
        filter = _filter;
        InitializeComponent();
        InitializeEventTypesCLB();
    }

    public void InitializeEventTypesCLB()
    {
        for (int i = 0; i < eventTypesCLB.Items.Count; i++)
        {
            eventTypesCLB.SetItemChecked(i, true);
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        filter.serialNumber = testTB.Text;
        
        this.Close();
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        //reseteverything
    }
} 
