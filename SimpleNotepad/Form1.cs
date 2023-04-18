using System;
using System.IO;
using System.Windows.Forms;


namespace SimpleNotepad
{
    public partial class MainForm : Form
    {
        private string _currentFilePath;
        public MainForm()
        {
            InitializeComponent();
            // 初始化记事本程序
            _currentFilePath = string.Empty;
            txtEditor.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(_currentFilePath, txtEditor.Text);
                MessageBox.Show("文件保存成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentFilePath = openFileDialog.FileName;
                txtEditor.Text = File.ReadAllText(_currentFilePath);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.Text))
            {
                DialogResult result = MessageBox.Show("是否保存当前文件？", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            _currentFilePath = string.Empty;
            txtEditor.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.Text))
            {
                DialogResult result = MessageBox.Show("是否保存当前文件？", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
