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
        }

        public ICommand ChangeDescriptionCommand { get; set; }

        private void ChangeDescription(object value)
        {
            Description = FlightClasses[Int32.Parse((string)value)].Describe();
        }

        private bool CanChangeDescription(object value)
        {
            return true;
        }

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

        private void SetVisibility()
        {
            if (Flight.HowManyClasses() > 3)
                Button4Visibility = "Visible";
            else
                Button4Visibility = "Collapsed";
        }

    }
}
