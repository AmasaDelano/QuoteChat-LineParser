using System;
using System.Linq;
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
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                AddExtension = true,
                Multiselect = false,
                Filter = "SRT Files (*.srt)|*.srt"
            };

            var dialogResponse = openFileDialog.ShowDialog();
            
            if (dialogResponse == DialogResult.OK)
            {
                // Read contents from file.
                var fileReader = new FileReader(openFileDialog.FileName);
                var quoteReader = new QuoteReader(fileReader);

                // Display the contents of the file
                resultsTextBox.Text = string.Join(
                    Environment.NewLine + Environment.NewLine,
                    quoteReader.GetAllQuotes());
            }
        }
    }
}
