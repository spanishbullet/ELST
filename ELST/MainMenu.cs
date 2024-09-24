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
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace ELST;

public partial class MainMenu : Form
{
    public MainMenu(string filePath)
    {
        Properties.Settings.Default.Reset();

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
        Properties.Settings.Default.Reset();

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

    private List<CustomEvent> hiddenEvents = new List<CustomEvent>();

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
        devicesTSSLabel.Text = $"Showing {currentDevices.Count} of {allDevices.Count} Devices";
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
        dgvEvents.SuspendLayout();
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
        dgvEvents.ResumeLayout();
        eventsTSSLabel.Text = $"Showing {dgvEvents.Rows.Count} of {customEvents.Count} Events";
    }

    private void InitializeDGVEvents()
    {
        dgvEvents.Columns.Clear();
        // Set up the DataGridView columns
        //ORDER MATTERS*******************
        dgvEvents.Columns.Add("TimeCreated", "Time Created");
        dgvEvents.Columns.Add("Manufacturer", "Manufacturer");
        dgvEvents.Columns.Add("Model", "Model");
        dgvEvents.Columns.Add("SerialNumber", "SCSI Serial Number");
        dgvEvents.Columns.Add("Action", "Action");
        dgvEvents.Columns.Add("Capacity", "Capacity");
        dgvEvents.Columns.Add("Computer", "Computer");
        dgvEvents.Columns.Add("EventId", "Event ID");
        dgvEvents.Columns.Add("ProviderName", "Provider Name");
        dgvEvents.Columns.Add("Level", "Level");
        dgvEvents.Columns.Add("Message", "Message");
        dgvEvents.Columns.Add("RecordId", "Record Number");
        dgvEvents.Columns.Add("Revision", "Revision");
        dgvEvents.Columns.Add("ParentID", "Parent ID");
        dgvEvents.Columns.Add("ProcessId", "Process ID");
        dgvEvents.Columns.Add("ThreadId", "Thread ID");
        dgvEvents.Columns.Add("Channel", "Channel");
        dgvEvents.Columns.Add("UserId", "User ID");
        dgvEvents.Columns.Add("Vbr0", "Vbr0");
        dgvEvents.Columns.Add("MachineName", "Machine Name");
        dgvEvents.Columns.Add("RegistryID", "RegistryID");
        dgvEvents.Columns.Add("DiskID", "Disk ID");

        //Hide Columns
        dgvEvents.Columns["EventId"].Visible = false;
        dgvEvents.Columns["Message"].Visible = false;
        dgvEvents.Columns["ProviderName"].Visible = false;
        dgvEvents.Columns["Level"].Visible = false;
        dgvEvents.Columns["Computer"].Visible = false;
        dgvEvents.Columns["RecordId"].Visible = false;
        dgvEvents.Columns["Revision"].Visible = false;
        dgvEvents.Columns["ParentID"].Visible = false;
        dgvEvents.Columns["ProcessId"].Visible = false;
        dgvEvents.Columns["ThreadId"].Visible = false;
        dgvEvents.Columns["Channel"].Visible = false;
        dgvEvents.Columns["UserId"].Visible = false;
        dgvEvents.Columns["Vbr0"].Visible = false;
        dgvEvents.Columns["MachineName"].Visible = false;
        dgvEvents.Columns["RegistryID"].Visible = false;
        dgvEvents.Columns["DiskID"].Visible = false;


        //neccesary for correct sorting/comparison by time
        dgvEvents.Columns["TimeCreated"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
        dgvEvents.Columns["TimeCreated"].ValueType = typeof(DateTime);



        // Adjust column widths
        dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                        Text = "Highlight"
                    };
                    highlightEvent.Click += (obj, ea) =>
                    {
                        foreach (DataGridViewRow row in dgvEvents.SelectedRows)
                        {
                            dgvEvents.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        }
                    };
                    ToolStripMenuItem removeHighlight = new()
                    {
                        Text = "Unhighlight"
                    };
                    removeHighlight.Click += (obj, ea) =>
                    {
                        foreach (DataGridViewRow row in dgvEvents.SelectedRows)
                        {
                            dgvEvents.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
                        }
                    };
                    ContextMenuStrip hiddenContextMenu = new();
                    ToolStripMenuItem hideEvent = new()
                    {
                        Text = "Hide"
                    };
                    hideEvent.Click += (obj, ea) =>
                    {
                        foreach (DataGridViewRow row in dgvEvents.SelectedRows)
                        {
                            hiddenEvents.Add(customEvents[rowIndex]);

                            dgvEvents.Rows.RemoveAt(row.Index);
                        }
                    };
                    ToolStripMenuItem showHiddenEvents = new()
                    {
                        Text = "Show Hidden"
                    };
                    showHiddenEvents.Click += (obj, ea) =>
                    {
                        hiddenEvents.Clear();
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
        if (selectedDevices.Count != currentDevices.Count)
        {
            MessageBox.Show("Must select all devices in current timeframe.");
        }
        else
        {
            if (hiddenEvents.Count > 0)
            {
                DialogResult result = MessageBox.Show("One or more events are hidden and could cause a false alarm or prevent anomoly detection.\nDo you want to show hidden events?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    hiddenEvents.Clear();
                    PopulatDGVEvents(customEvents);
                }
            }
            MessageBox.Show(Analyze.RecordNumber(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "recordId")));
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
        if (hiddenEvents.Count > 0)
        {
            DialogResult result = MessageBox.Show("One or more events are hidden and could cause a false alarm or prevent anomoly detection.\nDo you want to show hidden events?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                hiddenEvents.Clear();
                PopulatDGVEvents(customEvents);
            }
        }
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
        dgvEvents.Rows.Clear();
        dgvEvents.SuspendLayout();
        for (int i = 0; i < devicesCLB.Items.Count; i++)
        {
            devicesCLB.SetItemChecked(i, false);
        }
        //dgvEvents.ResumeLayout();
        PopulatDGVEvents(customEvents);
        dgvEvents.ResumeLayout();
    }

    private void checkAllDevicesButton_Click(object sender, EventArgs e)
    {
        dgvEvents.SuspendLayout();
        for (int i = 0; i < devicesCLB.Items.Count; i++)
        {
            devicesCLB.SetItemChecked(i, true);
        }
        PopulatDGVEvents(customEvents);
        dgvEvents.ResumeLayout();
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
        ConfigureColumns configureColumns = new(dgvEvents, columnsTSSLabel);
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

    private void MainMenu_Shown(object sender, EventArgs e)
    {
        if (Properties.Settings.Default.MainMenuFirstRun == true)
        {
            StartTutorial();
        }

        MessageBox.Show(Analyze.RecordNumber(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "recordId")));
        MessageBox.Show(Analyze.TimeChange(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "TimeCreated")));
    }

    private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StartTutorial();
    }

    private void StartTutorial()
    {
        TransparentPanel highlightPanel = new TransparentPanel();



        DialogResult result = MessageBox.Show("Welcome To the Event Log Story Teller Main Menu.\nAt Any point during the tutorial press \"Cancel\" to end and \"OK\" to continue.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            return;
        }

        highlightPanel.Size = dgvEvents.Size;
        highlightPanel.Location = dgvEvents.Location;
        this.splitContainer1.Panel2.Controls.Add(highlightPanel);
        highlightPanel.BringToFront();
        DialogResult result0 = MessageBox.Show("This section displays parsed information from each event in the log.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result0 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            this.splitContainer1.Panel2.Controls.Remove(highlightPanel);
            return;
        }
        this.splitContainer1.Panel2.Controls.Remove(highlightPanel);

        devicesCLB.BackColor = Color.Yellow;
        DialogResult result1 = MessageBox.Show("Devices\nThis section displays each of the unique serial numbers.\n " +
                                               "Check or uncheck the devices to show/hide all events associaded with " +
                                               "that sn.\nYou can click individual devices or use the \"Check All\" " +
                                               "or \"Uncheck All\" buttons.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result1 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            devicesCLB.BackColor = SystemColors.Control;
            return;
        }
        devicesCLB.BackColor = SystemColors.Control;

        dirTreeView.BackColor = Color.Yellow;
        DialogResult result2 = MessageBox.Show("Directory Tree\nThis section shows the parent folder of the log " +
                                               "file(s)", "Tutorial", MessageBoxButtons.OKCancel);
        if (result == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            dirTreeView.BackColor = SystemColors.Control;
            return;
        }
        dirTreeView.BackColor = SystemColors.Control;

        MainMenuStrip.BackColor = Color.Yellow;
        DialogResult result3 = MessageBox.Show("Menu Strip\nThe menu strip contains many helpful tools that allow you to" +
                                               " better analyze and export your findings.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result3 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            MainMenuStrip.BackColor = SystemColors.Control;
            return;
        }
        mainMenuStrip.BackColor = SystemColors.Control;

        fileToolStripMenuItem.ShowDropDown();
        openLogToolStripMenuItem.BackColor = Color.Yellow;
        logPropertiesToolStripMenuItem.BackColor = Color.Yellow;
        exportToolStripMenuItem.BackColor = Color.Yellow;
        exitToolStripMenuItem.BackColor = Color.Yellow;

        DialogResult result4 = MessageBox.Show("File\nHere you can view log properties, Export the parsed log and exit this page.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result4 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            openLogToolStripMenuItem.BackColor = SystemColors.Control;
            logPropertiesToolStripMenuItem.BackColor = SystemColors.Control;
            exportToolStripMenuItem.BackColor = SystemColors.Control;
            exitToolStripMenuItem.BackColor = SystemColors.Control;
            fileToolStripMenuItem.HideDropDown();
            return;
        }
        openLogToolStripMenuItem.BackColor = SystemColors.Control;
        logPropertiesToolStripMenuItem.BackColor = SystemColors.Control;
        exportToolStripMenuItem.BackColor = SystemColors.Control;
        exitToolStripMenuItem.BackColor = SystemColors.Control;
        fileToolStripMenuItem.HideDropDown();

        aboutToolStripMenuItem.ShowDropDown();
        infoToolStripMenuItem.BackColor = Color.Yellow;
        aboutToolStripMenuItem1.BackColor = Color.Yellow;
        tutorialToolStripMenuItem.BackColor = Color.Yellow;
        DialogResult result5 = MessageBox.Show("Help\nHere you can view more information about this application and view the tutorial again.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result5 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            infoToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem1.BackColor = SystemColors.Control;
            tutorialToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.HideDropDown();
            return;
        }
        infoToolStripMenuItem.BackColor = SystemColors.Control;
        aboutToolStripMenuItem1.BackColor = SystemColors.Control;
        tutorialToolStripMenuItem.BackColor = SystemColors.Control;
        aboutToolStripMenuItem.HideDropDown();

        analyzeToolStripMenuItem.ShowDropDown();
        recordNumbersToolStripMenuItem.BackColor = Color.Yellow;
        timeCToolStripMenuItem.BackColor = Color.Yellow;
        DialogResult result6 = MessageBox.Show("Analyze\nHere you can analyze Record Numbers and Times of events. This is automatically done when you open a log file.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result6 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            recordNumbersToolStripMenuItem.BackColor = SystemColors.Control;
            timeCToolStripMenuItem.BackColor = SystemColors.Control;
            analyzeToolStripMenuItem.HideDropDown();
            return;
        }
        recordNumbersToolStripMenuItem.BackColor = SystemColors.Control;
        timeCToolStripMenuItem.BackColor = SystemColors.Control;
        analyzeToolStripMenuItem.HideDropDown();

        resetToolStripMenuItem.ShowDropDown();
        resetCellsToolStripMenuItem1.BackColor = Color.Yellow;
        DialogResult result7 = MessageBox.Show("Reset\nHere you can reset any highlighting or other formatting to cells.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result7 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            resetCellsToolStripMenuItem1.BackColor = SystemColors.Control;
            resetToolStripMenuItem.HideDropDown();
            return;
        }
        resetCellsToolStripMenuItem1.BackColor = SystemColors.Control;
        resetToolStripMenuItem.HideDropDown();

        searchToolStripMenuItem.ShowDropDown();
        searchTSMI.BackColor = Color.Yellow;
        DialogResult result8 = MessageBox.Show("Use this control to search through all displayed data.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result8 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            searchTSMI.BackColor = SystemColors.Control;
            searchToolStripMenuItem.HideDropDown();
        }
        searchTSMI.BackColor = SystemColors.Control;
        searchToolStripMenuItem.HideDropDown();

        timeArrowLabel.BackColor = Color.Yellow;
        applyTimeframeButton.BackColor = Color.Yellow;
        resetTimefreameButtom.BackColor = Color.Yellow;
        DialogResult result9 = MessageBox.Show("Time Scope\nUse these controlls to time scpoe the events and devices displayed.\n" +
                                               "Pick a start and end time and then press \"Aplly\" to activate the filter and \"Reset\"" +
                                               "to remove the filter.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result9 == DialogResult.Cancel)
        {
            Properties.Settings.Default.MainMenuFirstRun = false;
            Properties.Settings.Default.Save();
            timeArrowLabel.BackColor = SystemColors.Control;
            applyTimeframeButton.BackColor = SystemColors.Control;
            resetTimefreameButtom.BackColor = SystemColors.Control;
        }
        timeArrowLabel.BackColor = SystemColors.Control;
        applyTimeframeButton.BackColor = SystemColors.Control;
        resetTimefreameButtom.BackColor = SystemColors.Control;

        DialogResult result10 = MessageBox.Show("End of Tutorial\nDo you want to see the tutorial again?", "Tutorial", MessageBoxButtons.YesNo);
        if (result10 == DialogResult.Yes)
        {
            StartTutorial();
        }
    }

    private void searchTSMI_Click(object sender, EventArgs e)
    {
        searchGB.Show();
    }
}
