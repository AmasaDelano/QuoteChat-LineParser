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
                // Get the quotes
                var fileReader = new FileReader(openFileDialog.FileName);
                var quoteReader = new QuoteReader(fileReader);
                var quotes = quoteReader.GetAllQuotes();

                // Get the corresponding movie file
                string moviePath = openFileDialog.FileName.Replace(".srt", ".mp4");
                var moviePlayer = new MoviePlayer(moviePath, vlcControl);

                // Generate a button for each quote. Clicking on the button will play the quote.
                foreach (var quote in quotes)
                {
                    BuildQuoteButton(quote, moviePlayer);
                }
            }
        }

        private void BuildQuoteButton(Quote quote, MoviePlayer moviePlayer)
        {
            var quoteButton = new QuotePanel(new[] { quote.GetData() }, moviePlayer);

            quoteButtonPanel.Controls.Add(quoteButton);
        }
    }
}