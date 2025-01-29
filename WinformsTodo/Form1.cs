using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.ListBox;

namespace WinformsTodo
{

    public partial class Form1 : Form
    {
        private static string SavePath = "./todos.csv";
        private Dictionary<int, TodoTask> todos = new Dictionary<int, TodoTask>();
        public Form1()
        {
            InitializeComponent();
            btnClear_Click(new object(), new EventArgs());
            if (!File.Exists(SavePath)) return;
            string[] lines = File.ReadAllLines(SavePath);
            foreach (string line in lines)
            {
                TodoTask task = TodoTask.FromCSV(line);
                todos.Add(task.id, task);
            }
            drawState();
        }

        TodoTask editing = new TodoTask(string.Empty, DateTime.Today);
        private void btnClear_Click(object sender, EventArgs e)
        {
            editing = new TodoTask(string.Empty, DateTime.Today);
            txtTitle.Text = editing.title;
            txtDate.Text = editing.DateTo();
        }
        private void saveState()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SavePath));
            StreamWriter writer;
            try { writer = new StreamWriter(SavePath); }
            catch
            {
                MessageBox.Show("Cant open the todos list file for saving", "File Write Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var taskEnt in todos) 
                writer.WriteLine(taskEnt.Value.ToCSV());
            writer.Close();
        }
        private void drawState()
        {
            lbTasks.Items.Clear();
            var tasks = (from entry in todos orderby entry.Value.due ascending select entry).Reverse().ToArray();
            for (int i = 0; i < tasks.Length; i++)
            {
                TodoTask task = tasks[i].Value;
                lbTasks.Items.Add(task);
                if (task.complete)
                    lbTasks.SetItemChecked(i, true);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty) return;

            editing.title = txtTitle.Text;
            if (!editing.DateFrom(txtDate.Text)) return;
            todos[editing.id] = editing;
            btnClear_Click(new object(), new EventArgs());
            drawState();
            saveState();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SelectedObjectCollection items = lbTasks.SelectedItems;
            for (int i = 0; i < items.Count; i++)
                todos.Remove((items[i] as TodoTask).id);
            drawState();
            saveState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbTasks.SelectedItems.Count <= 0) return;
            TodoTask toEdit = lbTasks.SelectedItem as TodoTask;
            lbTasks.SelectedItem = null;
            if (toEdit == null) return;
            editing = toEdit;
            btnClear_Click(new object(), new EventArgs());
        }

        private void lbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            TodoTask task = lbTasks.Items[e.Index] as TodoTask;
            task.complete = e.NewValue != 0;
            saveState();
        }
    }
}
