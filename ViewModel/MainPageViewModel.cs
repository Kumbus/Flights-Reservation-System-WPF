using System;
using System.Linq;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony początkowej, na któej wyszukuje się loty
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Konstruktor prywatny, żeby móc zastosować wzorzec singleton
        /// </summary>
        private MainPageViewModel()
        {
            PlusButtonAdultsCommand = new RelayCommand(AddPassenger, CanAdd);
            PlusButtonChildrenCommand = new RelayCommand(AddChild, CanAdd);
            MinusButtonAdultsCommand = new RelayCommand(SubtractPassenger, CanSubtractAdult);
            MinusButtonChildrenCommand = new RelayCommand(SubtractChild, CanSubtractChild);
            ChangePlacesCommand = new RelayCommand(ChangePlaces, CanChangePlaces);
            SearchFlightsCommand = new RelayCommand(SearchFlights, CanSearchFlights);
        }
        /// <summary>
        /// Instancja klasy zwracana przez wzorzec singleton
        /// </summary>
        private static MainPageViewModel? instance;
        /// <summary>
        /// Metoda zwracająca jedyną instancję klasy lub tworząca ją jeśli jeszcze nie istnieje
        /// </summary>
        /// <returns>Instancja klasy</returns>
        public static MainPageViewModel GetInstanceMainPageViewModel()
        {
            if (instance == null)
            {
                instance = new MainPageViewModel();
            }
            return instance;
        }

        #region Data i kalendarz
        /// <summary>
        /// Data urodzenia potrzebna do getera publicznej właściwości
        /// </summary>
        private DateTime calendarDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data urodzenia w postaci tekstowej, która jest wyświetlana na stronie
        /// </summary>
        public string CalendarDateString { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        /// <summary>
        /// Właściwość przypsująca tekstowi datę wybraną przez użytkownika w kalendarzu
        /// </summary>
        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set
            {
                CalendarDateString = value.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region Przyciski plusy i minusy z commmand
        /// <summary>
        /// Liczba wybranych dorosłych pasażerów
        /// </summary>
        public int PassengersNumber { get; set; } = 1;
        /// <summary>
        /// Liczba wybranych pasażerów dzieci
        /// </summary>
        public int ChildrenNumber { get; set; } = 0;
        /// <summary>
        /// Komenda obsługująca przycisk dodawania pasażerów dorosłych
        /// </summary>
        public ICommand PlusButtonAdultsCommand { get; set; }
        /// <summary>
        /// Metoda sprawdzająca czy można dodać pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        public bool CanAdd(object value)
        {
            return true;
        }
        /// <summary>
        /// Metoda dodająca dorosłego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        public void AddPassenger(object value)
        {
            PassengersNumber++;
            SetPassengers();
        }
        /// <summary>
        /// Komenda obsługująca przycisk dodawania pasażerów dzieci
        /// </summary>
        public ICommand PlusButtonChildrenCommand { get; set; }
        /// <summary>
        /// Metoda dodająca dziecięcego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        public void AddChild(object value)
        {
            ChildrenNumber++;
            SetPassengers();
        }
        /// <summary>
        /// Komenda obsługująca przycisk odejmowania pasażerów dorosłych
        /// </summary>
        public ICommand MinusButtonAdultsCommand { get; set; }
        /// <summary>
        /// Metoda sprawdzająca czy można odjąć dorosłego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True, jeśli liczba pasażerów dorosłych jest większa od 1, false jeśli jest mniejsza lub równa 1</returns>
        public bool CanSubtractAdult(object value)
        {
            if (PassengersNumber == 1)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Metoda odejmująca dorosłego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        public void SubtractPassenger(object value)
        {
            PassengersNumber--;
            SetPassengers();
        }
        /// <summary>
        /// Komenda obsługująca przycisk odejmowania pasażerów dzieci
        /// </summary>
        public ICommand MinusButtonChildrenCommand { get; set; }
        /// <summary>
        /// Metoda sprawdzająca czy można odjąć dziecięcego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True, jeśli liczba pasażerów dorosłych jest większa od 1, false jeśli jest mniejsza lub równa 0</returns>
        public bool CanSubtractChild(object value)
        {
            if (ChildrenNumber == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Metoda odejmująca dziecięcego pasażera
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        public void SubtractChild(object value)
        {
            ChildrenNumber--;
            SetPassengers();
        }
        /// <summary>
        /// String informujący ile i jacy pasażerowie są wybrani
        /// </summary>
        public string Passengers { get; set; } = "Dorośli: 1";
        /// <summary>
        /// Ustawia string informujący o pasażerach
        /// </summary>
        private void SetPassengers()
        {
            Passengers = "Dorośli: " + PassengersNumber + " Dzieci: " + ChildrenNumber;
            if (ChildrenNumber == 0)
                Passengers = "Dorośli: " + PassengersNumber;
      
        }
        #endregion

        #region Zamiana miejsc wylotu i przylotu
        /// <summary>
        /// Tekst odpowiadający miejscu wylotu
        /// </summary>
        public string SkadText { get; set; } = "";
        /// <summary>
        /// Tekst odpowiadający miejscu przylotu
        /// </summary>
        public string DokadText { get; set; } = "";
        /// <summary>
        /// Komenda obsługująca przycisk zamiany miejsc przylotu i odlotu
        /// </summary>
        public ICommand ChangePlacesCommand { get; set; }
        /// <summary>
        /// Metoda zamieniająca miejsca przylotu i odlotu
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        public void ChangePlaces(object value)
        {
            (DokadText, SkadText) = (SkadText, DokadText);
        }
        /// <summary>
        /// Metoda sprawdzająca czy można zamienić miejca przylotu i odlotu
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        public bool CanChangePlaces(object value)
        { 
            return true; 
        }
        #endregion

        #region Szukanie
        /// <summary>
        /// Komenda obsługująca przycisk wyszukania lotów
        /// </summary>
        public ICommand SearchFlightsCommand { get; set; }
        /// <summary>
        /// Metoda wyszukująca loty, których parametry wybrał użytkownik
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void SearchFlights(object value)
        {
            BasicFlight flightToSearch = new BasicFlight(SkadText, DokadText, CalendarDateString, ChildrenNumber + PassengersNumber, PassengersNumber, ChildrenNumber);
            FlightUse flightUse = new FlightUse();
            flightUse.Search(flightToSearch);
            if (FlightUse.Flights.Any())
            {
                WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                mainWindow.CurrentPage = ApplicationPage.Flights;
            }
            else
            {
                WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                mainWindow.CurrentPage = ApplicationPage.NoFlights;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy można wyszukać loty
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanSearchFlights(object value)
        {
            return true;
        }

        #endregion


    }
}
