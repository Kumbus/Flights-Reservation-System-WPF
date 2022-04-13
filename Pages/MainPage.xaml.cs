using System.Windows.Controls;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = MainPageViewModel.GetInstanceMainPageViewModel();
        }
    }
}
