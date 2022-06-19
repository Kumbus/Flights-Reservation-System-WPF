using System.Windows;

namespace Projekt
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = WindowViewModel.GetInstanceWindowViewModel();
        }


        private void Minimise(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; 
        }

        private void ChangeSize(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            WindowViewModel windowViewModel = WindowViewModel.GetInstanceWindowViewModel();
            windowViewModel.CreateCloseLog();
            Close();
        }



    }
}
