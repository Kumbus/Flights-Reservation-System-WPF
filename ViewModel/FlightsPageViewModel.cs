using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public ICommand GoToDetailsCommand { get; set; }

        private void GoToDetails(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.FlightDetails;
            FlightUse.Indeks = value as string;
        }

        private bool CanGoToDetails(object value)
        {
            return true;
        }



        
    }
}
