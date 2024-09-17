using NPOI.SS.Formula.Functions;
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
    private readonly DataGridView _dataGridView;

    private ToolStripStatusLabel _toolStripStatusLabel;

    public ConfigureColumns(DataGridView dataGridView, ToolStripStatusLabel toolStripStatusLabel)
    {
        InitializeComponent();
        _dataGridView = dataGridView;
        _toolStripStatusLabel = toolStripStatusLabel;
        LoadColumnSettings();
    }

    private void LoadColumnSettings()
    {
        // Get columns from the DataGridView and sort them by DisplayIndex
        var sortedColumns = _dataGridView.Columns.Cast<DataGridViewColumn>()
                                .OrderBy(c => c.DisplayIndex)
                                .ToList();
        // Add columns to the CheckedListBox in sorted order
        foreach (DataGridViewColumn column in sortedColumns)
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
        int visibleCount = 0;

        for (int i = 0; i < columnsCLB.Items.Count; i++)
        {
            var columnName = columnsCLB.Items[i].ToString();
            var column = _dataGridView.Columns.Cast<DataGridViewColumn>()
                          .First(c => c.HeaderText == columnName);
            if (columnsCLB.GetItemChecked(i))
            {
                column.Visible = true;
                visibleCount++;
            }
            column.DisplayIndex = i; // Set DisplayIndex to reflect new order
        }

        _toolStripStatusLabel.Text = $"Showing {visibleCount} of 20 Columns";

        _dataGridView.ResumeLayout();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
