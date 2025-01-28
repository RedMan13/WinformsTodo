using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsTodo
{
    public class TodoTask
    {
        public static int ids = 0;
        public int id { get; set; }
        public string title { get; set; }
        public DateTime due { get; set; }
        public bool complete { get; set; }

        public TodoTask(string title, DateTime due, bool complete = false) : base()
        {
            this.id = ids++;
            this.title = title;
            this.due = due;
            this.complete = complete;
        }
        override public string ToString()
        {
            return due.ToShortDateString() + " | " + title;
        }

        public bool DateFrom(string date)
        {
            string[] time = date.Split('-');
            if (time.Length != 3)
            {
                MessageBox.Show("The date " + date + " isnt a valid date time!!", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int year = int.Parse(time[0]);
            int month = int.Parse(time[1]);
            int day = int.Parse(time[2]);

            due = new DateTime(year, month, day);
            return true;
        }
        public string DateTo() { return due.Year.ToString().PadLeft(4, '0') + '-' + due.Month.ToString().PadLeft(2, '0') + '-' + due.Day.ToString().PadLeft(2, '0'); }

        static public TodoTask FromCSV(string csv)
        {
            string[] parts = csv.Split(',');
            TodoTask task = new TodoTask("Missing Title", DateTime.Now);
            if (parts.Length > 0)
                task.title = parts[0];
            if (parts.Length > 1)
                task.DateFrom(parts[1]);
            if (parts.Length > 2)
                task.complete = parts[2] == "true";
            return task;
        }
        public object ToCSV() {
            return title + ',' + DateTo() + ',' + complete;
        }
    }
}
