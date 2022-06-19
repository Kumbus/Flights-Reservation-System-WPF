using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca lini lotniczej Lot
    /// </summary>
    public class Lot : BasicFlight
    {
        private new const int classAmount = 3;
        public override string seatsString { get; set; }
        public List<ObservableCollection<Seat>> SeatsLayout;
        public Lot(BasicFlight bf) : base(bf)
        {
            Name = "Lot";
            DataBaseController dataBaseController = new DataBaseController();
            seatsString = dataBaseController.GetSeats(bf);
            SeatsLayout = new List<ObservableCollection<Seat>>();
            CreateSeatsCollection();
        }


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

        override public string Describe()
        {
            return "Cudowny lot z Lotem";
        }

        public override int HowManyClasses()
        {
            return classAmount;
        }

        public override List<BasicFlight> GenerateDerived()
        {
            List<BasicFlight> derived = new List<BasicFlight>();

            derived.Add(new Lot_EconomyClass(this));
            derived.Add(new Lot_EconomyClassPremium(this));
            derived.Add(new Lot_BusinessClass(this));


            return derived;
        }

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

        public override List<ObservableCollection<Seat>> GetSeats()
        {
            return SeatsLayout;
        }

        public override double GetPrice(int passengers, int children)
        {
            return Price * (passengers + children * 0.90);
        }
    }
}
