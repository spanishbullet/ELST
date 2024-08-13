using ELSTWinFormsLibrary;
using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;


namespace ELST;

public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeComponent();
        InitializeDGVEvents();
        AutoLoadFilePath();
        InitializeTimeControlGB();
    }

    private List<CustomEvent> customEvents = new List<CustomEvent>();

    private List<Device> devices = new List<Device>();

    private bool timeframe = false;

    private DateTime startTime;

    private DateTime endTime;


    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        string aboutMessage = "Version 0.1" +
            " - Prototype still in development.\n" +
                              "This prototype software is aimed to show event logs in a readable format that allows the user to see different events side by side and in context.";
        MessageBox.Show(aboutMessage);
    }

    private void infoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string helpMessage = "Open Event Log File:\n" +
                             " - Click the \"File\" button on the main form menu and then \"Open Log\" to launch a folder dialog.\n" +
                             " - Select a folder containing the .evtx file(s) you want to use.\n" +
                             " - Select and double click the desired .evtx file.\n" +
                             "View Event Data:\n" +
                             " - The event log data will automatically populate in table format within the DataGridView.\n" +
                             "Configure Fields\n" +
                             " - There are default fields that automatically populate.You can change the visible feilds by right clicking any of the column headers.\n" +
                             " - A dropdown menu will apear and you can select or deselect the feilds you wish to see.\n" +
                             " - You can also drag a column header left or right to change the other the feilds apear in.\n" +
                             "Exit\n" +
                             " - You can click the red \"X\" in the top right corner of the window.\n" +
                             " - Alternatively you can select \"File\" in the menu bar and then select \"Exit\".";
        MessageBox.Show(helpMessage); ;
    }

    private string selectedFolderPath = "D:\\Windows\\System32\\winevt\\Logs";
    private string defaultFilePath = "D:\\Windows\\System32\\winevt\\Logs\\Microsoft-Windows-Partition%4Diagnostic.evtx";
    private void AutoLoadFilePath()
    {
        ListDirectory(dirTreeView, selectedFolderPath);
        ActualPathTSSLabel.Text = defaultFilePath;
    }

    private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Open a folder dialog to let the user select a folder
        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Select a folder";
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Store the selected folder path in the class-level variable
                selectedFolderPath = folderBrowserDialog.SelectedPath;
            }
            else
            {
                return;
            }
        }
        ListDirectory(dirTreeView, selectedFolderPath);
    }

    private void ListDirectory(TreeView treeView, string path)
    {
        treeView.Nodes.Clear();
        var rootDirInfo = new DirectoryInfo(path);
        treeView.Nodes.Add(CreateDirectoryNode(rootDirInfo));
    }

    private static TreeNode CreateDirectoryNode(DirectoryInfo dirInfo)
    {
        var dirNode = new TreeNode(dirInfo.Name) { Tag = dirInfo.FullName };
        foreach (var dir in dirInfo.GetDirectories())
        {
            dirNode.Nodes.Add(CreateDirectoryNode(dir));
        }
        foreach (var file in dirInfo.GetFiles())
        {
            var fileNode = new TreeNode(file.Name) { Tag = file.FullName };
            dirNode.Nodes.Add(fileNode);
        }
        return dirNode;
    }

    private void DirTreeViewNode_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        // Check if the node is a file
        if (e.Node.Tag is string filePath && File.Exists(filePath))
        {
            //MessageBox.Show(filePath);
            GetEvents(filePath);
            PopulatDGVEvents(customEvents);
            ActualPathTSSLabel.Text = filePath;
        }
    }

    public void GetEvents(string evtxFilePath)
    {
        try
        {
            // Create an EventLogQuery object for the .evtx file
            EventLogQuery query = new EventLogQuery(evtxFilePath, PathType.FilePath);

            // Create an EventLogReader object
            EventLogReader reader = new EventLogReader(query);

            // Read and display the events
            EventRecord eventRecord;
            while ((eventRecord = reader.ReadEvent()) != null)
            {
                // Creat event object to store events.
                CustomEvent customEvent = new CustomEvent(eventRecord);
                customEvents.Add(customEvent);

                eventRecord.Dispose(); // Release resources
            }
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Error: Unauthorized access. Please run the application as Administrator.");
        }
        catch (EventLogException e)
        {
            MessageBox.Show("Error reading the event log file: " + e.Message);
        }
    }

    public void GetDevices()
    {
        devices = new List<Device>();
        if (timeframe)
        {
            foreach (CustomEvent customEvent in customEvents)
            {
                if (customEvent.TimeCreated >= startTime && customEvent.TimeCreated <= endTime)
                {
                    if (devices.Count == 0)
                    {
                        Device device = new Device(customEvent);
                        devices.Add(device);
                    }
                    if (devices.Any(d => d.serialNumber == customEvent.serialNumber))
                    {
                        devices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                    }
                    else
                    {
                        Device device = new Device(customEvent);
                        devices.Add(device);
                    }
                }
                
            }
        }
        else
        {
            foreach (CustomEvent customEvent in customEvents)
            {
                if (devices.Count == 0)
                {
                    Device device = new Device(customEvent);
                    devices.Add(device);
                }
                if (devices.Any(d => d.serialNumber == customEvent.serialNumber))
                {
                    devices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                }
                else
                {
                    Device device = new Device(customEvent);
                    devices.Add(device);
                }
            }
        }
    }

    private void PopulatDGVEvents(List<CustomEvent> customEvents)
    {
        dgvEvents.Rows.Clear();

        if (timeframe)
        {
            foreach (CustomEvent ce in customEvents)
            {
                if (ce.TimeCreated > startTime && ce.TimeCreated < endTime)
                {
                    dgvEvents.Rows.Add(ce.GetAllAttributes().ToArray());

                }
            }
        }
        else
        {
            foreach (CustomEvent ce in customEvents)
            {
                dgvEvents.Rows.Add(ce.GetAllAttributes().ToArray());
            }
        }

    }

    private void InitializeDGVEvents()
    {
        // Set up the DataGridView columns
        //ORDER MATTERS*******************
        dgvEvents.Columns.Add("EventId", "Event ID");
        dgvEvents.Columns.Add("ProviderName", "Provider Name");
        dgvEvents.Columns.Add("Level", "Level");
        dgvEvents.Columns.Add("Message", "Message");
        dgvEvents.Columns.Add("RecordId", "Record Number");
        dgvEvents.Columns.Add("TimeCreated", "Time Created");
        dgvEvents.Columns.Add("Capacity", "Capacity");
        dgvEvents.Columns.Add("Action", "Action");
        dgvEvents.Columns.Add("Manufacturer", "Manufacturer");
        dgvEvents.Columns.Add("Model", "Model");
        dgvEvents.Columns.Add("Revision", "Revision");
        dgvEvents.Columns.Add("SerialNumber", "Serial Number");
        dgvEvents.Columns.Add("ParentID", "Parent ID");
        dgvEvents.Columns.Add("Vbr0", "Vbr0");

        //Hide Columns
        dgvEvents.Columns["EventId"].Visible = false;
        dgvEvents.Columns["Message"].Visible = false;
        dgvEvents.Columns["ProviderName"].Visible = false;
        dgvEvents.Columns["Level"].Visible = false;




        // Adjust column widths
        dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        GetEvents(defaultFilePath);
        PopulatDGVEvents(customEvents);
        //GetDevices();
    }

    private void dgvEvents_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTestInfo = dgvEvents.HitTest(e.X, e.Y);
            if (hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                foreach (DataGridViewColumn column in dgvEvents.Columns)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;
                    };
                    menu.Items.Add(item);
                }
                menu.Show(dgvEvents, e.Location);
            }
        }
    }

    public static Dictionary<string, List<object>> ExtractDataFromColumns(DataGridView dataGridView, List<string> targetColumnNames)
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

    private void recordNumbersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Analyze.RecordNumber(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "recordId")));
    }

    private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvEvents.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }
    }

    private void timeCToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Analyze.TimeChange2(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "TimeCreated")));
    }

    private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GetDevices();
        DevicesPage devicePage = new DevicesPage(devices);
        devicePage.Show();
    }

    private void timeframeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        timeControlGB.Show();
    }

    private void cancelTimeFrameButton_Click(object sender, EventArgs e)
    {
        timeControlGB.Hide();
    }

    private void InitializeTimeControlGB()
    {
        startDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"; // Example: 08/13/2024 02:30 PM
        endDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

        startDTP.Value = customEvents[0].TimeCreated;
        endDTP.Value = customEvents[customEvents.Count - 1].TimeCreated;
    }

    private void applyTimeFrameButton_Click(object sender, EventArgs e)
    {
        if (startDTP.Value >= endDTP.Value)
        {
            MessageBox.Show("Date/Times not valid. \nEnd time must be later than start time. \n Please pick new Date/Times");
        }
        else
        {
            timeframe = true;
            startTime = startDTP.Value;
            endTime = endDTP.Value;
            timeControlGB.Hide();
            timeframeTSSLabel.Text = $"Timeframe: {startDTP.Value} - {endDTP.Value}";
            PopulatDGVEvents(customEvents);
            //MessageBox.Show($"timefram: {timeframe} \nStartTime: {startTime} \nEndTime: {endTime}");
        }
    }

    private void resetTimeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        timeframe = false;
        PopulatDGVEvents(customEvents);
    }
}
