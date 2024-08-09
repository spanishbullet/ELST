using ELSTWinFormsLibrary;
using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ELST;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        InitializeDGVEvents();
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

    private string selectedFolderPath;

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
            LoadEvtxFile(filePath);
            GetEvents(filePath);
        }
    }

    private void LoadEvtxFile(string evtxFilePath)
    {
        // Clear existing data
        dgvEvents.Rows.Clear();

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
                // Get the XML representation of the event
                string eventXml = eventRecord.ToXml();


                // Parse the XML to extract desired fields
                var capacity = XmlExtract.GetField(eventXml, "Capacity");
                var manufacturer = XmlExtract.GetField(eventXml, "Manufacturer");
                var model = XmlExtract.GetField(eventXml, "Model");
                var revision = XmlExtract.GetField(eventXml, "Revision");
                var serialNumber = XmlExtract.GetField(eventXml, "SerialNumber");
                var parentId = XmlExtract.GetField(eventXml, "ParentId");
                var vbr0 = XmlExtract.GetField(eventXml, "Vbr0");
                var extractedVbr0 = FormatVbr0.Extract(vbr0);

                // Add a row to the DataGridView
                //ORDER MATTERS*******************
                dgvEvents.Rows.Add(
                    eventRecord.Id,                          // Event ID
                    eventRecord.ProviderName,                // Provider Name
                    eventRecord.LevelDisplayName,            // Level
                    eventRecord.FormatDescription(),         // Message
                    eventRecord.RecordId,                    // Record Number
                    eventRecord.TimeCreated,                 // Time Created
                    capacity,                                // Capacity
                    manufacturer,                            // Manufacturer
                    model,                                   // Model
                    revision,                                // Revision
                    serialNumber,                            // Serial Number
                    parentId,                                // Parent ID
                    extractedVbr0                            // Extracted Data From Vbr0
                );

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

    public void GetEvents(string evtxFilePath)
    {
        List<CustomEvent> customEvents = new List<CustomEvent>();
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

            MessageBox.Show(customEvents.Count.ToString());
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Error: Unauthorized access. Please run the application as Administrator.");
        }
        catch (EventLogException e)
        {
            MessageBox.Show("Error reading the event log file: " + e.Message);
        }
        foreach (CustomEvent ce in customEvents)
        {
            string message = ce.recordNumber;
            MessageBox.Show(ce.Display());
        }
    }

    private void DisplayEvent(EventRecord eventRecord)
    {
        string eventDetails = $"Event ID: {eventRecord.Id}\n" +
                              $"Provider Name: {eventRecord.ProviderName}\n" +
                              $"Level: {eventRecord.LevelDisplayName}\n" +
                              $"Time Created: {eventRecord.TimeCreated}\n" +
                              $"Message: {eventRecord.FormatDescription()}\n" +
                              new string('-', 50) + "\n";

        // You can display the event details in a TextBox, ListBox, or any other control.
        // For simplicity, we are showing it in a MessageBox here.
        MessageBox.Show(eventDetails);
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
        //MessageBox.Show("Not yet functional");

        MessageBox.Show(Analyze.RecordNumber(dgvEvents, dgvExtract.ExtractColumnData(dgvEvents, "recordId")));
    }

    private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvEvents.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}
