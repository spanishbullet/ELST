using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class dgvExtract()
{
    public static List<object> ExtractColumnData(DataGridView dataGridView, string columnName)
    {
        List<object> columnData = new List<object>();

        // Check if the column exists in the DataGridView
        if (dataGridView.Columns[columnName] == null)
        {
            throw new ArgumentException($"Column '{columnName}' does not exist in the DataGridView.");
        }

        // Iterate through the rows and collect data from the specified column
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (!row.IsNewRow)
            {
                var cellValue = row.Cells[columnName].Value;
                columnData.Add(cellValue);
            }
        }

        return columnData;
    }


    public static Dictionary<string, List<object>> ExtractColumnsData(DataGridView dataGridView, List<string> targetColumnNames)
    {
        var columnData = new Dictionary<string, List<object>>();

        // Initialize lists for each specified column
        foreach (var columnName in targetColumnNames)
        {
            if (dataGridView.Columns[columnName] != null) // Check if column exists
            {
                columnData[columnName] = new List<object>();
            }
            else
            {
                // Handle the case where the column does not exist
                throw new ArgumentException($"Column '{columnName}' does not exist in the DataGridView.");
            }
        }

        // Iterate through the rows and collect data
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (!row.IsNewRow)
            {
                foreach (var columnName in targetColumnNames)
                {
                    if (columnData.ContainsKey(columnName))
                    {
                        var cellValue = row.Cells[columnName].Value;
                        columnData[columnName].Add(cellValue);
                    }
                }
            }
        }
        return columnData;
    }
}

