namespace WinformsTodo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Array todos;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtDate.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
