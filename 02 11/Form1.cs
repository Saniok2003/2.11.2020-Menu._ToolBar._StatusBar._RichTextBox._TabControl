using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;


namespace _02_11
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void dublicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("test0.txt");
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            StreamWriter sd = new StreamWriter("test1.txt");
            sd.WriteLine(richTextBox2.Text);
            sd.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                OpenFileDialog openFile1 = new OpenFileDialog();
                if (openFile1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(openFile1.FileName);
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                OpenFileDialog openFile2 = new OpenFileDialog();
                if (openFile2.ShowDialog() == DialogResult.OK)
                {
                    richTextBox2.Text = File.ReadAllText(openFile2.FileName);
                }
            }

        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                SaveFileDialog saveDialog1 = new SaveFileDialog();
                saveDialog1.DefaultExt = ".txt";
                saveDialog1.Filter = "Text File|*.txt|PDF file|*.pdf|Word File|*.doc";
                DialogResult dr = saveDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    File.WriteAllText(saveDialog1.FileName, richTextBox1.Text);
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                SaveFileDialog saveDialog1 = new SaveFileDialog();
                saveDialog1.DefaultExt = ".txt";
                saveDialog1.Filter = "Text File|*.txt|PDF file|*.pdf|Word File|*.doc";
                DialogResult dr = saveDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    File.WriteAllText(saveDialog1.FileName, richTextBox2.Text);
                }
            }

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.SelectedText);
        }
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }
        private void pastleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectionIndex = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(selectionIndex, Clipboard.GetText());
            richTextBox1.SelectionStart = selectionIndex + Clipboard.GetText().Length;
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pastleToolStripMenuItem_Click(sender, e);
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem1_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.SelectedText.Length;
            richTextBox1.DeselectAll();
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Count of characters: {richTextBox1.TextLength.ToString()}";
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Count of characters: {richTextBox2.TextLength.ToString()}";
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                toolStripStatusLabel1.Text = $"Count of characters: {richTextBox1.TextLength.ToString()}";
            }
            if (tabControl1.SelectedIndex == 1)
            {
                toolStripStatusLabel1.Text = $"Count of characters: {richTextBox2.TextLength.ToString()}";
            }
        }
    }
}
