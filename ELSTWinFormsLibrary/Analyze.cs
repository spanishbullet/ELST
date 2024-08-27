using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class Analyze
{
    public static string RecordNumber(DataGridView dgv, List<object> columnData)
    {
        /*foreach (DataGridViewRow row in dgv.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }*/
        string message = "";
        List<int> recordIds = columnData.ConvertAll(new Converter<object, int>(Convert.ToInt32));
        List<int> result = new List<int>();
        if (recordIds.Count > 0)
        {
            List<int> rows = new List<int>();
            var lastItem = recordIds[0];

            // Check if the first item is a discontinuity compared to the second item
            if (recordIds.Count > 1 && recordIds[1] != lastItem + 1)
            {
                message = "Possible anomalies at row(s):\n";
                message += 1 + "\n";
                rows.Add(lastItem);
            }

            for (int i = 1; i < recordIds.Count - 1; i++)
            {
                var currentItem = recordIds[i];
                var nextItem = recordIds[i + 1];

                // If the current item is not continuous with the last or next, add it to result
                if (currentItem != lastItem + 1 || nextItem != currentItem + 1)
                {
                    if (message.Length == 0)
                        message = "Possible anomalies at row(s):\n";
                    message += (i + 1) + "\n";
                    rows.Add(i);
                }

                lastItem = currentItem;
            }

            // Check if the last item is a discontinuity compared to the second last item
            if (recordIds.Count > 1 && recordIds[recordIds.Count - 1] != recordIds[recordIds.Count - 2] + 1)
            {
                if (message.Length == 0)
                    message += recordIds.Count;
                rows.Add(recordIds.Count - 1);
                message += recordIds.Count;
            }

            //highlight rows in dgv
            foreach (int row in rows)
            {
                dgv.Rows[row].DefaultCellStyle.BackColor = Color.Red;
            }

        }
        if (message.Length == 0)
            message = "No anomalies detected.";
        return message;
    }

    public static string TimeChange(DataGridView dgv, List<CustomEvent> customEvents)
    {
        string message = "";
        List<DateTime> times = new List<DateTime>();
        List<int> rows = new List<int>();

        foreach (CustomEvent customEvent in customEvents)
        {
            times.Add((DateTime)customEvent.TimeCreated);
        }

        DateTime lastItem = times[0];
        DateTime currentItem;

        for (int i = 1; i < times.Count; i++)
        {
            currentItem = times[i];
            if (currentItem <= lastItem)
            {
                if (message.Length == 0)
                    message = "Possible anomalies at row(s):\n";
                message += (i + 1) + "\n";
                rows.Add(i);
            }
            lastItem = currentItem;
        }

        //highlight rows in dgv
        foreach (int row in rows)
        {
            dgv.Rows[row].DefaultCellStyle.BackColor = Color.Purple;
        }

        if (message.Length == 0)
            message = "No anomalies detected";

        return message;
    }

    public static string TimeChange2(DataGridView dgv, List<object> columnData)
    {
        List<DateTime> times = columnData.ConvertAll(new Converter<object, DateTime>(Convert.ToDateTime));
        string message = "";
        List<int> result = new List<int>();
        if (columnData.Count > 0)
        {
            List<int> rows = new List<int>();
            DateTime lastItem = times[0];
            DateTime currentItem;

            for (int i = 1; i < times.Count; i++)
            {
                currentItem = times[i];
                if (currentItem <= lastItem)
                {
                    if (message.Length == 0)
                        message = "Possible anomalies at row(s):\n";
                    message += (i + 1) + "\n";
                    rows.Add(i);
                }
                lastItem = currentItem;
            }

            //highlight rows in dgv
            foreach (int row in rows)
            {
                dgv.Rows[row].DefaultCellStyle.BackColor = Color.MediumPurple;
            }

        }
        if (message.Length == 0)
            message = "No anomalies detected.";
        return message;
    }
}

