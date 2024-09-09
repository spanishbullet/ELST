using ELSTWinFormsLibrary;
using NPOI.SS.Formula.Functions;
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

public partial class StartupPage : Form
{
    public bool cancel;
    private string drive;
    private List<string> filesOfInterest = new List<string>();
    private List<string> selectedFilesOfInterest = new List<string>();


    public StartupPage()
    {
        InitializeComponent();
        cancel = false;
    }

    private CancellationTokenSource _cancellationTokenSource;

    private void searchButtonDriveSearch_Click(object sender, EventArgs e)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;

        SearchingWindow searchingWindow = new SearchingWindow(_cancellationTokenSource);
        searchingWindow.Show();

        var progress = new Progress<int>(percent => searchingWindow.UpdateProgress(percent));

        Task.Run(() =>
        {
            try
            {
                filesOfInterest.AddRange(Startup.Search(drive, "Microsoft-Windows-Partition%4Diagnostic.evtx", progress, cancellationToken));
                if (filesOfInterest.Count > 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        foundFilesLabel.Text = $"{filesOfInterest.Count} files of interest found:";
                        foreach (string file in filesOfInterest)
                        {
                            // Check if the node already exists
                            bool itemExists = false;

                            foreach (var item in foundFilesCLB.Items)
                            {
                                if (item.ToString().Equals(file, StringComparison.OrdinalIgnoreCase))
                                {
                                    itemExists = true;
                                    break;
                                }
                            }

                            // Add the node only if it does not exist
                            if (!itemExists)
                            {
                                foundFilesCLB.Items.Add(file);
                            }
                        }

                    }));
                    MessageBox.Show("Search Successful");
                }
                else
                {
                    MessageBox.Show("No files found. Please use Manual Selection.");
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Search canceled.");
            }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    searchingWindow.Close();
                }));
            }
        }, cancellationToken);
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
        if (foundFilesCLB.Items.Count != 0)
        {
            if (foundFilesCLB.CheckedItems.Count == 0)
            {
                foreach (var item in foundFilesCLB.Items)
                {
                    string filePath = item.ToString();
                    MainMenu mainMenu = new MainMenu(filePath);
                    mainMenu.Show();
                }
            }
            else
            {
                foreach (var item in foundFilesCLB.CheckedItems)
                {
                    string filePath = item.ToString();
                    MainMenu mainMenu = new MainMenu(filePath);
                    mainMenu.Show();
                }
            }
        }
        else
        {
            MessageBox.Show("No files found. \nSearch again or open file manually.");
        }

    }

    private void openTogetherButtonDriveSearch_Click(object sender, EventArgs e)
    {
        if (foundFilesCLB.Items.Count != 0)
        {
            if (foundFilesCLB.CheckedItems.Count == 0)
            {
                MainMenu mainMenu = new MainMenu(filesOfInterest);
                mainMenu.Show();
            }
            else
            {
                selectedFilesOfInterest.Clear();
                foreach (var item in foundFilesCLB.CheckedItems)
                {
                    selectedFilesOfInterest.Add(item.ToString());
                }
                MainMenu mainMenu = new MainMenu(selectedFilesOfInterest);
                mainMenu.Show();
            }
        }
        else
        {
            MessageBox.Show("No files found. \nSearch again or open file manually.");
        }
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
            MainMenu mainMenu = new MainMenu(filePath);
            mainMenu.Show();
        }
    }

    private void foundFilesCLB_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        // Prevent recursive handling by checking if the item is already being checked
        if (e.CurrentValue == e.NewValue)
            return;

        // Set the new value based on the current state
        e.NewValue = e.CurrentValue == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
    }

    private void helpButton_Click(object sender, EventArgs e)
    {
        string helpMessage = "Drive Search:\n" +
                             " - Click the \"Select Drive\" button to launch a folder dialog.\n" +
                             " - Select the drive/directory you want to search.\n" +
                             " - Select the file or files you would like to open from the checked box.\n" +
                             " - Click the \"Open File(s)\" button to open each selected file in it's own window.\n" +
                             " - Click the \"Open Together\" button to open each selected file in the same window.\n" +
                             " - If no files are selected it will open all found files according to the button you click.\n" +
                             "Open Manually:" +
                             " - Click the \"Open File\" button to launch a folder dialog.\n" +
                             " - Select the drive/directory you want to search and it will open in it's own window.\n";
        MessageBox.Show(helpMessage);
    }

    private void clearItemsButton_Click(object sender, EventArgs e)
    {
        filesOfInterest.Clear();
        selectedFilesOfInterest.Clear();
        foundFilesCLB.Items.Clear();
        foundFilesLabel.Text = $"{filesOfInterest.Count} files of interest found:";
    }
}
