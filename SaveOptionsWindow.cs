using System.Windows;

namespace CopilotChatWPF
{
    public partial class SaveOptionsWindow : Window
    {
        public string SelectedOption { get; private set; } = "Keine";

        public SaveOptionsWindow()
        {
            InitializeComponent();
        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption = "JSON";
            this.Close();
        }

        private void btnCsv_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption = "CSV";
            this.Close();
        }

        private void btnBoth_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption = "Beide";
            this.Close();
        }

        private void btnNone_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption = "Keine";
            this.Close();
        }
    }
}