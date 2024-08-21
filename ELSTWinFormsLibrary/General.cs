using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ELSTWinFormsLibrary;

public class FormatVbr0
{
    public static byte[] convert(string hexString)
    {
        return Enumerable.Range(0, hexString.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                         .ToArray();
    }

    public static string Extract(string vbr0HexStr)
    {
        if (vbr0HexStr.Length == 0)
        {
            return "Empty";
        }
        //else if (vbr0HexStr.Length != 512)
        //{
        //    return "Unexpected Size";
        //}

        byte[] vbr0Data = convert(vbr0HexStr);

        // Extract 4-byte values at the given offsets
        uint valueAt43 = BitConverter.ToUInt32(vbr0Data, 0x43); // Little Endian
        uint valueAt64 = BitConverter.ToUInt32(vbr0Data, 0x64); // Little Endian
        uint valueAt48 = BitConverter.ToUInt32(vbr0Data, 0x48); // Little Endian

        // Output the values
        return $"0x43: 0x{valueAt43:X8}, 0x64: 0x{valueAt64:X8},  0x48: 0x{valueAt48:X8}";
    }

}

public class XmlExtract
{
    public static string GetField(string xml, string fieldName)
    {
        try
        {
            // Load XML document
            XDocument doc = XDocument.Parse(xml);

            // Namespace handling (important to match the XML namespace)
            XNamespace ns = "http://schemas.microsoft.com/win/2004/08/events/event";

            // Search for the field in <EventData> section
            XElement dataElement = doc.Descendants(ns + "EventData").Descendants(ns + "Data").FirstOrDefault(e => (string)e.Attribute("Name") == fieldName);

            return dataElement?.Value ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }
}

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

public class Analyze
{
    public static string RecordNumber(DataGridView dgv, List<object> columnData)
    {
        /*foreach (DataGridViewRow row in dgv.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }*/
        string message = "";
        List<int> recordIds = columnData.ConvertAll(new Converter<object, int>(Convert.ToInt32));
        List<int> result = new List<int>();
        if (recordIds.Count > 0)
        {
            List<int> rows= new List<int>();
            var lastItem = recordIds[0];

            // Check if the first item is a discontinuity compared to the second item
            if (recordIds.Count > 1 && recordIds[1] != lastItem + 1)
            {
                message = "Possible anomalies at row(s):\n";
                message += 1 + "\n";
                rows.Add(lastItem);
            }

            for (int i = 1; i < recordIds.Count - 1; i++)
            {
                var currentItem = recordIds[i];
                var nextItem = recordIds[i + 1];

                // If the current item is not continuous with the last or next, add it to result
                if (currentItem != lastItem + 1 || nextItem != currentItem + 1)
                {
                    if (message.Length == 0)
                        message = "Possible anomalies at row(s):\n";
                    message += (i+1) + "\n";
                    rows.Add(i);
                }

                lastItem = currentItem;
            }

            // Check if the last item is a discontinuity compared to the second last item
            if (recordIds.Count > 1 && recordIds[recordIds.Count - 1] != recordIds[recordIds.Count - 2] + 1)
            {
                if (message.Length == 0)
                    message += recordIds.Count;
                rows.Add(recordIds.Count-1);
                message += recordIds.Count;
            }

            //highlight rows in dgv
            foreach (int row in rows)
            {
                dgv.Rows[row].DefaultCellStyle.BackColor = Color.Red;
            }

        }
        if (message.Length == 0)
            message = "No anomalies detected.";
        return message;
    }

    public static string TimeChange(DataGridView dgv, List<CustomEvent> customEvents)
    {
        /*foreach (DataGridViewRow row in dgv.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }*/
        string message = "";
        List<DateTime> times = new List<DateTime>();
        List<int> rows = new List<int>();

        foreach (CustomEvent customEvent in customEvents)
        {
            times.Add(customEvent.TimeCreated);
        }

        DateTime lastItem = times[0];
        DateTime currentItem;

        for (int i = 1; i < times.Count; i++ )
        {
            currentItem = times[i];
            if (currentItem <= lastItem)
            {
                if (message.Length == 0)
                    message = "Possible anomalies at row(s):\n";
                message += (i + 1) + "\n";
                rows.Add(i);
            }
            lastItem = currentItem;
        }

        //highlight rows in dgv
        foreach (int row in rows)
        {
            dgv.Rows[row].DefaultCellStyle.BackColor = Color.Purple;
        }

        if (message.Length == 0)
            message = "No anomalies detected";

        return message;
    }

    public static string TimeChange2(DataGridView dgv, List<object> columnData)
    {
        List<DateTime> times = columnData.ConvertAll(new Converter<object, DateTime>(Convert.ToDateTime));
        string message = "";
        List<int> result = new List<int>();
        if (columnData.Count > 0)
        {
            List<int> rows = new List<int>();
            DateTime lastItem = times[0];
            DateTime currentItem;

            for (int i = 1; i < times.Count; i++)
            {
                currentItem = times[i];
                if (currentItem <= lastItem)
                {
                    if (message.Length == 0)
                        message = "Possible anomalies at row(s):\n";
                    message += (i + 1) + "\n";
                    rows.Add(i);
                }
                lastItem = currentItem;
            }

            //highlight rows in dgv
            foreach (int row in rows)
            {
                dgv.Rows[row].DefaultCellStyle.BackColor = Color.MediumPurple;
            }

        }
        if (message.Length == 0)
            message = "No anomalies detected.";
        return message;
    }
}

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

public class Startup()
{

    public static List<string> Search(string dir, string fileName, IProgress<int> progress = null)
    {
        int processedDirectories = 1;
        return searchDirectory(dir, fileName, CountTotalDirectories(dir), ref processedDirectories, progress);
    }

    private static List<string> searchDirectory(string dir, string fileName, int totalDirectories, ref int processedDirectories, IProgress<int> progress = null)
    {
        List<string> filePaths = new List<string>();

        try
        {
            // Process the current directory
            foreach (string file in Directory.GetFiles(dir, fileName))
            {
                filePaths.Add(file);
            }

            // Report progress after processing the current directory
            processedDirectories++;
            int progressPercentage = (processedDirectories * 100) / totalDirectories;
            progress?.Report(progressPercentage);

            // Recursively search in subdirectories
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                filePaths.AddRange(searchDirectory(subDir, fileName, totalDirectories, ref processedDirectories, progress));
            }
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (Exception ex) { Console.WriteLine($"Error searching files: {ex.Message}"); }

        return filePaths;
    }


    private static int CountTotalDirectories(string dir)
    {
        int count = 1; // Start with 1 to include the current directory

        try
        {
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                count += CountTotalDirectories(subDir); // Recursively count subdirectories
            }
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return count;
    }
}