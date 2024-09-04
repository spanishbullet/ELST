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
        string message = "";
        List<int> recordIds = columnData.ConvertAll(new Converter<object, int>(Convert.ToInt32));
        List<int> rows = new List<int>();

        if (recordIds.Count > 0)
        {
            var lastItem = recordIds[0];

            for (int i = 0; i < recordIds.Count; i++)
            {
                var currentItem = recordIds[i];
                string anomalyType = "";

                // Check for duplicate numbers
                if (i > 0 && currentItem == lastItem)
                {
                    anomalyType = "Duplicate number";
                }

                // Check for missing numbers
                if (i > 0 && currentItem > lastItem + 1)
                {
                    anomalyType = "Missing number(s)";
                }

                // Check for numbers out of order
                if (i > 0 && currentItem < lastItem)
                {
                    anomalyType = "Numbers out of order";
                }

                if (!string.IsNullOrEmpty(anomalyType))
                {
                    if (message.Length == 0)
                    {
                        message = "Anomalies detected at row(s):\n";
                    }
                    message += $"{i + 1}: {anomalyType}\n";
                    rows.Add(i);
                }

                lastItem = currentItem;
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

