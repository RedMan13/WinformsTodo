using System.Linq;
using static System.Windows.Forms.ListView;

namespace WinformsTodo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnClear_Click(new object(), new EventArgs());
        }

        TodoTask editing = new TodoTask(string.Empty, DateTime.Now);
        private void btnClear_Click(object sender, EventArgs e)
        {
            editing = new TodoTask(string.Empty, DateTime.Now);
            txtTitle.Text = editing.title;
            txtDate.Text = editing.due.Year.ToString().PadLeft(4, '0') + '-' + editing.due.Month.ToString().PadLeft(2, '0') + '-' + editing.due.Day.ToString().PadLeft(2, '0');
        }

        private Dictionary<int, TodoTask> todos = new Dictionary<int, TodoTask>();
        private void reflowListView()
        {
            lvTasks.Items.Clear();
            foreach (var taskItem in todos)
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
                else if (taskItem.Value.due < DateTime.Now)
                {
                    item.ToolTipText = "Missed";
                    item.BackColor = Color.LightCoral;
                }
                lvTasks.Items.Add(item);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] time = txtDate.Text.Split('-');
            if (time.Length != 3)
            {
                MessageBox.Show("The date " + txtDate.Text + " isnt a valid date time!!", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int year = int.Parse(time[0]);
            int month = int.Parse(time[1]);
            int day = int.Parse(time[2]);

            TodoTask task = new TodoTask(txtTitle.Text, new DateTime(year, month, day));
            todos.Add(task.id, task);
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
            e.Item.ToolTipText = e.Item.Checked ? "Complete" : "";
            e.Item.Font = new Font(e.Item.Font, e.Item.Checked ? FontStyle.Strikeout : FontStyle.Regular);
        }
    }
}
