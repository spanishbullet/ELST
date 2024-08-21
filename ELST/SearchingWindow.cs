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
    public partial class SearchingWindow : Form
    {
        public SearchingWindow()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int percent)
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //cancel = true;
        }
    }
}
