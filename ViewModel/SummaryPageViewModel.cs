using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony podsumowania
    public class SummaryPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Lot, który jest rezerwowany
        /// </summary>
        public BasicFlight MyFlight { get; set; }
        /// <summary>
        /// Cena za lot
        /// </summary>
        private double price = new double();
        /// <summary>
        /// Cena za lot jako tekst
        /// </summary>
        public string StringPrice { get; set; } = "";
        /// <summary>
        /// Lista wybranych miejsc podczas rezerwacji
        /// </summary>
        public List<Seat> ChosenSeats { get; set; } = new List<Seat>();
        /// <summary>
        /// Lista klas podróży dla danej lini lorniczej
        /// </summary>
        private List<BasicFlight> FlightClasses  = new List<BasicFlight>();
        /// <summary>
        /// Kolekcja foteli w samolocie
        /// </summary>
        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();
        /// <summary>
        /// Konstruktor 
        /// </summary>
        public SummaryPageViewModel()
        {
            Messenger.Default.Register<BasicFlight>(this, (Flight) =>
            {
                MyFlight = (BasicFlight)Flight;
            });

            Messenger.Default.Register<List<Seat>>(this, (clickedSeats) =>
            {
                ChosenSeats = clickedSeats;
                FlightClasses = MyFlight.GenerateDerived();
                MakeCollection();
                SetPrize();
            });

            GoToPaymentPageCommand = new RelayCommand(GoToPaymentPage, CanGoToPaymentPage);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);

            price = 0;
        }

        #region Przypsanie danych
        /// <summary>
        /// Tworzy listę wybranych krzeseł
        /// </summary>
        private void MakeCollection()
        {

            for (int i = 0; i < ChosenSeats.Count; i++) 
            {
                ChosenSeats[i].SetClass(MyFlight.Name);
                Seats.Add(ChosenSeats[i]);
            }
        }
        /// <summary>
        /// Ustawia cenę w zależności od wybranych miejsc
        /// </summary>
        private void SetPrize()
        {
            int i = 0;
            for (i = i; i < MyFlight.passengersNumber; i++) 
            {
                switch (ChosenSeats[i].Number[0])
                {
                    case 'E':
                        {
                            price += FlightClasses[0].GetPrice(1, 0);
                            break;
                        }
                    case 'P':
                        {
                            price += FlightClasses[1].GetPrice(1, 0);
                            break;
                        }
                    case 'B':
                        {
                            price += FlightClasses[2].GetPrice(1, 0);
                            break;
                        }
                    case 'F':
                        {
                            price += FlightClasses[3].GetPrice(1, 0);
                            break;
                        }
                }
            }

            for (i = i; i < MyFlight.passengersNumber + MyFlight.childrenNumber; i++)
            {
                switch (ChosenSeats[i].Number[0])
                {
                    case 'E':
                        {
                            price += FlightClasses[0].GetPrice(0, 1);
                            break;
                        }
                    case 'P':
                        {
                            price += FlightClasses[1].GetPrice(0, 1);
                            break;
                        }
                    case 'B':
                        {
                            price += FlightClasses[2].GetPrice(0, 1);
                            break;
                        }
                    case 'F':
                        {
                            price += FlightClasses[3].GetPrice(0, 1);
                            break;
                        }
                }
            }

            StringPrice = price + " zł";
        }
        #endregion

        #region Przejdź do płatności
        /// <summary>
        /// Komenda zmieniająca stronę na stronę płatności
        /// </summary>
        public ICommand GoToPaymentPageCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę płatności
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoToPaymentPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Payment;
            Messenger.Default.Send(MyFlight);
            Messenger.Default.Send(ChosenSeats);
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę płatności może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoToPaymentPage(object value)
        {
            return true;
        }

        #endregion

        #region Powrót do wyboru foteli
        /// <summary>
        /// Komenda zmieniająca stronę na stronę wyboru miejsc
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę wyboru miejsc
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.SeatChoice;

        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę wyboru miejsc może zostać wykonana
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
