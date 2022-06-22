using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony wyboru miejsc
    /// </summary>
    public class SeatChoicePageViewModel : BaseViewModel
    {
        /// <summary>
        /// Lot, którego dotyczy rezerwacja
        /// </summary>
        public BasicFlight Flight { get; set; } = WindowViewModel.Flight;
        /// <summary>
        /// Tekst przycisku potwierdzającego
        /// </summary>
        public string ButtonText { get; set; }
        /// <summary>
        /// Liczba wybranych siedzeń
        /// </summary>
        private int NumberOfClicked = 0;
        /// <summary>
        /// Lista zawierająca nazwy klas podróży lini lotniczych
        /// </summary>
        public List<string> ClassNames { get; set; } = new List<string>();
        /// <summary>
        /// Kolekcja miejsc w najtańszej klasie podróży
        /// </summary>
        public ObservableCollection<Seat>? EconomySeats { get; set; }
        /// <summary>
        /// Kolekcja miejsce w drugiej najtańszej klasie podróży 
        /// </summary>
        public ObservableCollection<Seat>? PremiumSeats { get; set; }
        /// <summary>
        /// Kolekcja miejsce w prawie najdroższej klasie podróży 
        /// </summary>
        public ObservableCollection<Seat>? BusinessSeats { get; set; }
        /// <summary>
        /// Kolekcja miejsce w najdroższej klasie podróży 
        /// </summary>
        public ObservableCollection<Seat>? FirstSeats { get; set; }
        /// <summary>
        /// Słownik gdzie numer fotela jest kluczem, a fotel wartością
        /// </summary>
        private Dictionary<string, Seat> seatsDictionary = new Dictionary<string, Seat>();
        /// <summary>
        /// Lista wybranych miejsc
        /// </summary>
        private List<Seat> clickedSeats = new List<Seat>();
        /// <summary>
        /// Konstruktor
        /// </summary>
        public SeatChoicePageViewModel()
        {

            Thread economySeatsThread = new Thread(() => EconomySeats = Flight.GetSeats()[0]);
            economySeatsThread.Start();
            Thread premiumSeatsThread = new Thread(() => PremiumSeats = Flight.GetSeats()[1]);
            premiumSeatsThread.Start();
            Thread businessSeatsThread = new Thread(() => BusinessSeats = Flight.GetSeats()[2]);
            businessSeatsThread.Start();


            if (Flight.GetSeats().Count > 3)
            {
                Thread firstSeatsThread = new Thread(() => FirstSeats = Flight.GetSeats()[3]);
                firstSeatsThread.Start();
                firstSeatsThread.Join();
            }

            economySeatsThread.Join();
            premiumSeatsThread.Join();
            businessSeatsThread.Join();
            
            CreateDictionary();
            CheckNumber();
            SetNames();

            ButtonText = "Pozostałe siedzenia do wybrania: " + (Flight.passengersNumber + Flight.childrenNumber - NumberOfClicked);
            CheckClickedSeatsCommand = new RelayCommand(CheckClickedSeats, CanCheckClickedSeats);
            GoToSummaryCommand = new RelayCommand(GoToSummary, CanGoToSummary);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region SeatsCommand
        /// <summary>
        /// Komenda wykonująca operacje po wybraniu miejsca
        /// </summary>
        public ICommand CheckClickedSeatsCommand { get; set; }
        /// <summary>
        /// Tworzy kolekcję wybranych krzeseł
        /// </summary>
        /// <param name="value">Numer krzesła</param>
        private void CheckClickedSeats(object value)
        {
            string number = Convert.ToString(value);
            Seat clickedSeat = seatsDictionary[number];
            bool clicked = clickedSeat.Clicked;
            if(clicked == true)
            {
                NumberOfClicked++;
                clickedSeats.Add(clickedSeat);
                if (NumberOfClicked > Flight.passengersNumber + Flight.childrenNumber) 
                {
                    int index = Int32.Parse(clickedSeats[0].Number.Substring(1)) - 1;
                    switch (clickedSeats[0].Number[0])
                    {
                        case 'E':
                            {
                                Seat newSeat = EconomySeats[index];
                                newSeat.Clicked = false;
                                EconomySeats.RemoveAt(index);
                                EconomySeats.Insert(index, newSeat);
                                break;
                            }
                        case 'P':
                            {
                                Seat newSeat = PremiumSeats[index];
                                newSeat.Clicked = false;
                                PremiumSeats.RemoveAt(index);
                                PremiumSeats.Insert(index, newSeat);
                                break;
                            }

                        case 'B':
                            {
                                Seat newSeat = BusinessSeats[index];
                                newSeat.Clicked = false;
                                BusinessSeats.RemoveAt(index);
                                BusinessSeats.Insert(index, newSeat);
                                break;
                            }
                        case 'F':
                            {
                                Seat newSeat = FirstSeats[index];
                                newSeat.Clicked = false;
                                FirstSeats.RemoveAt(index);
                                FirstSeats.Insert(index, newSeat);
                                break;
                            }


                    }
                    clickedSeats.RemoveAt(0);
                    NumberOfClicked--;
                }
            }
            else
            {
                NumberOfClicked--;
                clickedSeats.Remove(clickedSeat);
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę płatności może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanCheckClickedSeats(object value)
        {
            return true;
        }

        #endregion
        /// <summary>
        /// Metoda tworząca słownik z list z miejscami
        /// </summary>
        private void CreateDictionary()
        {
            foreach(Seat s in EconomySeats)
                seatsDictionary.Add(s.Number, s);

            foreach (Seat s in PremiumSeats)
                seatsDictionary.Add(s.Number, s);

            foreach (Seat s in BusinessSeats)
                seatsDictionary.Add(s.Number, s);

            if (Flight.GetSeats().Count > 3)
                foreach (Seat s in FirstSeats)
                    seatsDictionary.Add(s.Number, s);

        }
        /// <summary>
        /// Metoda sprawdzająca ile siedzeń jest już wybranych przy przejściu do strony - potrzebne kiedy się cofamy
        /// </summary>
        private void CheckNumber()
        {
            foreach(KeyValuePair<string, Seat> s in seatsDictionary)
            {
                if (s.Value.Clicked == true)
                {
                    clickedSeats.Add(s.Value);
                    NumberOfClicked++;
                }
            }
        }

        #region Przejście do podsumowania
        /// <summary>
        /// Komenda zmieniająca stronę na stronę podsumowania
        /// </summary>
        public ICommand GoToSummaryCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę podsumowania
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoToSummary(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Summary;
            Messenger.Default.Send(Flight);
            Messenger.Default.Send(clickedSeats);
            
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę podsumowania może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoToSummary(object value)
        {
            if (NumberOfClicked == Flight.passengersNumber + Flight.childrenNumber)
            {
                ButtonText = "Podsumowanie";
                return true;
            }
            else
            {
                ButtonText = "Pozostałe siedzenia do wybrania: " + (Flight.passengersNumber + Flight.childrenNumber - NumberOfClicked);
                return false;
            }
        }

        #endregion

        #region Powrót do lotów
        /// <summary>
        /// Komenda zmieniająca stronę na stronę lotów
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę lotów
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Flights;

        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę lotów może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoBack(object value)
        {
            return true;
        }
        #endregion
        /// <summary>
        /// Metoda przypisująca nazwy klas podróży do listy
        /// </summary>
        private void SetNames()
        {
            List<BasicFlight> classes = Flight.GenerateDerived();
            foreach(BasicFlight flight in classes)
                ClassNames.Add(flight.Name);
        }

    }
}
