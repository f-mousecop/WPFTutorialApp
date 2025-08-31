using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Messages { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            pnlMainGrid.MouseUp += new MouseButtonEventHandler(pnlMainGrid_MouseUp);
            lblDate.Content = DateTime.Now.ToString();

            Messages = new ObservableCollection<string>();
            DataContext = this;
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            string me = "Me: ";
            
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Text.Contains(txtName.Text))
            {
                //lstNames.Items.Add(txtName.Text);
                lstNames.AppendText(me + txtName.Text + "\n");

                txtName.Clear();
            }
        }


        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void BtnClickMe_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(this.FindResource("strWindow").ToString());
            lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
        }

        private void BtnExcTest_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
           
            }
            s.Trim();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Window ln = new Window
            //{
            //    Title = "Login",
            //    Width = 300,
            //    Height = 200
            //};
            //ln.Show();
            Window1 ln1 = new Window1();
            ln1.Show();
       
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                Messages.Add("You: " + userMessage);

                // TODO Call OpenAI API
                Messages.Add($"Bot: {userMessage}");
                UserInput.Clear();
                MessagesList.ScrollIntoView(Messages.Last());
            }
        }
    }
}