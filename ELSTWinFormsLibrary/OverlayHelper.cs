/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace ELSTWinFormsLibrary;

public class OverlayHelper
{
    private Form form;
    private Panel overlayPanel;
    private Label infoLabel;

    public OverlayHelper(Form form)
    {
        this.form = form;
        InitializeOverlay();
    }

    private void InitializeOverlay()
    {
        overlayPanel = new Panel
        {
            BackColor = Color.FromArgb(128, 0, 0, 0), // Semi-transparent black
            Dock = DockStyle.Fill,
            Visible = false
        };

        infoLabel = new Label
        {
            AutoSize = true,
            BackColor = Color.White,
            Padding = new Padding(5),
            BorderStyle = BorderStyle.FixedSingle
        };

        form.Controls.Add(overlayPanel);
        overlayPanel.Controls.Add(infoLabel);
        infoLabel.BringToFront();

        overlayPanel.Click += (sender, e) => form.OnOverlayClicked();
    }

    public void HighlightControl(Control control, string message)
    {
        var controlLocation = control.PointToScreen(Point.Empty);
        var formLocation = form.PointToScreen(Point.Empty);

        var relativeLocation = new Point(
            controlLocation.X - formLocation.X,
            controlLocation.Y - formLocation.Y
        );

        infoLabel.Text = message;
        infoLabel.Location = new Point(relativeLocation.X + control.Width + 10, relativeLocation.Y);

        // Create a border around the control
        ControlBorder controlBorder = new ControlBorder(control, Color.Yellow);
        controlBorder.ShowBorder();

        overlayPanel.Visible = true;
        overlayPanel.BringToFront();
    }

    public void HideOverlay()
    {
        overlayPanel.Visible = false;
    }
}
*/