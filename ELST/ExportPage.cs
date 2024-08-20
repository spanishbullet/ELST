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

public partial class ExportPage : Form
{
    private DataGridView dgv = new DataGridView();

    private bool closeAtFinish = false;

    private string type;

    //expost entire log when true
    private string scope;
    public ExportPage(DataGridView _dgv)
    {
        dgv = _dgv;
        InitializeComponent();
        typeCLB.SetItemChecked(0, true);
        type = "Excel Document";
        scopeCLB.SetItemChecked(0, true);
        scope = "All Events";
    }



    private void exportButton_Click(object sender, EventArgs e)
    {

        if (scope == "All Events")
        {
            ExportWhole(type);
        }
        else if (scope == "Selected Events")
        {
            ExportSelected(type);
        }

        //ExportToExcel(dgv);
        if (closeAtFinish)
            this.Close();
    }

    private void ExportWhole(string type) 
    {
        switch (type)
        {
            case ("Excel Document"):
                Export.ToExcel(dgv);
                break;
            case ("Excel Document 2007"):
                Export.ToXls(dgv);
                break;
            case ("HTML Document"):
                Export.ToHtml(dgv);
                break;
            case ("Text File (tab seperated)"):
                Export.ToTxt(dgv);
                break;
        }
    }

    private void ExportSelected(string type)
    {
        switch (type)
        {
            case ("Excel Document"):
                Export.SelectedToExcel(dgv);
                break;
            case ("Excel Document 2007"):
                Export.SelectedToXls(dgv);
                break;
            case ("HTML Document"):
                Export.SelectedToHtml(dgv);
                break;
            case ("Text File (tab seperated)"):
                Export.SelectedToTxt(dgv);
                break;
        }
    }

    private void closeCB_CheckedChanged(object sender, EventArgs e)
    {
        if (closeCB.Checked)
        {
            closeAtFinish = true;
        }
        else if (!closeCB.Checked)
        {
            closeAtFinish = false;
        }
    }

    private void typeCLB_MouseDown(object sender, MouseEventArgs e)
    {
        // Get the index of the item at the clicked position
        int index = typeCLB.IndexFromPoint(e.Location);

        // Check if the index is valid
        if (index >= 0)
        {
            // Check the clicked item
            typeCLB.SetItemChecked(index, !typeCLB.GetItemChecked(index));

            // Uncheck all other items
            for (int i = 0; i < typeCLB.Items.Count; i++)
            {
                if (i != index)
                {
                    typeCLB.SetItemChecked(i, false);
                }
            }
            type = typeCLB.Items[index].ToString();
        }
    }

    private void scopeCLB_MouseDown(object sender, MouseEventArgs e)
    {
        // Get the index of the item at the clicked position
        int index = scopeCLB.IndexFromPoint(e.Location);

        // Check if the index is valid
        if (index >= 0)
        {
            // Check the clicked item
            scopeCLB.SetItemChecked(index, !scopeCLB.GetItemChecked(index));

            // Uncheck all other items
            for (int i = 0; i < scopeCLB.Items.Count; i++)
            {
                if (i != index)
                {
                    scopeCLB.SetItemChecked(i, false);
                }
            }
            scope = scopeCLB.Items[index].ToString();
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
