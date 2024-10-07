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

public partial class LogPropertiesWindow : Form
{
    private string filePath;
    public LogPropertiesWindow(string Path)
    {
        filePath = Path;
        InitializeComponent();

        FileInfo fileInfo = new FileInfo(filePath);

        // Get file information
        logFileName.Text = filePath;
        long fileSizeInBytes = fileInfo.Length;
        double fileSizeInKB = fileSizeInBytes / 1024.0; // Kilobytes
        fileSize.Text = $"{fileSizeInKB}KB ({fileSizeInBytes} bytes)";
        fileCreated.Text = fileInfo.CreationTime.ToString();
        fileAccessed.Text = fileInfo.LastAccessTime.ToString();
        fileModified.Text = fileInfo.LastWriteTime.ToString();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void LogPropertiesWindow_Deactivate(object sender, EventArgs e)
    {
        this.Close();
    }
}
