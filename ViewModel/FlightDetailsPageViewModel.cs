using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony ze szczegółami lotu
    /// </summary>
    public class FlightDetailsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Lista klas podróży dostępnych w locie
        /// </summary>
        public List<BasicFlight> FlightClasses { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca za widoczność przycisku z 4 klasą podróży, który jest niedostępny dla LOTu
        /// </summary>
        public string Button4Visibility { get; set; }
        /// <summary>
        /// Opis aktualnie przeglądanej klasy podróży
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Lot, którego dotyczy rezerwacja
        /// </summary>
        public BasicFlight Flight { get; set; }
        /// <summary>
        /// Konstuktor
        /// </summary>
        public FlightDetailsPageViewModel()
        {
            Flight = FlightUse.FindOne();
            SetVisibility();
            FlightClasses = Flight.GenerateDerived();
            Description = FlightClasses[0].Describe();
            ChangeDescriptionCommand = new RelayCommand(ChangeDescription, CanChangeDescription);
            GoToSeatChoiceCommand = new RelayCommand(GoToSeatChoice, CanGoToSeatChoice);
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
        }

        #region Zmiana opisów klas lotów
        /// <summary>
        /// Komenda obsługująca zmianę przyciski zmieniające opis
        /// </summary>
        public ICommand ChangeDescriptionCommand { get; set; }
        /// <summary>
        /// Metoda zmieniająca opis w zależności od klasy podróży
        /// </summary>
        /// <param name="value">Parametr komendy - indeks klasy podróży w liście klas</param>
        private void ChangeDescription(object value)
        {
            Description = FlightClasses[Int32.Parse((string)value)].Describe();
        }
        /// <summary>
        /// Metoda sprawdzająca czy można zmienić opis
        /// </summary>
        /// <param name="value">Parametr komendy - indeks klasy podróży w liście klas</param>
        /// <returns>True</returns>
        private bool CanChangeDescription(object value)
        {
            return true;
        }
        #endregion

        #region Przejście do wyboru miejsc
        /// <summary>
        /// Komenda zmieniająca stronę na stronę wyboru miejsc
        /// </summary>
        public ICommand GoToSeatChoiceCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę wyboru miejsc
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoToSeatChoice(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            WindowViewModel.Flight = Flight;
            mainWindow.CurrentPage = ApplicationPage.SeatChoice;
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę wyboru miejsc może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoToSeatChoice(object value)
        {
            return true;
        }

        #endregion
        /// <summary>
        /// Metoda zmieniająca widoczność przycisku dla 4 klasy podróży
        /// </summary>
        private void SetVisibility()
        {
            if (Flight.HowManyClasses() > 3)
                Button4Visibility = "Visible";
            else
                Button4Visibility = "Collapsed";
        }

        #region Powrót do lotów
        /// <summary>
        /// Komenda zmieniająca stronę na stronę wyboru lotów
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę wyboru lotów
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoBack(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Flights;

        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę wyboru lotów może zostać wykonana
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
