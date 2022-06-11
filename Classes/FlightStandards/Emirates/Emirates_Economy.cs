namespace Projekt
{
    public class Emirates_Economy : Emirates
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Klasa ekonomiczna";
        public Emirates_Economy(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Klasa ekonomiczna " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa ekonomiczna - w klasie ekonomicznej Emirates dostajesz o wiele więcej\n\nNasza klasa ekonomiczna\nW klasie ekonomicznej Emirates możesz oczekiwać więcej dzięki tysiącom kanałów, połączeniu Wi - Fi na pokładzie i daniom kuchni " +
                "regionalnej.\n\nPoczuj smak miejsca, do którego lecisz\nWybierz regionalne dania z pokładowego menu i delektuj się potrawami, które zabiorą Cię w podróż po świecie.\n\nOdkryj tysiące kanałów\nOglądaj komedie, thrillery i romanse na pokładzie. " +
                "Wybieraj spośród najnowszych filmów i seriali.\n\nWznieś toast\nDobierz do posiłku któryś z darmowych napojów.\n\nMali podróżni\nMali podróżnicy ucieszą się z naszej rozrywki non‑stop: od kreskówek po klasyczne filmy Disneya.";

        }

        public override double GetPrice(int passengers, int children)
        {
            return Price * (passengers + children * 0.75);
        }
    }
}
