using ELSTWinFormsLibrary;

namespace ELST;

public partial class StartupPage : Form
{
    public bool cancel;
    private string drive;
    private List<string> filesOfInterest = new List<string>();
    private List<string> selectedFilesOfInterest = new List<string>();
    //private TutorialManager tutorialManager;

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

        int newFileCount = 0;
        Task.Run(() =>
        {
            try
            {
                List<string> files = Startup.Search(drive, "Microsoft-Windows-Partition%4Diagnostic.evtx", progress, cancellationToken);
                foreach (string file in files)
                {
                    if (!filesOfInterest.Contains(file))
                    {
                        filesOfInterest.Add(file);
                        newFileCount++;
                    }
                }

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

                    if (newFileCount > 0)
                    {
                        MessageBox.Show($"Search Complete. \n{newFileCount} new files found.");
                    }
                    else
                    {
                        MessageBox.Show("Search Complete.\nNo new files found.");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Handle the cancellation case
                this.Invoke(new Action(() =>
                {
                    if (newFileCount > 0)
                    {
                        MessageBox.Show($"Search Canceled. \n{newFileCount} new files found before cancellation.");
                    }
                    else
                    {
                        MessageBox.Show("Search Canceled.\nNo new files found.");
                    }
                }));
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
            MessageBox.Show("No files found. \nSearch again or add file manually.");
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
            MessageBox.Show("No files found. \nSearch again or add file manually.");
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

            if (!filesOfInterest.Contains(filePath))
            {
                filesOfInterest.Add(filePath);
                foundFilesLabel.Text = $"{filesOfInterest.Count} files of interest found:";
                foundFilesCLB.Items.Add(filePath);
            }
            else
            {
                MessageBox.Show("File already present");
            }
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
        DialogResult result = MessageBox.Show(helpMessage, "Press \"Yes\" to see tutorial again, Press \"No\" to close this window.", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            StartTutorial();
        }
    }

    private void foundFilesCLB_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void removeAllButton_Click(object sender, EventArgs e)
    {
        filesOfInterest.Clear();
        selectedFilesOfInterest.Clear();
        foundFilesCLB.Items.Clear();
        foundFilesLabel.Text = $"{filesOfInterest.Count} files of interest found:";
    }

    private void removeSelectedButton_Click(object sender, EventArgs e)
    {
        // Create a list to hold the checked items
        var itemsToRemove = new List<object>();

        // Add the checked items to the new list
        foreach (var item in foundFilesCLB.CheckedItems)
        {
            itemsToRemove.Add(item);
        }

        // Remove items from the CheckedListBox and filesOfInterest
        foreach (var item in itemsToRemove)
        {
            filesOfInterest.Remove(item.ToString());
            foundFilesCLB.Items.Remove(item);
        }
        foundFilesLabel.Text = $"{filesOfInterest.Count} files of interest found:";
    }

    private void StartTutorial()
    {
        DialogResult result = MessageBox.Show("Welcome To the Event Log Story Teller Startup Menu.\nAt Any point during the tutorial press \"Cancel\" to end and \"OK\" to continue.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            return;
        }

        driveSearchGB.BackColor = Color.Yellow;
        DialogResult result0 = MessageBox.Show("Use these controlls to search a drive", "Tutorial", MessageBoxButtons.OKCancel);
        if (result0 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            driveSearchGB.BackColor = SystemColors.Control;
            return;
        }
        driveSearchGB.BackColor = SystemColors.Control;

        manualOpenGB.BackColor = Color.Yellow;
        DialogResult result1 = MessageBox.Show("Use these controlls to manually select a file", "Tutorial", MessageBoxButtons.OKCancel);
        if (result1 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            manualOpenGB.BackColor = SystemColors.Control;
            return;
        }
        manualOpenGB.BackColor = SystemColors.Control;

        foundFilesCLB.BackColor = Color.Yellow;
        DialogResult result2 = MessageBox.Show("Files found during a search and files selected manually will apear here with their full file path.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result2 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            foundFilesCLB.BackColor = SystemColors.Control;
            return;
        }
        foundFilesCLB.BackColor = SystemColors.Control;

        openFileButtonDriveSearch.BackColor = Color.Yellow;
        DialogResult result3 = MessageBox.Show("This button will open the selected file(s) in their own window.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result3 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            openFileButtonDriveSearch.BackColor = SystemColors.Control;
            return;
        }
        openFileButtonDriveSearch.BackColor = SystemColors.Control;

        openTogetherButtonDriveSearch.BackColor = Color.Yellow;
        DialogResult result4 = MessageBox.Show("This Button will open the selected files(s) in the same window.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result4 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            openTogetherButtonDriveSearch.BackColor = SystemColors.Control;
            return;
        }
        openTogetherButtonDriveSearch.BackColor = SystemColors.Control;

        removeSelectedButton.BackColor = Color.Yellow;
        removeAllButton.BackColor = Color.Yellow;
        DialogResult result5 = MessageBox.Show("Use these buttons to remove files from the files of interest box.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result5 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            removeAllButton.BackColor = SystemColors.Control;
            removeSelectedButton.BackColor = SystemColors.Control;
            return;
        }
        removeAllButton.BackColor = SystemColors.Control;
        removeSelectedButton.BackColor = SystemColors.Control;

        helpButton.BackColor = Color.Yellow;
        DialogResult result6 = MessageBox.Show("Use this button for more help or to see the tutorial again.", "Tutorial", MessageBoxButtons.OKCancel);
        if (result6 == DialogResult.Cancel)
        {
            Properties.Settings.Default.StartupFirstRun = false;
            Properties.Settings.Default.Save();
            helpButton.BackColor = SystemColors.Control;
            return;
        }
        helpButton.BackColor = SystemColors.Control;
    }

    private void StartupPage_Shown(object sender, EventArgs e)
    {
        if (Properties.Settings.Default.StartupFirstRun == true)
        {
            StartTutorial();
        }
    }
}
