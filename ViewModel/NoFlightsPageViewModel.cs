using System.Windows.Input;

namespace Projekt
{
    public class NoFlightsPageViewModel : BaseViewModel
    {

        public NoFlightsPageViewModel()
        {
            GoToSearchPageCommand = new RelayCommand(GoToSearchPage, CanGoToSearchPage);
        }

        #region Wróć so strony głównej
        public ICommand GoToSearchPageCommand { get; set; }

        private void GoToSearchPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }

        private bool CanGoToSearchPage(object value)
        {
            return true;
        }

        #endregion
    }
}
