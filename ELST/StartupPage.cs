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
    public partial class StartupPage : Form
    {
        public bool cancel;
        private string drive;
        private List<string> filesOfInterest = new List<string>();


        public StartupPage()
        {
            InitializeComponent();
            cancel = false;
        }

        private async void searchButtonDriveSearch_Click(object sender, EventArgs e)
        {
            filesOfInterest.Clear();
            SearchingWindow searchingWindow = new SearchingWindow();
            searchingWindow.Show();

            try
            {
                var progress = new Progress<int>(percent =>
                {
                    searchingWindow.UpdateProgress(percent);
                });

                // Run the search operation asynchronously
                filesOfInterest = await Task.Run(() => Startup.Search(drive, "Microsoft-Windows-Partition%4Diagnostic.evtx", progress));

                if (filesOfInterest.Count > 0)
                {
                    foundFilesLabelDriveSearch.Text = $"{filesOfInterest.Count} files of interest found:";
                    foreach (string file in filesOfInterest)
                    {
                        foundFilesTV.Nodes.Add(file);
                    }
                }
                else
                {
                    MessageBox.Show("No files found. Please use Manual Selection.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
            finally
            {
                searchingWindow.Close();
            }

            MessageBox.Show("Search Completed");
        }



        private void selectDriveButtonDriveSearch_Click(object sender, EventArgs e)
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
                    drive = folderBrowserDialog.SelectedPath;
                    drivePathLabelDriveSearh.Text = drive;
                }
                else
                {
                    return;
                }
            }
        }

        private void openFileButtonDriveSearch_Click(object sender, EventArgs e)
        {
            string filePath = foundFilesTV.SelectedNode.Text;
            string folderPath = "";
            MainMenu mainMenu = new MainMenu(filePath, filesOfInterest);
            mainMenu.Show();
        }

        private void openFileButtonManual_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

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
                MainMenu mainMenu = new MainMenu(filePath, filesOfInterest);
                mainMenu.Show();
            }
        }
    }
}
