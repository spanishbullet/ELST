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
        LoadColumnSettings();
        typeCLB.SetItemChecked(0, true);
        type = "Excel Document";
        scopeCLB.SetItemChecked(0, true);
        scope = "All Events";
    }

    private void LoadColumnSettings()
    {
        fieldsCLB.Items.Clear();
        var sortedColumns = dgv.Columns.Cast<DataGridViewColumn>()
                                .OrderBy(c => c.DisplayIndex)
                                .ToList();

        // Add columns to the CheckedListBox in sorted order
        foreach (DataGridViewColumn column in sortedColumns)
        {
            fieldsCLB.Items.Add(column.HeaderText, column.Visible);
        }
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
                Export.ToExcel(dgv, fieldsCLB);
                break;
            case ("Excel Document 2007"):
                Export.ToXls(dgv, fieldsCLB);
                break;
            case ("HTML Document"):
                Export.ToHtml(dgv, fieldsCLB);
                break;
            case ("Text File (tab seperated)"):
                Export.ToTxt(dgv, fieldsCLB);
                break;
        }
    }

    private void ExportSelected(string type)
    {
        switch (type)
        {
            case ("Excel Document"):
                Export.SelectedToExcel(dgv, fieldsCLB);
                break;
            case ("Excel Document 2007"):
                Export.SelectedToXls(dgv, fieldsCLB);
                break;
            case ("HTML Document"):
                Export.SelectedToHtml(dgv, fieldsCLB);
                break;
            case ("Text File (tab seperated)"):
                Export.SelectedToTxt(dgv, fieldsCLB);
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

    private void scopeCLB_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        // Prevent unchecking the last checked item (ensure at least one item is always checked)
        if (e.NewValue == CheckState.Unchecked && scopeCLB.CheckedItems.Count == 1)
        {
            e.NewValue = CheckState.Checked;
            return;
        }

        // Uncheck all other items when a new one is checked
        if (e.NewValue == CheckState.Checked)
        {
            for (int i = 0; i < scopeCLB.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    // Uncheck the other items
                    scopeCLB.SetItemChecked(i, false);
                }
            }

            // Update the scope with the newly checked item
            scope = scopeCLB.Items[e.Index].ToString();
        }
    }

    private void moveUpButton_Click(object sender, EventArgs e)
    {
        int index = fieldsCLB.SelectedIndex;
        if (index > 0)
        {
            var item = fieldsCLB.SelectedItem;
            var isChecked = fieldsCLB.GetItemChecked(index);
            fieldsCLB.Items.RemoveAt(index);
            fieldsCLB.Items.Insert(index - 1, item);
            fieldsCLB.SetItemChecked(index - 1, isChecked);
            fieldsCLB.SelectedIndex = index - 1;
        }
    }

    private void moveDownButton_Click(object sender, EventArgs e)
    {
        int index = fieldsCLB.SelectedIndex;
        if (index >= 0 && index < fieldsCLB.Items.Count - 1)
        {
            var item = fieldsCLB.SelectedItem;
            var isChecked = fieldsCLB.GetItemChecked(index);
            fieldsCLB.Items.RemoveAt(index);
            fieldsCLB.Items.Insert(index + 1, item);
            fieldsCLB.SetItemChecked(index + 1, isChecked);
            fieldsCLB.SelectedIndex = index + 1;
        }
    }

    private void helpButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Select desired format.\n " +
                        "Select events to export. \n Select desired fields. \n" +
                        "Field will order from top to bottom as left to right.\n" +
                        "Use Buttons to change order. \n" +
                        "Changing oder and selection here will only affect the exproted document, not the application.\n" +
                        "Use \"Configure Columns\" to change view and selection in the application.\n");
    }
}
