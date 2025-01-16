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

        public TodoTask(string title, DateTime due, bool complete)
        {
            this.id = ids++;
            this.title = title;
            this.due = due;
            this.complete = complete;
        }
    }
}
