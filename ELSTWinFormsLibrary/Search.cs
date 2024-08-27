using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class Search
{
    public static List<Tuple<int, int>> SearchDataGridView(DataGridView dgv, string searchText, bool caseSensitive)
    {
        List<Tuple<int, int>> foundCells = new List<Tuple<int, int>>();

        // Iterate through all the rows and columns
        foreach (DataGridViewRow row in dgv.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null)
                {
                    string cellText = cell.Value.ToString();
                    bool isMatch;

                    if (caseSensitive)
                    {
                        isMatch = cellText.Contains(searchText);
                    }
                    else
                    {
                        isMatch = cellText.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                    }

                    if (isMatch)
                    {
                        // Store the row and column index of the matching cell
                        foundCells.Add(new Tuple<int, int>(cell.RowIndex, cell.ColumnIndex));
                    }
                }
            }
        }
        return foundCells;
    }

    public static void HighlightFoundCells(DataGridView dgv, List<Tuple<int, int>> foundCells)
    {
        foreach (var cellLocation in foundCells)
        {
            // Optionally, change the cell's background color to highlight it
            dgv.Rows[cellLocation.Item1].Cells[cellLocation.Item2].Style.BackColor = Color.LimeGreen;

            // You could also scroll to the first found cell
            dgv.FirstDisplayedScrollingRowIndex = cellLocation.Item1;
        }
    }

    public static void HighlightRowsWithFoundCells(DataGridView dgv, List<Tuple<int, int>> foundCells)
    {
        foreach (var cellLocation in foundCells)
        {
            // Optionally, change the cell's background color to highlight it
            dgv.Rows[cellLocation.Item1].DefaultCellStyle.BackColor = Color.Green;

            // You could also scroll to the first found cell
            dgv.FirstDisplayedScrollingRowIndex = cellLocation.Item1;
        }
    }

    public static void UnhighlightRowsWithFoundCells(DataGridView dgv, List<Tuple<int, int>> foundCells)
    {
        foreach (var cellLocation in foundCells)
        {
            // Optionally, change the cell's background color to highlight it
            dgv.Rows[cellLocation.Item1].DefaultCellStyle.BackColor = Color.White;

            // You could also scroll to the first found cell
            dgv.FirstDisplayedScrollingRowIndex = cellLocation.Item1;
        }
    }

}