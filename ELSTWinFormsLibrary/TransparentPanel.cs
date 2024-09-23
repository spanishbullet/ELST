using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ELSTWinFormsLibrary;

public class TransparentPanel : Panel
{
    public TransparentPanel()
    {
        // Allow transparency in this control.
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;  // This ensures we don't draw a solid color background.
    }

    // Override OnPaint to handle custom painting
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);  // Ensure the base painting is done

        // Create a semi-transparent color with alpha blending
        Color semiTransparentColor = Color.FromArgb(100, 255, 255, 0);  // 100 alpha for partial transparency, black color

        // Create a solid brush with the semi-transparent color
        using (SolidBrush brush = new SolidBrush(semiTransparentColor))
        {
            // Fill the panel with the semi-transparent color
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Optionally, add other custom drawings here if needed.
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Prevent the default background painting to keep transparency
    }
}

