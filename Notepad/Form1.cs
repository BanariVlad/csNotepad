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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextRedactor.NewFile(richTextBox1);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextRedactor.OpenFile(richTextBox1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextRedactor.SaveFile(richTextBox1);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextRedactor.SaveAsFile(richTextBox1);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redactor.CutText(richTextBox1);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redactor.CopyText(richTextBox1);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redactor.PasteText(richTextBox1);
        }
    }
}