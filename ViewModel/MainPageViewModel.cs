using System;
using System.Windows.Input;

namespace Projekt
{
    public class MainPageViewModel : BaseViewModel
    {

        private MainPageViewModel()
        {
            PlusButtonAdultsCommand = new RelayCommand(AddPassenger, CanAdd);
            PlusButtonChildrenCommand = new RelayCommand(AddChild, CanAdd);
            MinusButtonAdultsCommand = new RelayCommand(SubtractPassenger, CanSubtractAdult);
            MinusButtonChildrenCommand = new RelayCommand(SubtractChild, CanSubtractChild);
            ChangePlacesCommand = new RelayCommand(ChangePlaces, CanChangePlaces);
            SearchFlightsCommand = new RelayCommand(SearchFlights, CanSearchFlights);
        }

        private static MainPageViewModel? instance;

        public static MainPageViewModel GetInstanceMainPageViewModel()
        {
            if (instance == null)
            {
                instance = new MainPageViewModel();
            }
            return instance;
        }

        #region Data i kalendarz
        private DateTime calendarDate { get; set; } = DateTime.Now;

        public string CalendarDateString { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set
            {
                CalendarDateString = value.ToString("yyyy-MM-dd");
                //CalendarDateString = CalendarDateString.Substring(0, 10);
            }
        }
        #endregion

        #region Przyciski plusy i minusy z commmand
        public int PassengersNumber { get; set; } = 1;
        public int ChildrenNumber { get; set; } = 0;
        public ICommand PlusButtonAdultsCommand { get; set; }

        public bool CanAdd(object value)
        {
            return true;
        }
        public void AddPassenger(object value)
        {
            PassengersNumber++;
            SetPassengers();
        }

        public ICommand PlusButtonChildrenCommand { get; set; }

        public void AddChild(object value)
        {
            ChildrenNumber++;
            SetPassengers();
        }

        public ICommand MinusButtonAdultsCommand { get; set; }

        public bool CanSubtractAdult(object value)
        {
            if (PassengersNumber == 1)
                return false;
            else
                return true;
        }
        public void SubtractPassenger(object value)
        {
            PassengersNumber--;
            SetPassengers();
        }

        public ICommand MinusButtonChildrenCommand { get; set; }

        public bool CanSubtractChild(object value)
        {
            if (ChildrenNumber == 0)
                return false;
            else
                return true;
        }
        public void SubtractChild(object value)
        {
            ChildrenNumber--;
            SetPassengers();
        }

        public string Passengers { get; set; } = "Dorośli: 1";
        private void SetPassengers()
        {
            Passengers = "Dorośli: " + PassengersNumber + " Dzieci: " + ChildrenNumber;
            if (ChildrenNumber == 0)
                Passengers = "Dorośli: " + PassengersNumber;
      
        }
        #endregion

        #region Zamiana miejsc wylotu i przylotu
        public string SkadText { get; set; } = "";
        public string DokadText { get; set; } = "";

        public ICommand ChangePlacesCommand { get; set; }
        public void ChangePlaces(object value)
        {
            (DokadText, SkadText) = (SkadText, DokadText);
        }

        public bool CanChangePlaces(object value)
        { 
            return true; 
        }
        #endregion

        #region Szukanie

        public ICommand SearchFlightsCommand { get; set; }

        private void SearchFlights(object value)
        {
            BasicFlight flightToSearch = new BasicFlight(SkadText, DokadText, CalendarDateString, ChildrenNumber + PassengersNumber, PassengersNumber, ChildrenNumber);
            FlightUse flightUse = new FlightUse();
            flightUse.Search(flightToSearch);
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Flights;
        }

        private bool CanSearchFlights(object value)
        {
            return true;
        }

        #endregion


    }
}
