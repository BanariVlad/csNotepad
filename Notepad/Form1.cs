using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private Redactor TextRedactor = new Redactor();
        public Form1()
        {
            InitializeComponent();
            TextRedactor.SetContextMenu(richTextBox1);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) => TextRedactor.NewFile(richTextBox1);

        private void richTextBox1_TextChanged(object sender, EventArgs e) => TextRedactor.CountWords(richTextBox1, toolStripTextBox1);

        private void openToolStripMenuItem_Click(object sender, EventArgs e) => TextRedactor.OpenFile(richTextBox1);
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => TextRedactor.SaveFile(richTextBox1);

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => TextRedactor.SaveAsFile(richTextBox1);

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => Redactor.CutText(richTextBox1);

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => Redactor.CopyText(richTextBox1);

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => Redactor.PasteText(richTextBox1);

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) => Redactor.HelpMenu();

        private void printToolStripMenuItem_Click(object sender, EventArgs e) => Redactor.PrintFile();

        private void bToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        private void iToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Italic);

        private void rToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Font = new Font("Segoe UI", Convert.ToInt16(toolStripTextBox4.Text), FontStyle.Bold);
            }
            catch
            {
                //
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e) => TextRedactor.PickColor(richTextBox1);

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new Form{Size = new Size(100, 100), FormBorderStyle = FormBorderStyle.FixedToolWindow};
            var textBox = new TextBox{Size = new Size(100, 25)};
            var btn = new Button{Text = @"Find", Size = new Size(100, 30), Location = new Point(0, 30)};
            btn.Click += (send, evt) => Redactor.FindWord(richTextBox1, textBox.Text);
            form.Controls.Add(textBox);
            form.Controls.Add(btn);
            form.ShowDialog();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectionAlignment = HorizontalAlignment.Left;

        private void centerToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        private void rightToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
    }
}