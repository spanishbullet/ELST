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
        AutoLoadFilePath();
        InitializeMainMenuStrip();
        InitializeDGVEvents();
        InitializeDevicesCLB();
        InitializeTimeControl();
        /*MessageBox.Show($"Point E\ntimeframe = {timeframe}\n" +
                        $"Events size = {customEvents.Count}\n" +
                        $"current devices size = {currentDevices.Count}\n" +
                        $"selected devices size = {selectedDevices.Count}\n" +
                        $"all devices size  = {allDevices.Count}");*/
    }

    private List<CustomEvent> customEvents = new List<CustomEvent>();

    //selected devices
    public List<Device> selectedDevices = new List<Device>();

    //devices with events in the current timeframe
    public List<Device> currentDevices = new List<Device>();

    //all devices in the log
    public List<Device> allDevices = new List<Device>();

    public bool timeframe = false;

    public DateTime originalStartTime;

    public DateTime originalEndTime;

    public DateTime startTime;

    public DateTime endTime;



    private bool caseSensitive = false;

    private void InitializeMainMenuStrip()
    {
        //mainMenuStrip.

        // Host the DateTimePicker in a ToolStripControlHost
        ToolStripControlHost startDTPToolStripControlHost = new ToolStripControlHost(startDTP);
        ToolStripControlHost endDTPToolStripControlHost = new ToolStripControlHost(endDTP);
        ToolStripControlHost timeArrowLabelToolStripControlHost = new ToolStripControlHost(timeArrowLabel);
        ToolStripControlHost applyTimeframeButtonToolStripControlHost = new ToolStripControlHost(applyTimeframeButton);
        ToolStripControlHost resetTiemframeButtomToolStripControlHost = new ToolStripControlHost(resetTimefreameButtom);

        // Add the ToolStripControlHost to the ToolStrip
        mainMenuStrip.Items.Add(startDTPToolStripControlHost);
        mainMenuStrip.Items.Add(timeArrowLabelToolStripControlHost);
        mainMenuStrip.Items.Add(endDTPToolStripControlHost);
        mainMenuStrip.Items.Add(applyTimeframeButtonToolStripControlHost);
        mainMenuStrip.Items.Add(resetTiemframeButtomToolStripControlHost);

    }

    public void InitializeDevicesCLB()
    {
        selectedDevices.Clear();
        GetAllDevices();
        GetCurrentDevices();

        devicesCLB.Items.Clear(); // Clear all items in the CheckedListBox
        foreach (Device device in currentDevices)
        {
            devicesCLB.Items.Add(device.serialNumber); // Add each device's serial number to the CheckedListBox
        }
        for (int i = 0; i < devicesCLB.Items.Count; i++)
        {
            devicesCLB.SetItemChecked(i, true);
        }
        PopulatDGVEvents(customEvents);
    }


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

    public void GetCurrentDevices()
    {
        currentDevices.Clear();
        if (timeframe)
        {
            foreach (CustomEvent customEvent in customEvents)
            {
                if (customEvent.TimeCreated >= startTime && customEvent.TimeCreated <= endTime)
                {
                    if (currentDevices.Count == 0)
                    {
                        Device device = new Device(customEvent);
                        currentDevices.Add(device);
                    }
                    else if (currentDevices.Any(d => d.serialNumber == customEvent.serialNumber))
                    {
                        currentDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                    }
                    else
                    {
                        Device device = new Device(customEvent);
                        currentDevices.Add(device);
                    }
                }
            }
        }
        else
        {
            foreach (CustomEvent customEvent in customEvents)
            {
                if (currentDevices.Count == 0)
                {
                    Device device = new Device(customEvent);
                    currentDevices.Add(device);
                }
                else if (currentDevices.Any(d => d.serialNumber == customEvent.serialNumber))
                {
                    currentDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                }
                else
                {
                    Device device = new Device(customEvent);
                    currentDevices.Add(device);
                }
            }
        }
    }


    public void GetAllDevices()
    {
        allDevices = new List<Device>();

        foreach (CustomEvent customEvent in customEvents)
        {
            if (allDevices.Count == 0)
            {
                Device device = new Device(customEvent);
                allDevices.Add(device);
            }
            if (allDevices.Any(d => d.serialNumber == customEvent.serialNumber))
            {
                allDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
            }
            else
            {
                Device device = new Device(customEvent);
                allDevices.Add(device);
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
                    foreach (Device device in selectedDevices)
                    {
                        if (ce.serialNumber == device.serialNumber)
                        {
                            dgvEvents.Rows.Add(ce.GetAllAttributes().ToArray());
                            
                        }
                    }
                }
            }
        }
        else 
        {
            foreach (CustomEvent ce in customEvents)
            {
                foreach (Device device in selectedDevices)
                {
                    if (ce.serialNumber == device.serialNumber)
                    {
                        dgvEvents.Rows.Add(ce.GetAllAttributes().ToArray());
                        
                    }
                }
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
        if (selectedDevices.Count == currentDevices.Count)
        {
            MessageBox.Show(Analyze.RecordNumber(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "recordId")));

        }
        else
        {
            MessageBox.Show("Must select all devices in current timeframe.");
        }
    }

    private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvEvents.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = Color.White;
            }
        }
    }

    private void timeCToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Analyze.TimeChange2(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "TimeCreated")));
    }

    private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GetCurrentDevices();
        DevicesPage devicePage = new DevicesPage(this);
        devicePage.Show();
    }

    private void InitializeTimeControl()
    {
        startDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"; // Example: 08/13/2024 02:30 PM
        endDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";


        startDTP.Value = customEvents[0].TimeCreated;
        endDTP.Value = customEvents[customEvents.Count - 1].TimeCreated;

        originalStartTime = startDTP.Value;
        originalEndTime = endDTP.Value;
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
            timeframeTSSLabel.Text = $"Timeframe: {startDTP.Value} - {endDTP.Value}";
            selectedDevices.Clear();
            PopulatDGVEvents(customEvents);
            InitializeDevicesCLB();
        }
    }

    private void resetTimeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        timeframe = false;
        PopulatDGVEvents(customEvents);
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        List<Tuple<int, int>> foundCells = Search.SearchDataGridView(dgvEvents, searchTextBox.Text, caseSensitive);
        Search.HighlightFoundCells(dgvEvents, foundCells);
    }

    private void cancelSearchButton_Click(object sender, EventArgs e)
    {
        searchGB.Hide();
    }

    private void caseSensitiveCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (caseSensitiveCheckBox.Checked)
            caseSensitive = true;
        if (!caseSensitiveCheckBox.Checked)
            caseSensitive = false;
    }

    private Point mousDownLocation;

    private void searchGB_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            mousDownLocation = e.Location;
        }
    }
    private void searchGB_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            searchGB.Left = e.X + searchGB.Left - mousDownLocation.X;
            searchGB.Top = e.Y + searchGB.Top - mousDownLocation.Y;
        }
    }

    private void searchToolStripMenuItem_Click(object sender, EventArgs e)
    {
        searchGB.Show();
    }

    private void resetTimefreameButtom_Click(object sender, EventArgs e)
    {
        timeframe = false;
        startDTP.Value = originalStartTime;
        endDTP.Value = originalEndTime;
        timeframeTSSLabel.Text = $"Timeframe: {originalStartTime} - {originalEndTime} (Entire Log)";
        InitializeDevicesCLB();
        PopulatDGVEvents(customEvents);
    }

    private void devicesCLB_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.CurrentValue == CheckState.Unchecked)
        {
            Device currentDevice = currentDevices.FirstOrDefault(d => d.serialNumber == devicesCLB.Items[e.Index].ToString());

            selectedDevices.Add(currentDevice);
        }
        else if (e.CurrentValue == CheckState.Checked)
        {
            Device currentDevice = currentDevices.FirstOrDefault(d => d.serialNumber == devicesCLB.Items[e.Index].ToString());

            selectedDevices.Remove(currentDevice);
        }
        PopulatDGVEvents(customEvents);
    }
}
