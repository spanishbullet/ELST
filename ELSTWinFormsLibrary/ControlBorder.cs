using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class ControlBorder
{
    public static void DrawHighlight(Control control, Color borderColor, int borderWidth)
    {
        var graphics = control.CreateGraphics();
        using (Pen pen = new Pen(borderColor, borderWidth))
        {
            var rect = new Rectangle(0, 0, control.Width - 1, control.Height - 1);
            graphics.DrawRectangle(pen, rect);
        }
    }
}

