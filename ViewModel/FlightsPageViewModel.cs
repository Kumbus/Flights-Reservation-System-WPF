using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt
{
    public class FlightsPageViewModel : BaseViewModel
    {
        public ObservableCollection<BasicFlight>? Flights { get; set; } 
        public FlightsPageViewModel()
        {
            Flights = FlightUse.Flights;
            GoToDetailsCommand = new RelayCommand(GoToDetails, CanGoToDetails);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region Przejście do szczegółów lotu
        public ICommand GoToDetailsCommand { get; set; }

        private void GoToDetails(object value)
        {
            FlightUse.Indeks = value as string;
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.FlightDetails;
            
        }

        private bool CanGoToDetails(object value)
        {
            return true;
        }

        #endregion

        #region Powrót do strony głównej
        public ICommand GoBackCommand { get; set; }

        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;

        }

        private bool CanGoBack(object value)
        {
            return true;
        }

        #endregion

    }
}
