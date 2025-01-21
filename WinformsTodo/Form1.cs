using static System.Windows.Forms.ListView;

namespace WinformsTodo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtDate.Text = string.Empty;
        }

        private readonly TodoTask[] todos;
        private void reflowListView()
        {
            lvTasks.Items.Clear();
            for (int i = 0; i < todos.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Checked = todos[i].complete;
                item.Text = todos[i].ToString();
                item.Tag = i;
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
            todos.Append(new TodoTask(txtTitle.Text, new DateTime(year, month, day)));
            reflowListView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection items = lvTasks.SelectedItems;
            int[] toRemove;
            for (int i = 0; i < lvTasks.SelectedItems.Count; i++) {
                items[i].Remove();
            }
        }
    }
}
