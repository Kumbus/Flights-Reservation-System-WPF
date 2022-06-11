using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt
{
    public class SummaryPageViewModel : BaseViewModel
    {
        public BasicFlight MyFlight { get; set; }
        private double price = 0;
        public string StringPrice { get; set; } = "";
        public List<Seat> ChosenSeats { get; set; } = new List<Seat>();
        private List<BasicFlight> FlightClasses  = new List<BasicFlight>();

        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();
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
        }

        #region Przypsanie danych
        private void MakeCollection()
        {

            for (int i = 0; i < ChosenSeats.Count; i++) 
            {
                ChosenSeats[i].SetClass(MyFlight.Name);
                Seats.Add(ChosenSeats[i]);
            }
        }

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

        #region Komenda
        public ICommand GoToPaymentPageCommand { get; set; }

        private void GoToPaymentPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Payment;
            Messenger.Default.Send(MyFlight);
            Messenger.Default.Send(ChosenSeats);
        }

        private bool CanGoToPaymentPage(object value)
        {
            return true;
        }

        #endregion

    }
}
