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

public partial class ConfigureColumns : Form
{
    private DataGridView _dataGridView;

    public ConfigureColumns(DataGridView dataGridView)
    {
        InitializeComponent();
        _dataGridView = dataGridView;
        LoadColumnSettings();
    }

    private void LoadColumnSettings()
    {
        columnsCLB.Items.Clear();
        foreach (DataGridViewColumn column in _dataGridView.Columns)
        {
            columnsCLB.Items.Add(column.HeaderText, column.Visible);
        }
    }

    private void moveUpButton_Click(object sender, EventArgs e)
    {
        int index = columnsCLB.SelectedIndex;
        if (index > 0)
        {
            var item = columnsCLB.SelectedItem;
            var isChecked = columnsCLB.GetItemChecked(index);
            columnsCLB.Items.RemoveAt(index);
            columnsCLB.Items.Insert(index - 1, item);
            columnsCLB.SetItemChecked(index - 1, isChecked);
            columnsCLB.SelectedIndex = index - 1;
        }
    }

    private void moveDownButton_Click(object sender, EventArgs e)
    {
        int index = columnsCLB.SelectedIndex;
        if (index >= 0 && index < columnsCLB.Items.Count - 1)
        {
            var item = columnsCLB.SelectedItem;
            var isChecked = columnsCLB.GetItemChecked(index);
            columnsCLB.Items.RemoveAt(index);
            columnsCLB.Items.Insert(index + 1, item);
            columnsCLB.SetItemChecked(index + 1, isChecked);
            columnsCLB.SelectedIndex = index + 1;
        }
    }

    private void applyButton_Click(object sender, EventArgs e)
    {
        // Apply visibility changes and reordering
        var newOrder = columnsCLB.Items.Cast<string>().ToArray();
        _dataGridView.SuspendLayout();

        for (int i = 0; i < columnsCLB.Items.Count; i++)
        {
            var columnName = columnsCLB.Items[i].ToString();
            var column = _dataGridView.Columns.Cast<DataGridViewColumn>()
                          .First(c => c.HeaderText == columnName);
            column.Visible = columnsCLB.GetItemChecked(i);
            column.DisplayIndex = i; // Set DisplayIndex to reflect new order
        }

        _dataGridView.ResumeLayout();
        this.Close();
    }



    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Hide();
    }

    private void columnsCLB_MouseDown(object sender, MouseEventArgs e)
    {
        int index = columnsCLB.IndexFromPoint(e.Location);
        if (index != ListBox.NoMatches)
        {
            // Toggle the checked state
           columnsCLB.SetItemChecked(index, !columnsCLB.GetItemChecked(index));
        }
    }
}
