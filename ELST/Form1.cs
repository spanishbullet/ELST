using System;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace ELST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private string selectedFolderPath = "D:\\Windows\\System32\\winevt\\TraceFormat";

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
            var dirNode = new TreeNode(dirInfo.FullName);
            foreach (var dir in dirInfo.GetDirectories())
                dirNode.Nodes.Add(CreateDirectoryNode(dir));
            foreach (var file in dirInfo.GetFiles())
                dirNode.Nodes.Add(new TreeNode(file.Name));
            return dirNode;
        }

        private void DirTreeViewNode_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Perform actions based on the clicked node
            //MessageBox.Show("Double-clicked node: " + e.Node.Text);

            string selectedEvtxFilePath = selectedFolderPath + "\\" + e.Node.Text;
            MessageBox.Show(selectedEvtxFilePath);
        }


    }
}
