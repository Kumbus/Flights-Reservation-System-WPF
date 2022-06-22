using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony profilu użytkownika
    /// </summary>
    public class AccountPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Zalogowany użytkownik
        /// </summary>
        public static User? User { get; set; }
        /// <summary>
        /// Loty zarezerwowane na zalogowanego użytkownika
        /// </summary>
        public ObservableCollection<BasicFlight> Flights { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public AccountPageViewModel()
        {
            DataBaseController controller = new DataBaseController();
            Flights = controller.AddFlightToAccount(User.Id);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
            DeleteAccountCommand = new RelayCommand(DeleteAccount, CanDeleteAccount);
            CancelReservationCommand = new RelayCommand(CancelReservation, CanCancelReservation);
        }

        #region Usunięcie konta
        /// <summary>
        /// Komenda obsługująca przycisk usunięcia konta
        /// </summary>
        public ICommand DeleteAccountCommand { get; set; }
        /// <summary>
        /// Metoda usuwająca konto
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void DeleteAccount(object value)
        {
            DataBaseController dataBaseController = new DataBaseController();
            dataBaseController.DeleteAccount(User.Email);

            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;           
        }
        /// <summary>
        /// Metoda sprawdzająca czy można usunąć konto
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanDeleteAccount(object value)
        {
            return true;
        }
        #endregion


        #region Powrót na stronę główną
        /// <summary>
        /// Komenda zmieniająca stronę na stronę początkową
        /// </summary>
        public ICommand BackToMainPageCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę początkową
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void BackToMainPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę początkową może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanBackToMainPage(object value)
        {
            return true;
        }
        #endregion

        #region Anulowanie rezerwacji
        /// <summary>
        /// Komenda obsługująca anulowanie rezerwacji
        /// </summary>
        public ICommand CancelReservationCommand { get; set; }
        /// <summary>
        /// Metoda anulująca rezerwację
        /// </summary>
        /// <param name="value">Parametr komendy - numer lotu</param>
        private void CancelReservation(object value)
        {
            string number = (string)value;
            DataBaseController dataBaseController = new DataBaseController();

            Flights = dataBaseController.CancelMethods(number, GetFlight(number), User.Id);


        }
        /// <summary>
        /// Metoda znajdująca lot do anulowania wśród lotów użytkownika
        /// </summary>
        /// <param name="id">ID lotu</param>
        /// <returns>Lot do anulowania</returns>
        private BasicFlight GetFlight(string id)
        {
            foreach(BasicFlight bf in Flights)
            {
                if(bf.FlightNumber == id)
                    return bf;
            }
            return null;
        }
        /// <summary>
        /// Metoda sprawdzająca czy lot może zostać anulowany
        /// </summary>
        /// <param name="value">Parametr komendy - numer lotu</param>
        /// <returns>True</returns>
        private bool CanCancelReservation(object value)
        {
            return true;
        }

        #endregion
    }
}
