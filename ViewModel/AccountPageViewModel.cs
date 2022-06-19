using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt
{
    public class AccountPageViewModel : BaseViewModel
    {
        public static User? User { get; set; }

        public ObservableCollection<BasicFlight> Flights { get; set; }

        public AccountPageViewModel()
        {
            DataBaseController controller = new DataBaseController();
            Flights = controller.AddFlightToAccount(User.Id);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
            DeleteAccountCommand = new RelayCommand(DeleteAccount, CanDeleteAccount);
            CancelReservationCommand = new RelayCommand(CancelReservation, CanCancelReservation);
        }

        #region Usunięcie konta
        public ICommand DeleteAccountCommand { get; set; }
        private void DeleteAccount(object value)
        {
            DataBaseController dataBaseController = new DataBaseController();
            dataBaseController.DeleteAccount(User.Email);

            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;           
        }
        private bool CanDeleteAccount(object value)
        {
            return true;
        }
        #endregion


        #region Powrót na stronę główną
        public ICommand BackToMainPageCommand { get; set; }

        private void BackToMainPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }

        private bool CanBackToMainPage(object value)
        {
            return true;
        }
        #endregion

        #region Anulowanie rezerwacji
        public ICommand CancelReservationCommand { get; set; }
        private void CancelReservation(object value)
        {
            string number = (string)value;
            DataBaseController dataBaseController = new DataBaseController();

            Flights = dataBaseController.CancelMethods(number, GetFlight(number), User.Id);


        }
        private BasicFlight GetFlight(string id)
        {
            foreach(BasicFlight bf in Flights)
            {
                if(bf.FlightNumber == id)
                    return bf;
            }
            return null;
        }
        private bool CanCancelReservation(object value)
        {
            return true;
        }

        #endregion
    }
}
