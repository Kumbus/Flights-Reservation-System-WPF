using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca lini lotniczej Lot
    /// </summary>
    public class Lot : BasicFlight
    {
        /// <summary>
        ///  Stała określająca ilość klas pochodnych
        /// </summary>
        private new const int classAmount = 3;
        /// <summary>
        ///  Właściwość odpowiadająca konfiguracji siedzeń w samolocie
        /// </summary>
        public override string seatsString { get; set; }
        /// <summary>
        ///  Lista obserwowalnych kolekcji, gdzie każda jest konfiguracją siedzeń dla innej klasy podóży
        /// </summary>
        public List<ObservableCollection<Seat>> SeatsLayout;
        /// <summary>
        ///  Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public Lot(BasicFlight bf) : base(bf)
        {
            Name = "Lot";
            DataBaseController dataBaseController = new DataBaseController();
            seatsString = dataBaseController.GetSeats(bf);
            SeatsLayout = new List<ObservableCollection<Seat>>();
            CreateSeatsCollection();
        }
        /// <summary>
        ///  Pole odpowiadające cenie dodające krótki opis w geterze
        /// </summary>
        public string PriceString 
        {
            get
            {
                return "Ceny już od: " + GetPrice(passengersNumber, childrenNumber) + " zł";
            }

            set
            {
            }
        }
        /// <summary>
        ///  Metoda opisująca lot używana przez klasy pochodne
        ///  <returns>Opis klasy podróży</returns>
        /// </summary>
        override public string Describe()
        {
            return "Cudowny lot z Lotem";
        }
        /// <summary>
        ///  Metoda zwracająca ilość klas pochodnych
        ///  <returns>Liczba klas pochodnych</returns>
        /// </summary>
        public override int HowManyClasses()
        {
            return classAmount;
        }
        /// <summary>
        ///  Metoda wirtualna zwracająca klasy pochodne dla klas pochodnych
        ///  <returns>Lista zawierająca obiekty klas pochodnych</returns>
        /// </summary>
        public override List<BasicFlight> GenerateDerived()
        {
            List<BasicFlight> derived = new List<BasicFlight>();

            derived.Add(new Lot_EconomyClass(this));
            derived.Add(new Lot_EconomyClassPremium(this));
            derived.Add(new Lot_BusinessClass(this));


            return derived;
        }
        /// <summary>
        ///  Metoda tworząca kolekcje siedzeń na podstawie danych pobranych z bazy
        /// </summary>
        public void CreateSeatsCollection()
        {
            ObservableCollection<Seat> economySeats = new ObservableCollection<Seat>();
            ObservableCollection<Seat> premiumSeats = new ObservableCollection<Seat>();
            ObservableCollection<Seat> businessSeats = new ObservableCollection<Seat>();
            int countEconomy = 0, countPremium = 0, countBusiness = 0;

            for (int i = 0; i < seatsString.Length - 1; i++) 
            {
                if (seatsString[i] == '1' || seatsString[i] == '0')
                    continue;

                Seat seat = new Seat();
                if (seatsString[i] == 'E')
                {
                    countEconomy++;
                    seat.Number = "E" + countEconomy;
                    
                    if (seatsString[i + 1] == '1')
                        seat.Free = false;
                    else
                        seat.Free = true;

                    economySeats.Add(seat);
                }
                else if (seatsString[i] == 'P')
                {
                    countPremium++;
                    seat.Number = "P" + countPremium;
                    if (seatsString[i + 1] == '1')
                        seat.Free = false;
                    else
                        seat.Free = true;

                    premiumSeats.Add(seat);
                }
                else if (seatsString[i] == 'B')
                {
                    countBusiness++;
                    seat.Number = "B" + countBusiness;
                    if (seatsString[i + 1] == '1')
                        seat.Free = false;
                    else
                        seat.Free = true;

                    businessSeats.Add(seat);
                }


            }

            SeatsLayout.Add(economySeats);
            SeatsLayout.Add(premiumSeats);
            SeatsLayout.Add(businessSeats);
        }
        /// <summary>
        ///  Metoda zwracająca konfigurację siedzeń 
        ///  <returns>Lista obserwowalnych kolekcji gdzie każda jest ułożenie mfoteli w danej klasie podróży</returns>
        /// </summary>
        public override List<ObservableCollection<Seat>> GetSeats()
        {
            return SeatsLayout;
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla najtańszej klasy podróży lotu
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Najtańsza cena lotu</returns>
        /// </summary>
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(Price * (passengers + children * 0.90), 2);
        }
    }
}
