using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinformsTodo
{
    public partial class TodoTask : UserControl
    {
        public static int ids = 0;
        public int id { get; set; }
        private string title;
        public string Title
        {
            get => title;
            set { title = value; Reflow(); }
        }
        private DateTime due;
        public DateTime Due
        {
            get => due;
            set { due = value; Reflow(); }
        }
        public bool Complete
        {
            get => chkCompleted.Checked;
            set => chkCompleted.Checked = value;
        }
        public bool Selected = false;

        public TodoTask(string title, DateTime due, bool complete = false) : base()
        {
            this.id = ids++;
            InitializeComponent();
            this.title = title;
            this.due = due;
            this.Complete = complete;
            Reflow();
        }
        override public string ToString()
        {
            return due.ToShortDateString() + " | " + title;
        }

        public void Reflow() { lblTitle.Text = this.ToString(); }

        public bool DateFrom(string date)
        {
            string[] time = date.Split('-');
            if (time.Length != 3)
            {
                MessageBox.Show("Invalid date " + date + " for task " + title, "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int year = int.Parse(time[0]);
            int month = int.Parse(time[1]);
            int day = int.Parse(time[2]);

            Due = new DateTime(year, month, day);
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
                task.Complete = parts[2].ToLower() == "true";
            return task;
        }
        public object ToCSV()
        {
            return title + ',' + DateTo() + ',' + Complete;
        }

        private void TodoTask_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
            BackColor = Selected ? SystemColors.Highlight : SystemColors.Control;
            lblTitle.ForeColor = Selected ? SystemColors.ControlLightLight : SystemColors.ControlText;
        }

        private void lblTitle_Click(object sender, EventArgs e) { TodoTask_Click(sender, e); }
    }
}
