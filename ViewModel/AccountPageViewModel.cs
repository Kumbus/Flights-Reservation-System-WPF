using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }
        

        public ICommand DeleteAccountCommand { get; set; }


        private void DeleteAccount(object value)
        {
                string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand("Delete from users where Email = '" + User.Email + "'", connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                mainWindow.CurrentPage = ApplicationPage.Main;
            
        }

        private bool CanDeleteAccount(object value)
        {
            return true;
        }



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
    }
}
