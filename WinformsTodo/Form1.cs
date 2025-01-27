using System.IO;
using System.Linq;
using static System.Windows.Forms.ListView;

namespace WinformsTodo
{

    public partial class Form1 : Form
    {
        private static string SavePath = "./todos.csv";
        private Dictionary<int, TodoTask> todos = new Dictionary<int, TodoTask>();
        public Form1()
        {
            InitializeComponent();
            this.btnClear_Click(new object(), new EventArgs());
            if (!File.Exists(SavePath)) return;
            string[] lines = File.ReadAllLines(SavePath);
            foreach (string line in lines)
            {
                TodoTask task = TodoTask.FromCSV(line);
                todos.Add(task.id, task);
            }
            reflowListView();
        }

        TodoTask editing = new TodoTask(string.Empty, DateTime.Today);
        private void btnClear_Click(object sender, EventArgs e)
        {
            editing = new TodoTask(string.Empty, DateTime.Today);
            txtTitle.Text = editing.title;
            txtDate.Text = editing.DateTo();
        }

        private void reflowListView()
        {
            lvTasks.Items.Clear();
            Directory.CreateDirectory(Path.GetDirectoryName(SavePath));
            StreamWriter writer = new StreamWriter(SavePath);
            foreach (var taskItem in (from entry in todos orderby entry.Value.due ascending select entry).Reverse())
            {
                ListViewItem item = new ListViewItem();
                item.Checked = taskItem.Value.complete;
                item.Text = taskItem.Value.ToString();
                item.Tag = taskItem.Value.id;
                if (taskItem.Value.complete)
                {
                    item.ToolTipText = "Complete";
                    item.Font = new Font(item.Font, FontStyle.Strikeout);
                }
                else if (taskItem.Value.due < DateTime.Today)
                {
                    item.ToolTipText = "Missed";
                    item.BackColor = Color.LightCoral;
                }
                lvTasks.Items.Add(item);
                writer.WriteLine(taskItem.Value.ToCSV());
            }
            writer.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty) return;

            editing.title = txtTitle.Text;
            editing.DateFrom(txtDate.Text);
            todos[editing.id] = editing;
            this.btnClear_Click(new object(), new EventArgs());
            reflowListView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection items = lvTasks.SelectedItems;
            for (int i = 0; i < items.Count; i++)
            {
                int id = (int)(items[i].Tag);
                todos.Remove(id);
            }
            reflowListView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count <= 0) return;
            int id = (int)(lvTasks.SelectedItems[0].Tag);
            for (int i = 1; i < lvTasks.SelectedItems.Count; i++)
                lvTasks.SelectedItems[i].Selected = false;
            TodoTask toEdit = todos[id];
            if (toEdit == null) return;
            editing = toEdit;
            txtTitle.Text = editing.title;
            txtDate.Text = editing.due.Year.ToString().PadLeft(4, '0') + '-' + editing.due.Month.ToString().PadLeft(2, '0') + '-' + editing.due.Day.ToString().PadLeft(2, '0');
        }

        private void lvTasks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int id = (int)(e.Item.Tag);
            TodoTask task = todos[id];
            task.complete = e.Item.Checked;
            if (e.Item.Checked)
            {
                e.Item.ToolTipText = "Complete";
                e.Item.Font = new Font(e.Item.Font, FontStyle.Strikeout);
                e.Item.BackColor = Color.White;
            } else
            {
                e.Item.ToolTipText = "Complete";
                e.Item.Font = new Font(e.Item.Font, FontStyle.Regular);
                if (task.due < DateTime.Today)
                    e.Item.BackColor = Color.LightCoral;
            }
        }
    }
}
