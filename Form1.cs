using System;
using System.IO;
using System.Windows.Forms;

namespace Assemblr
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {//Exit application
            if (MessageBox.Show("Are you sure you want to close Assemblr?",
                                "Assemblr",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }            
        }
        
        private void newToolStripButton_Click(object sender, EventArgs e)
        {//New file
            tabControl1.TabPages.Add("NewTab", "New file");
            RichTextBox richCodeEdit = new RichTextBox();
            richCodeEdit.Name = "richCodeEdit";
            richCodeEdit.Anchor = (
                                    AnchorStyles.Bottom | 
                                    AnchorStyles.Right  |
                                    AnchorStyles.Top    |
                                    AnchorStyles.Left
                                    );
            richCodeEdit.Dock = DockStyle.Fill;

            tabControl1.TabPages["NewTab"].Controls.Add(richCodeEdit);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {//New file
            newToolStripButton_Click(sender, e);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {//Open file

            Stream fileStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            RichTextBox richCodeEdit = new RichTextBox();
            string filePath = "";            
            
            richCodeEdit.Name = "richCodeEdit";
            richCodeEdit.Anchor = (
                                    AnchorStyles.Bottom |
                                    AnchorStyles.Right |
                                    AnchorStyles.Top |
                                    AnchorStyles.Left
                                    );
            richCodeEdit.Dock = DockStyle.Fill;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    richCodeEdit.Text = fileContent;
                }
                //Numele şi extensia fişierului deschis
                string fileName = Path.GetFileName(filePath);

                //Creează un tab nou, cu numele fişierului deschis
                tabControl1.TabPages.Add(fileName, fileName);
                tabControl1.TabPages[fileName].Controls.Add(richCodeEdit);                
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//Open file
            openToolStripButton_Click(sender, e);
        }       
    }
}
