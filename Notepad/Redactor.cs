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
            File.WriteAllText(_path, textBox.Text);
        }

        public void SaveAsFile(RichTextBox textBox)
        {
            var selectFile = new OpenFileDialog();
            if (SelectFile(selectFile))
            {
                SaveFile(textBox);
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

        public static void CopyText(TextBoxBase textBox)
        {
            try
            {
                Clipboard.SetText(textBox.SelectedText);
            }
            catch
            {
                //ignore
            }
        }

        public static void PasteText(TextBoxBase textBox)
        {
            textBox.Paste();
        }

        public static void CutText(TextBoxBase textBox)
        {
            textBox.Cut();
        }
    }
}