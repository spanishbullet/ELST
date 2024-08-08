using ELSTLibrary;
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
        MessageBox.Show("This prototype software is aimed to show event logs in a readable format that allows the user to see different events side by side and in context.");
    }

    private void infoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Tool not yet funcitonal.");
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
}
