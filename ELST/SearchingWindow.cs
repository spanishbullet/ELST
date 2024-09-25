using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELST;

public partial class SearchingWindow : Form
{
    private CancellationTokenSource _cancellationTokenSource;

    public SearchingWindow(CancellationTokenSource cancellationTokenSource)
    {
        InitializeComponent();
        _cancellationTokenSource = cancellationTokenSource;
    }

    /*For use with Startup.Search w/ total directory count
     * 
     * public void UpdateProgress(int percent)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<int>(UpdateProgress), percent);
        }
        else
        {
            searchPB.Value = percent;
            progressLabel.Text = $"Progress: {percent}%";
        }
    }*/

    public void UpdateProgress(int numDirs)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<int>(UpdateProgress), numDirs);
        }
        else
        {
            numDirectoriesLB.Text = numDirs.ToString();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel(); // Signal cancellation
        this.Close();
    }
}
