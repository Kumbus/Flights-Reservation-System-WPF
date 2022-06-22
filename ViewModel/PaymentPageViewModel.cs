using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowidająca za zachowanie strony płatności
    /// </summary>
    public class PaymentPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Lot, którego dotyczy rezerwacja
        /// </summary>
        private BasicFlight MyFlight;
        /// <summary>
        /// Lista miejsc wybranych podczas rezerwacji
        /// </summary>
        private List<Seat> ChosenSeats = new List<Seat>();

        /// <summary>
        /// Imię użytkownika
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        public string Surname { get; set; } = "";
        /// <summary>
        /// Email użytkownika
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// Numer telefonu użytkownika
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// Właściwość przechowująca tekst, który jest wyświetlony kiedy wprowadzone dane są nieprawidłowe
        /// </summary>
        public string WrongData { get; set; } = "";

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PaymentPageViewModel()
        {
            if (WindowViewModel.logged == true)
            {
                User user = AccountPageViewModel.User;
                Name = user.Name;
                Surname = user.Surname;
                Email = user.Email;
                PhoneNumber = user.PhoneNumber;
                CalendarDateString = user.Birthday;
            }

            Messenger.Default.Register<BasicFlight>(this, (Flight) =>
            {
                MyFlight = Flight;
            });

            Messenger.Default.Register<List<Seat>>(this, (clickedSeats) =>
            {
                ChosenSeats = clickedSeats;
            });

            EndTransactionCommand = new RelayCommand(EndTransaction, CanEndTransaction);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region Data urodzenia
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

        #region Sprawdzanie poprawności danych przy zakupie
        /// <summary>
        /// Metoda sprawdzająca czy wpisane dane są poprawne
        /// </summary>
        /// <returns>True jeśli dane są poprawne, false jeśli dan enie są poprawne</returns>
        private bool CheckData()
        {
            Regex checkNameAndSurname = new Regex(@"^[\p{L}\p{M}][\p{L}\p{M}\-.' ]*[\p{L}\p{M}]$");
            Regex checkEmail = new Regex(@"^[a-zA-Z0-9][a-zA-Z\.\-_0-9]{2,}@[a-zA-Z\.\-_0-9]{2,}(\.[a-zA-Z]{2,3})$");
            Regex checkPhoneNumber1 = new Regex(@"[0-9]{9}");
            Regex checkPhoneNumber2 = new Regex(@"^+[0-9]{2} [0-9]{9}");
            if (!checkNameAndSurname.IsMatch(Name))
            {
                WrongData = "Imię zawiera nieprawidłowe znaki";
                return false;
            }
            else if (!checkNameAndSurname.IsMatch(Surname))
            {
                WrongData = Name + " Nazwisko zawiera nieprawidłowe znaki";
                return false;
            }
            else if (!checkEmail.IsMatch(Email))
            {
                WrongData = "Email jest nieprawidłowy";
                return false;
            }
            else if (!(checkPhoneNumber1.IsMatch(PhoneNumber) || checkPhoneNumber2.IsMatch(PhoneNumber)))
            {
                WrongData = "Numer telefonu jest nieprawidłowy";
                return false;
            }

            return true;
        }
        #endregion

        #region Zakończenie zakupu
        /// <summary>
        /// Komenda odpowiadająca przyciskowi kończącemu transakcję 
        /// </summary>
        public ICommand EndTransactionCommand { get; set; }
        /// <summary>
        /// Metoda do komendy, która kończy transakcję i wywołuje metody zapisujące wszystko do bazy danych
        /// </summary>
        /// <param name="value">Parametr komendy - nulll</param>
        private void EndTransaction(object value)
        {
            if (CheckData())
            {
                DataBaseController controller = new DataBaseController();
                controller.UpdateAfterPurchase(MyFlight, ChosenSeats);
                if (WindowViewModel.logged == true)
                    controller.LoadLoggedUserFlight(MyFlight, AccountPageViewModel.User, ChosenSeats);
                else
                    controller.LoadUnloggedUserFlight(MyFlight, Name, Surname, Email, PhoneNumber, CalendarDateString, ChosenSeats);

                WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                mainWindow.CurrentPage = ApplicationPage.Thanks;

            }

        }
        /// <summary>
        /// Metoda sprawdzająca czy można wyknać komendę, która końćzy transakcję
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanEndTransaction(object value)
        {
            return true;
        }



        #endregion

        #region Powrót do podsumowanie
        /// <summary>
        /// Komenda zmieniająca stronę na stronę podsumowania
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę podsumowania
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Summary;
            Messenger.Default.Send(WindowViewModel.Flight);
            Messenger.Default.Send(ChosenSeats);
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę podsumowania może zostać wykonana
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
