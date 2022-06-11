using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Projekt
{
    public class PaymentPageViewModel : BaseViewModel
    {
        private BasicFlight MyFlight;

        private List<Seat> ChosenSeats = new List<Seat>();


        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string WrongData { get; set; } = "";


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
        }

        #region Data urodzenia
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




        #region Sprawdzanie poprawności danych przy zakupie
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
        public ICommand EndTransactionCommand { get; set; }

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

            }

            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Thanks;
            //MailSender mailSender = new MailSender();
            //mailSender.Send(Email);

        }

        private bool CanEndTransaction(object value)
        {
            return true;
        }

        #endregion
    }
}
