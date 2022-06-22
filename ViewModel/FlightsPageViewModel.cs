using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony wyboru lotów
    /// </summary>
    public class FlightsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Obserwowalna kolekcja zawierająca wszystkie loty pasujące parametrom podanym przez użytkownika
        /// </summary>
        public ObservableCollection<BasicFlight>? Flights { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public FlightsPageViewModel()
        {
            Flights = FlightUse.Flights;
            GoToDetailsCommand = new RelayCommand(GoToDetails, CanGoToDetails);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region Przejście do szczegółów lotu
        /// <summary>
        /// Komenda zmieniająca stronę na stronę szczegółów lotu
        /// </summary>
        public ICommand GoToDetailsCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę szczegółów lotu
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoToDetails(object value)
        {
            FlightUse.Indeks = value as string;
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.FlightDetails;
            
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę szczegółów lotu może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoToDetails(object value)
        {
            return true;
        }

        #endregion

        #region Powrót do strony głównej
        /// <summary>
        /// Komenda zmieniająca stronę na stronę początkową
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę początkową
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;

        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę początkową może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoBack(object value)
        {
            return true;
        }

        #endregion

    }
}
