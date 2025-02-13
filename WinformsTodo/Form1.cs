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
        public Form1()
        {
            InitializeComponent();
            btnClear_Click(new object(), new EventArgs());
            if (!File.Exists(SavePath)) return;
            string[] lines = File.ReadAllLines(SavePath);
            foreach (string line in lines)
            {
                TodoTask task = TodoTask.FromCSV(line);
                flpTodos.Controls.Add(task);
            }
        }

        TodoTask editing = new TodoTask(string.Empty, DateTime.Today);
        private void btnClear_Click(object sender, EventArgs e)
        {
            loadEditing(new TodoTask(string.Empty, DateTime.Today));
        }
        void loadEditing(TodoTask toEdit = null)
        {
            if (toEdit != null) editing = toEdit;
            txtTitle.Text = editing.Title;
            txtTitle.Focus();
            txtDate.Text = editing.DateTo();
        }
        public void saveState()
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
            foreach (var taskEnt in flpTodos.Controls)
                writer.WriteLine((taskEnt as TodoTask).ToCSV());
            writer.Close();
        }
        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnAdd_Click(sender, e);
        }
        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnAdd_Click(sender, e);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty) return;

            if (!editing.DateFrom(txtDate.Text)) return;
            editing.Title = txtTitle.Text;
            if (editing.Parent == null)
                flpTodos.Controls.Add(editing);
            btnClear_Click(new object(), new EventArgs());
            saveState();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < flpTodos.Controls.Count; i++) {
                TodoTask task = flpTodos.Controls[i] as TodoTask;
                if (task.Selected)
                {
                    task.Dispose();
                    i--;
                }
            }
            saveState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TodoTask toEdit = null;
            foreach (var taskEnt in flpTodos.Controls)
                if ((taskEnt as TodoTask).Selected)
                {
                    toEdit = taskEnt as TodoTask;
                    break;
                }
            if (toEdit == null) return;
            toEdit.Selected = false;
            loadEditing(toEdit);
        }

        private void btnClearTasks_Click(object sender, EventArgs e)
        {
            flpTodos.Controls.Clear();
            saveState();
        }
    }
}
