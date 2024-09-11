using ELSTWinFormsLibrary;
using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System.Drawing.Text;
using System.ComponentModel;


namespace ELST;

public partial class MainMenu : Form
{
    public MainMenu(string filePath)
    {
        defaultFilePath = filePath;
        selectedFolderPath = System.IO.Path.GetDirectoryName(defaultFilePath);
        baseDirPath = Path.GetPathRoot(defaultFilePath);
        filesOfInterest.Add(filePath);

        InitializeComponent();
        AutoLoadFilePath();
        InitializeMainMenuStrip();
        InitializeDGVEvents();
        InitializeDevicesCLB();
        InitializeTimeControl();
    }
    public MainMenu(List<string> files)
    {
        filesOfInterest = files;
        defaultFilePath = files[0];
        selectedFolderPath = System.IO.Path.GetDirectoryName(defaultFilePath);
        baseDirPath = Path.GetPathRoot(defaultFilePath);

        InitializeComponent();
        AutoLoadFilePath();
        InitializeMainMenuStrip();
        InitializeDGVEvents();
        InitializeDevicesCLB();
        InitializeTimeControl();
    }

    //path variables
    private string defaultFilePath;

    private string selectedFolderPath;

    private readonly string baseDirPath;

    //list of events
    private readonly List<CustomEvent> customEvents = [];

    //selected devices
    public List<Device> selectedDevices = [];

    //devices with events in the current timeframe
    public List<Device> currentDevices = [];

    //all devices in the log
    public List<Device> allDevices = [];

    //variables used for timeframe
    public bool timeframe = false;

    public DateTime originalStartTime;

    public DateTime originalEndTime;

    public DateTime startTime;

    public DateTime endTime;

    //drive to search for files of interest
    public string drive;

    //list of files of interest found in drive
    public List<string> filesOfInterest = [];

    //for search function
    private bool caseSensitive = false;

    // event used as filter
    public CustomEvent filter = new();

    private void InitializeMainMenuStrip()
    {
        //mainMenuStrip.

        // Host the DateTimePicker in a ToolStripControlHost
        ToolStripControlHost startDTPToolStripControlHost = new(startDTP);
        ToolStripControlHost endDTPToolStripControlHost = new(endDTP);
        ToolStripControlHost timeArrowLabelToolStripControlHost = new(timeArrowLabel);
        ToolStripControlHost applyTimeframeButtonToolStripControlHost = new(applyTimeframeButton);
        ToolStripControlHost resetTiemframeButtomToolStripControlHost = new(resetTimefreameButtom);

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
            " - Prototype still in development.";
        MessageBox.Show(aboutMessage);
    }

    private void infoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        HelpWindow helpWindow = new HelpWindow();
        helpWindow.Show();
    }

    private void AutoLoadFilePath()
    {
        //ListDirectory(dirTreeView, selectedFolderPath);
        ListAllDirectories(dirTreeView, filesOfInterest);
        ActualPathTSSLabel.Text = "";

        foreach (string path in filesOfInterest)
        {
            ActualPathTSSLabel.Text += path + "\n";
        }
        ActualPathTSSLabel.Text = ActualPathTSSLabel.Text.Remove(ActualPathTSSLabel.Text.Length - 2);
    }

    private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*OpenFileDialog openFileDialog = new OpenFileDialog();

        // Set filter options and filter index.
        openFileDialog.Title = "Select a folder";
        openFileDialog.Filter = "Event Log Files (*.evtx)|*.evtx|All Files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;
        openFileDialog.Multiselect = false;
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

        // Show the dialog and get result.
        DialogResult result = openFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            // Get the selected file's path.
            string filePath = openFileDialog.FileName;
            defaultFilePath = filePath;
            selectedFolderPath = System.IO.Path.GetDirectoryName(filePath);
        }
        else
        {
            return;
        }

        ListDirectory(dirTreeView, selectedFolderPath);
        InitializeDGVEvents();
        InitializeDevicesCLB();
        InitializeTimeControl();*/
    }

    private static void ListDirectory(TreeView treeView, string path)
    {
        treeView.Nodes.Clear();
        var rootDirInfo = new DirectoryInfo(path);
        treeView.Nodes.Add(CreateDirectoryNode(rootDirInfo));
        treeView.ExpandAll();
    }

    private static void ListAllDirectories(TreeView treeView, List<string> paths)
    {
        treeView.Nodes.Clear();
        foreach (string path in paths)
        {
            var rootDirInfo = new DirectoryInfo(System.IO.Path.GetDirectoryName(path));
            treeView.Nodes.Add(CreateDirectoryNode(rootDirInfo));
            treeView.ExpandAll();
        }
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

            GetEvents(filesOfInterest);
            InitializeDevicesCLB();
            PopulatDGVEvents(customEvents);
            ActualPathTSSLabel.Text = filePath;
        }
    }

    public void GetEvents(List<string> filePaths)
    {
        customEvents.Clear();

        foreach (string file in filePaths)
        {
            try
            {
                // Create an EventLogQuery object for the .evtx file
                EventLogQuery query = new(file, PathType.FilePath);

                // Create an EventLogReader object
                EventLogReader reader = new(query);

                // Read and display the events
                EventRecord eventRecord;
                while ((eventRecord = reader.ReadEvent()) != null)
                {
                    // Creat event object to store events.
                    CustomEvent customEvent = new(eventRecord);
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
                        Device device = new(customEvent);
                        currentDevices.Add(device);
                    }
                    else if (currentDevices.Any(d => d.serialNumber == customEvent.serialNumber))
                    {
                        currentDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                    }
                    else
                    {
                        Device device = new(customEvent);
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
                    Device device = new(customEvent);
                    currentDevices.Add(device);
                }
                else if (currentDevices.Any(d => d.serialNumber == customEvent.serialNumber))
                {
                    currentDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
                }
                else
                {
                    Device device = new(customEvent);
                    currentDevices.Add(device);
                }
            }
        }
    }


    public void GetAllDevices()
    {
        allDevices = [];

        foreach (CustomEvent customEvent in customEvents)
        {
            if (allDevices.Count == 0)
            {
                Device device = new(customEvent);
                allDevices.Add(device);
            }
            if (allDevices.Any(d => d.serialNumber == customEvent.serialNumber))
            {
                allDevices.FirstOrDefault(d => d.serialNumber == customEvent.serialNumber).AddEvent(customEvent);
            }
            else
            {
                Device device = new(customEvent);
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
                            if (ce.Equals(filter))
                            {
                                dgvEvents.Rows.Add([.. ce.GetAllAttributes()]);
                            }
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
                        if (ce.Equals(filter))
                        {
                            dgvEvents.Rows.Add([.. ce.GetAllAttributes()]);
                        }
                    }
                }
            }
        }

        dgvEvents.Sort(dgvEvents.Columns["TimeCreated"], ListSortDirection.Ascending);

        eventsTSSLabel.Text = $"Showing {dgvEvents.Rows.Count} of {customEvents.Count} Events";
    }

    private void InitializeDGVEvents()
    {
        dgvEvents.Columns.Clear();
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
        dgvEvents.Columns.Add("ProcessId", "Process ID");
        dgvEvents.Columns.Add("ThreadId", "Thread ID");
        dgvEvents.Columns.Add("Channel", "Channel");
        dgvEvents.Columns.Add("Computer", "Computer");
        dgvEvents.Columns.Add("UserId", "User ID");
        dgvEvents.Columns.Add("Vbr0", "Vbr0");

        //Hide Columns
        dgvEvents.Columns["EventId"].Visible = false;
        dgvEvents.Columns["Message"].Visible = false;
        dgvEvents.Columns["ProviderName"].Visible = false;
        dgvEvents.Columns["Level"].Visible = false;

        //neccesary for correct sorting/comparison by time
        dgvEvents.Columns["TimeCreated"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
        dgvEvents.Columns["TimeCreated"].ValueType = typeof(DateTime);



        // Adjust column widths
        dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        dgvEvents.Height = splitContainer1.Panel2.ClientSize.Height - pathStatusStrip.Height - eventsStatusStrip.Height;

        GetEvents(filesOfInterest);
        PopulatDGVEvents(customEvents);
    }

    private void dgvEvents_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTestInfo = dgvEvents.HitTest(e.X, e.Y);
            if (hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenuStrip menu = new();
                foreach (DataGridViewColumn column in dgvEvents.Columns)
                {
                    ToolStripMenuItem item = new()
                    {
                        Text = column.HeaderText,
                        Checked = column.Visible
                    };
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;
                    };
                    menu.Items.Add(item);
                }
                menu.Show(dgvEvents, e.Location);
            }
            else if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
            {
                int rowIndex = hitTestInfo.RowIndex;
                if (rowIndex >= 0 && rowIndex < dgvEvents.Rows.Count && dgvEvents.Rows[rowIndex].Selected)
                {
                    DataGridViewRow row = dgvEvents.Rows[rowIndex];
                    ContextMenuStrip menu = new();
                    ToolStripMenuItem eventProperties = new()
                    {
                        Text = "Event Properties"
                    };
                    eventProperties.Click += (obj, ea) =>
                    {
                        EventPropertiesPage eventPropertiesPage = new(dgvEvents, customEvents, rowIndex);
                        eventPropertiesPage.Show();
                    };
                    ToolStripMenuItem logProperties = new()
                    {
                        Text = "Log Properties"
                    };
                    logProperties.Click += (obj, ea) =>
                    {
                        foreach (var file in filesOfInterest)
                        {
                            LogPropertiesWindow logPropertiesWindow = new(file);
                            logPropertiesWindow.Show();
                        }
                    };
                    ToolStripMenuItem highlightEvent = new()
                    {
                        Text = "Highlight Event"
                    };
                    highlightEvent.Click += (obj, ea) =>
                    {
                        dgvEvents.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    };
                    ToolStripMenuItem removeHighlight = new()
                    {
                        Text = "Remove Highlight"
                    };
                    removeHighlight.Click += (obj, ea) =>
                    {
                        dgvEvents.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    };
                    ToolStripMenuItem hideEvent = new()
                    {
                        Text = "Hide Event"
                    };
                    hideEvent.Click += (obj, ea) =>
                    {
                        dgvEvents.Rows.RemoveAt(rowIndex);
                    };
                    ToolStripMenuItem showHiddenEvents = new()
                    {
                        Text = "Show Hidden Events"
                    };
                    showHiddenEvents.Click += (obj, ea) =>
                    {
                        PopulatDGVEvents(customEvents);
                    };

                    menu.Items.Add(eventProperties);
                    menu.Items.Add(logProperties);
                    menu.Items.Add(highlightEvent);
                    menu.Items.Add(removeHighlight);
                    menu.Items.Add(hideEvent);
                    menu.Items.Add(showHiddenEvents);
                    menu.Show(dgvEvents, e.Location);
                }
            }
        }
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
        MessageBox.Show(Analyze.TimeChange(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "TimeCreated")));
    }

    private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GetCurrentDevices();
        DevicesPage devicePage = new(this);
        devicePage.Show();
    }

    private void InitializeTimeControl()
    {
        startDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"; // Example: 08/13/2024 02:30 PM
        endDTP.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";


        startDTP.Value = (DateTime)customEvents[0].TimeCreated;
        endDTP.Value = (DateTime)customEvents[^1].TimeCreated;

        originalStartTime = startDTP.Value;
        originalEndTime = endDTP.Value;
    }

    private void applyTimeFrameButton_Click(object sender, EventArgs e)
    {
        if (startDTP.Value >= endDTP.Value)
        {
            MessageBox.Show("Date/Times not valid. \nEnd time must be later than start time. \n Please pick new Date/Times");
        }
        else if (startDTP.Value != originalStartTime || endDTP.Value != originalEndTime)
        {
            timeframe = true;
            startTime = startDTP.Value;
            endTime = endDTP.Value;
            selectedDevices.Clear();
            InitializeDevicesCLB();
            PopulatDGVEvents(customEvents);
        }
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
        InitializeDevicesCLB();
        PopulatDGVEvents(customEvents);
    }

    private void devicesCLB_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Checked)
        {
            Device currentDevice = currentDevices.FirstOrDefault(d => d.serialNumber == devicesCLB.Items[e.Index].ToString());

            selectedDevices.Add(currentDevice);
        }
        else if (e.NewValue == CheckState.Unchecked)
        {
            Device currentDevice = currentDevices.FirstOrDefault(d => d.serialNumber == devicesCLB.Items[e.Index].ToString());

            selectedDevices.Remove(currentDevice);
        }
        PopulatDGVEvents(customEvents);
    }

    private void uncheckAllDevicesButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < devicesCLB.Items.Count; i++)
        {
            devicesCLB.SetItemChecked(i, false);
        }
        PopulatDGVEvents(customEvents);
    }

    private void checkAllDevicesButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < devicesCLB.Items.Count; i++)
        {
            devicesCLB.SetItemChecked(i, true);
        }
        PopulatDGVEvents(customEvents);
    }

    private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            // Set filter options and filter index.
            Title = "Select a folder",
            Filter = "Event Log Files (*.evtx)|*.evtx|All Files (*.*)|*.*",
            FilterIndex = 1,
            Multiselect = false,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        };

        // Show the dialog and get result.
        DialogResult result = openFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            // Get the selected file's path.
            string filePath = openFileDialog.FileName;
            defaultFilePath = filePath;
            selectedFolderPath = System.IO.Path.GetDirectoryName(filePath);
        }
        else
        {
            return;
        }

        //ListDirectory(dirTreeView, selectedFolderPath);
        ListAllDirectories(dirTreeView, filesOfInterest);
        InitializeDGVEvents();
        InitializeDevicesCLB();
        InitializeTimeControl();
    }

    private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConfigureColumns configureColumns = new(dgvEvents);
        configureColumns.Show();
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ExportPage export = new(dgvEvents);
        export.Show();
    }

    private void newFilterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FilterWindow filterWindow = new(dgvEvents, filter);
        filterWindow.Show();
    }

    private void clearFilterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        PopulatDGVEvents(customEvents);
    }

    private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        EventPropertiesPage eventPropertiesPage = new(dgvEvents, customEvents, dgvEvents.SelectedRows[0].Index);
        eventPropertiesPage.Show();
    }

    private void logPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (var file in filesOfInterest)
        {
            LogPropertiesWindow logPropertiesWindow = new(file);
            logPropertiesWindow.Show();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void resetSearchButton_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvEvents.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = Color.White;
            }
        }
    }
}
