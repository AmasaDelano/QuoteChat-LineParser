using System;
using System.Windows.Forms;

namespace QuoteChatLineParser
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                AddExtension = true,
                Multiselect = false,
                Filter = "SRT Files (*.srt)|*.srt"
            };

            var dialogResponse = openFileDialog.ShowDialog();

            if (dialogResponse == DialogResult.OK)
            {
                // TODO: Read contents from file.
                // TODO: Do something with contents from file.
            }
        }
    }
}
