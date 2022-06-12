using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AppointmentWPF2.Pages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var clickedBtn = e.OriginalSource as NavBar;
            NavigationService.Navigate(clickedBtn.NavUri);
        }
    }

}
