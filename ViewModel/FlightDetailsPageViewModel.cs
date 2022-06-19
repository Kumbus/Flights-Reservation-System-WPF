using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Projekt
{
    public class FlightDetailsPageViewModel : BaseViewModel
    {
        public List<BasicFlight> FlightClasses { get; set; }

        public string Button4Visibility { get; set; }

        public string Description { get; set; }
        public BasicFlight Flight { get; set; }
        public FlightDetailsPageViewModel()
        {
            Flight = FlightUse.FindOne();
            SetVisibility();
            FlightClasses = Flight.GenerateDerived();
            Description = FlightClasses[0].Describe();
            ChangeDescriptionCommand = new RelayCommand(ChangeDescription, CanChangeDescription);
            GoToSeatChoiceCommand = new RelayCommand(GoToSeatChoice, CanGoToSeatChoice);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region Zmiana opisów klas lotów
        public ICommand ChangeDescriptionCommand { get; set; }

        private void ChangeDescription(object value)
        {
            Description = FlightClasses[Int32.Parse((string)value)].Describe();
        }
       
        private bool CanChangeDescription(object value)
        {
            return true;
        }
        #endregion

        #region Przejście do wyboru miejsc
        public ICommand GoToSeatChoiceCommand { get; set; }

        private void GoToSeatChoice(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            WindowViewModel.Flight = Flight;
            mainWindow.CurrentPage = ApplicationPage.SeatChoice;
        }

        private bool CanGoToSeatChoice(object value)
        {
            return true;
        }

        #endregion

        private void SetVisibility()
        {
            if (Flight.HowManyClasses() > 3)
                Button4Visibility = "Visible";
            else
                Button4Visibility = "Collapsed";
        }

        #region Powrót do lotów
        public ICommand GoBackCommand { get; set; }

        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Flights;

        }

        private bool CanGoBack(object value)
        {
            return true;
        }
        #endregion
    }
}
