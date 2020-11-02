using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public class Redactor
    {
        private string _path;

        private bool SelectFile(OpenFileDialog dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _path = dialog.FileName;
                return true;
            }

            return false;
        }

        public void NewFile(RichTextBox textBox)
        {
            textBox.Text = "";
            _path = "";
        }

        public void OpenFile(RichTextBox textBox)
        {
            var selectFile = new OpenFileDialog();
            if (SelectFile(selectFile))
            {
                textBox.Text = File.ReadAllText(_path);
            }
        }

        public void SaveFile(RichTextBox textBox)
        {
            try
            {
                File.WriteAllText(_path, textBox.Text);
            }
            catch
            {
                //
            }
        }

        public void SaveAsFile(RichTextBox textBox)
        {
            var saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFile.FileName, true))
                {
                    writer.WriteLine(textBox.Text);
                    writer.Close();
                }
            }
        }
        
        public static void PrintFile()
        {
            var printDocument = new PrintDocument();
            var printDialog = new PrintDialog {Document = printDocument};
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }

        public void SetContextMenu(RichTextBox textBox)
        {
            var contextMenu = new ContextMenuStrip();
            var copyMenuItem = new ToolStripMenuItem("Copy");
            copyMenuItem.Click += (sender, e) => CopyText(textBox);
            var pasteMenuItem = new ToolStripMenuItem("Paste");
            pasteMenuItem.Click += (sender, e) => PasteText(textBox);
            var cutMenuItem = new ToolStripMenuItem("Cut");
            cutMenuItem.Click += (sender, e) => CutText(textBox);
            contextMenu.Items.AddRange(new ToolStripItem[] {copyMenuItem, pasteMenuItem, cutMenuItem});
            textBox.ContextMenuStrip = contextMenu;
        }

        public static void CopyText(TextBoxBase textBox) => Clipboard.SetText(textBox.SelectedText);

        public static void PasteText(TextBoxBase textBox) => textBox.Paste();

        public static void CutText(TextBoxBase textBox) => textBox.Cut();

        public static void SetFont(RichTextBox textBox, string value)
        {
            textBox.Font = new Font("Segoe UI", Convert.ToInt16(value), FontStyle.Bold);
        }

        public static void HelpMenu()
        {
            var dialog = new Form();
            var label = new Label {Text = @"HELP MEE PLSSS!"};
            dialog.Controls.Add(label);
            dialog.ShowDialog();
        }

        public void PickColor(RichTextBox richBox)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richBox.SelectionColor = colorDialog.Color;
            }
            
        }
    }
}