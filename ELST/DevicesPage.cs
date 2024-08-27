using ELSTWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELST
{
    public partial class DevicesPage : Form
    {
        private bool timeFrame = false;
        List<Device> selectedDevices = new List<Device>();
        List<Device> allDevices = new List<Device>();
        private TreeNode selectedNode;
        private Device selectedDevice;

        public DevicesPage(MainMenu mainMenu)
        {
            selectedDevices = mainMenu.selectedDevices;
            allDevices = mainMenu.allDevices;
            timeFrame = mainMenu.timeframe;

            InitializeComponent();
            InitializeDevicesTV();
            InitializeDGVDevices();
            InitializeDGVDeviceEvents();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InitializeDevicesTV()
        {
            devicesTV.Nodes.Clear();
            foreach (Device device in selectedDevices)
            {
                devicesTV.Nodes.Add(device.serialNumber);
            }
            devicesTVSSTLabel.Text = $"{selectedDevices.Count} Devices:";
        }

        public void InitializeDGVDevices()
        {
            dgvDevices.Columns.Add("SerialNumber", "Serial Number");
            dgvDevices.Columns.Add("Manufacturer", "Manufacturer");
            dgvDevices.Columns.Add("Model", "Model");
            dgvDevices.Columns.Add("FirstEvent", "First Event");
            dgvDevices.Columns.Add("LastEvent", "Last Event");
            dgvDevices.Columns.Add("Appearances", "Appearances");
            dgvDevices.Columns.Add("Revision", "Revision");
            dgvDevices.Columns.Add("ParentID", "Parent ID");
            dgvDevices.Columns.Add("Capacity", "Capacity");

            // Adjust column widths
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void InitializeDGVDeviceEvents()
        {
            dgvDeviceEvents.Columns.Add("EventId", "Event ID");
            dgvDeviceEvents.Columns.Add("ProviderName", "Provider Name");
            dgvDeviceEvents.Columns.Add("Level", "Level");
            dgvDeviceEvents.Columns.Add("Message", "Message");
            dgvDeviceEvents.Columns.Add("RecordId", "Record Number");
            dgvDeviceEvents.Columns.Add("TimeCreated", "Time Created");
            dgvDeviceEvents.Columns.Add("Action", "Action");
            dgvDeviceEvents.Columns.Add("Vbr0", "Vbr0");

            //Hide Columns
            dgvDeviceEvents.Columns["EventId"].Visible = false;
            dgvDeviceEvents.Columns["Message"].Visible = false;
            dgvDeviceEvents.Columns["ProviderName"].Visible = false;
            dgvDeviceEvents.Columns["Level"].Visible = false;

            // Adjust column widths
            dgvDeviceEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void devicesTV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            dgvDevices.Rows.Clear();
            dgvDeviceEvents.Rows.Clear();
            selectedNode = e.Node;

            Device currentDevice = selectedDevices.FirstOrDefault(d => d.serialNumber == e.Node.Text);
            selectedDevice = currentDevice;

            dgvDevices.Rows.Add(currentDevice.GetAllAttributes().ToArray());

            foreach (CustomEvent ce in currentDevice.events)
            {
                dgvDeviceEvents.Rows.Add(ce.GetUniqueAttributes().ToArray());
            }

            
        }

        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Device completeDevice = allDevices.FirstOrDefault(d => d.serialNumber == selectedNode.Text);

            if (selectedDevice.Equals(completeDevice))
            {
                MessageBox.Show($"No other events for {selectedDevice.serialNumber} outside current timeframe.");
            }
            else
            {
                MessageBox.Show($"{completeDevice.events.Count - selectedDevice.events.Count} events for {selectedDevice.serialNumber} outside current timeframe.");
            }
        }
    }
}
