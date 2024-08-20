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
    public static void ToExcel(DataGridView dgv)
    {
        // Enable ExcelPackage to work without a license context (non-commercial use)
        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage())
        {
            // Add a new worksheet to the Excel workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ExportedData");

            // Export the column headers
            for (int i = 1; i <= dgv.Columns.Count; i++)
            {
                worksheet.Cells[1, i].Value = dgv.Columns[i - 1].HeaderText;
            }

            // Export the data rows
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            // Format cells to fit data
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Prompt the user to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(saveFileDialog.FileName);
                package.SaveAs(fi);
                MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


    public static void ToXls(DataGridView dgv)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("ExportedData");
    
        // Export column headers
        IRow headerRow = sheet.CreateRow(0);
        for (int i = 0; i < dgv.Columns.Count; i++)
        {
            headerRow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText);
        }
    
        // Export data rows
        for (int i = 0; i < dgv.Rows.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                if (dgv.Rows[i].Cells[j].Value != null)
                {
                    row.CreateCell(j).SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                }
            }
        }
        
        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;
    
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    

    public static void ToHtml(DataGridView dgv)
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<html><body><table border='1'>");

        // Create header row
        html.AppendLine("<tr>");
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            html.AppendFormat("<th>{0}</th>", column.HeaderText);
        }
        html.AppendLine("</tr>");

        // Create data rows
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                html.AppendLine("<tr>");
                foreach (DataGridViewCell cell in row.Cells)
                {
                    html.AppendFormat("<td>{0}</td>", cell.Value?.ToString() ?? string.Empty);
                }
                html.AppendLine("</tr>");
            }
        }

        html.AppendLine("</table></body></html>");

        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "HTML files (*.html)|*.html";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, html.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void ToTxt(DataGridView dgv)
    {
        StringBuilder txt = new StringBuilder();

        // Create header row
        for (int i = 0; i < dgv.Columns.Count; i++)
        {
            txt.Append(dgv.Columns[i].HeaderText);
            if (i < dgv.Columns.Count - 1) txt.Append("\t");
        }
        txt.AppendLine();

        // Create data rows
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    txt.Append(row.Cells[i].Value?.ToString() ?? string.Empty);
                    if (i < dgv.Columns.Count - 1) txt.Append("\t");
                }
                txt.AppendLine();
            }
        }

        // Prompt the user to save the file
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, txt.ToString());
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SelectedToExcel(DataGridView dgv)
    {

    }

    public static void SelectedToXls(DataGridView dgv)
    {

    }

    public static void SelectedToHtml(DataGridView dgv)
    {

    }

    public static void SelectedToTxt(DataGridView dgv)
    {

    }
}
