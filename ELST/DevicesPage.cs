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

        List<Device> devices = new List<Device>();

        public DevicesPage(List<Device> deviceList)
        {
            devices = deviceList;
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
            foreach (Device device in devices)
            {
                devicesTV.Nodes.Add(device.serialNumber);
            }
            devicesTVSSTLabel.Text = $"{devices.Count} Devices:";
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

            Device currentDevice = devices.FirstOrDefault(d => d.serialNumber == e.Node.Text);

            dgvDevices.Rows.Add(currentDevice.GetAllAttributes().ToArray());

            foreach (CustomEvent ce in currentDevice.events)
            {
                dgvDeviceEvents.Rows.Add(ce.GetUniqueAttributes().ToArray());
            }
        }
    }
}
