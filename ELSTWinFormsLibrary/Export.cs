using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.OpenXmlFormats.Dml.Chart;

namespace ELSTWinFormsLibrary;

public class Export
{
    public static void ToExcel(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        // Enable ExcelPackage to work without a license context (non-commercial use)
        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage())
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ExportedData");

            // Create a list to keep track of the selected columns
            var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

            // Export column headers for checked items
            int columnIndex = 1;
            foreach (var item in selectedColumns)
            {
                int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                if (dgvColumnIndex >= 0)
                {
                    worksheet.Cells[1, columnIndex].Value = dgv.Columns[dgvColumnIndex].HeaderText;
                    columnIndex++;
                }
            }

            // Export data rows for checked columns
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                if (!dgv.Rows[rowIndex].IsNewRow)
                {
                    columnIndex = 1;
                    foreach (var item in selectedColumns)
                    {
                        int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                        if (dgvColumnIndex >= 0)
                        {
                            worksheet.Cells[rowIndex + 2, columnIndex].Value = dgv.Rows[rowIndex].Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty;
                            columnIndex++;
                        }
                    }
                }
            }

            // Auto-fit columns
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Prompt the user to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(saveFileDialog.FileName);
                package.SaveAs(fi);
                MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


    public static void ToXls(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("ExportedData");

        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

        // Export column headers
        IRow headerRow = sheet.CreateRow(0);
        int columnIndex = 0;
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                headerRow.CreateCell(columnIndex).SetCellValue(dgv.Columns[dgvColumnIndex].HeaderText);
                columnIndex++;
            }
        }

        // Export data rows
        for (int i = 0; i < dgv.Rows.Count; i++)
        {
            if (!dgv.Rows[i].IsNewRow)
            {
                IRow row = sheet.CreateRow(i + 1);
                columnIndex = 0;
                foreach (var item in selectedColumns)
                {
                    int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                    if (dgvColumnIndex >= 0)
                    {
                        row.CreateCell(columnIndex).SetCellValue(dgv.Rows[i].Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty);
                        columnIndex++;
                    }
                }
            }
        }

        // Manually adjust column widths
        for (int i = 0; i < selectedColumns.Count; i++)
        {
            sheet.AutoSizeColumn(i);
        }

        // Save the XLS file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Excel files (*.xls)|*.xls",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    

    public static void ToHtml(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();
        StringBuilder html = new StringBuilder();

        html.AppendLine("<html><body><table border='1'>");

        // Export column headers
        html.AppendLine("<tr>");
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                html.AppendLine($"<th>{dgv.Columns[dgvColumnIndex].HeaderText}</th>");
            }
        }
        html.AppendLine("</tr>");

        // Export data rows
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                html.AppendLine("<tr>");
                foreach (var item in selectedColumns)
                {
                    int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                    if (dgvColumnIndex >= 0)
                    {
                        html.AppendLine($"<td>{row.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty}</td>");
                    }
                }
                html.AppendLine("</tr>");
            }
        }

        html.AppendLine("</table></body></html>");

        // Save the HTML file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "HTML files (*.html)|*.html",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, html.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void ToTxt(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();
        StringBuilder txt = new StringBuilder();

        // Export column headers
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                txt.Append(dgv.Columns[dgvColumnIndex].HeaderText + "\t");
            }
        }
        txt.AppendLine();

        // Export data rows
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                foreach (var item in selectedColumns)
                {
                    int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                    if (dgvColumnIndex >= 0)
                    {
                        txt.Append(row.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty + "\t");
                    }
                }
                txt.AppendLine();
            }
        }

        // Save the TXT file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Text files (*.txt)|*.txt",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, txt.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SelectedToExcel(DataGridView dgv, CheckedListBox fieldsCLB)
    {        
        // Enable ExcelPackage to work without a license context (non-commercial use)
        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage())
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ExportedData");

            // Create a list to keep track of the selected columns
            var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

            // Export column headers for checked items
            int columnIndex = 1;
            foreach (var item in selectedColumns)
            {
                int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                if (dgvColumnIndex >= 0)
                {
                    worksheet.Cells[1, columnIndex].Value = dgv.Columns[dgvColumnIndex].HeaderText;
                    columnIndex++;
                }
            }

            // Sort selected rows by their index to maintain original order
            var orderedSelectedRows = dgv.SelectedRows.Cast<DataGridViewRow>()
                .OrderBy(r => r.Index)
                .ToList();

            // Export data rows for checked columns from selected rows only
            int rowIndex = 0; // This is for the Excel worksheet row index
            foreach (DataGridViewRow selectedRow in orderedSelectedRows)
            {
                rowIndex++; // Increment worksheet row index for each selected row
                columnIndex = 1;

                foreach (var item in selectedColumns)
                {
                    int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                    if (dgvColumnIndex >= 0)
                    {
                        worksheet.Cells[rowIndex + 1, columnIndex].Value = selectedRow.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty;
                        columnIndex++;
                    }
                }
            }

            // Auto-fit columns
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Prompt the user to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(saveFileDialog.FileName);
                package.SaveAs(fi);
                MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public static void SelectedToXls(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        IWorkbook workbook = new HSSFWorkbook(); // Use HSSFWorkbook for .xls
        ISheet worksheet = workbook.CreateSheet("ExportedData");

        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

        // Export column headers for checked items
        IRow headerRow = worksheet.CreateRow(0);
        int columnIndex = 0;
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                headerRow.CreateCell(columnIndex).SetCellValue(dgv.Columns[dgvColumnIndex].HeaderText);
                columnIndex++;
            }
        }

        // Sort selected rows by their index to maintain original order
        var orderedSelectedRows = dgv.SelectedRows.Cast<DataGridViewRow>()
            .OrderBy(r => r.Index)
            .ToList();

        // Export data rows for checked columns from selected rows only
        int rowIndex = 1; // Start from the first row after the header
        foreach (DataGridViewRow selectedRow in orderedSelectedRows)
        {
            IRow row = worksheet.CreateRow(rowIndex++);
            columnIndex = 0;

            foreach (var item in selectedColumns)
            {
                int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                if (dgvColumnIndex >= 0)
                {
                    row.CreateCell(columnIndex).SetCellValue(selectedRow.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty);
                    columnIndex++;
                }
            }
        }

        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Excel files (*.xls)|*.xls",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SelectedToHtml(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

        StringBuilder html = new StringBuilder();
        html.AppendLine("<table border='1'>");

        // Export column headers for checked items
        html.AppendLine("<tr>");
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                html.AppendLine($"<th>{dgv.Columns[dgvColumnIndex].HeaderText}</th>");
            }
        }
        html.AppendLine("</tr>");

        // Sort selected rows by their index to maintain original order
        var orderedSelectedRows = dgv.SelectedRows.Cast<DataGridViewRow>()
            .OrderBy(r => r.Index)
            .ToList();

        // Export data rows for checked columns from selected rows only
        foreach (DataGridViewRow selectedRow in orderedSelectedRows)
        {
            html.AppendLine("<tr>");
            foreach (var item in selectedColumns)
            {
                int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                if (dgvColumnIndex >= 0)
                {
                    html.AppendLine($"<td>{selectedRow.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty}</td>");
                }
            }
            html.AppendLine("</tr>");
        }

        html.AppendLine("</table>");

        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "HTML files (*.html)|*.html",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, html.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SelectedToTxt(DataGridView dgv, CheckedListBox fieldsCLB)
    {
        var selectedColumns = fieldsCLB.CheckedItems.Cast<string>().ToList();

        StringBuilder txt = new StringBuilder();

        // Export column headers for checked items
        foreach (var item in selectedColumns)
        {
            int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
            if (dgvColumnIndex >= 0)
            {
                txt.Append($"{dgv.Columns[dgvColumnIndex].HeaderText}\t");
            }
        }
        txt.AppendLine();

        // Sort selected rows by their index to maintain original order
        var orderedSelectedRows = dgv.SelectedRows.Cast<DataGridViewRow>()
            .OrderBy(r => r.Index)
            .ToList();

        // Export data rows for checked columns from selected rows only
        foreach (DataGridViewRow selectedRow in orderedSelectedRows)
        {
            foreach (var item in selectedColumns)
            {
                int dgvColumnIndex = dgv.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item)?.Index ?? -1;
                if (dgvColumnIndex >= 0)
                {
                    txt.Append($"{selectedRow.Cells[dgvColumnIndex].Value?.ToString() ?? string.Empty}\t");
                }
            }
            txt.AppendLine();
        }

        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Text files (*.txt)|*.txt",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, txt.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
