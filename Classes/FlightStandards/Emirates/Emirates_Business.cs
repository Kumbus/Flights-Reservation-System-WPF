namespace Projekt
{
    public class Emirates_Business : Emirates
    {
        public Emirates_Business(BasicFlight bf) : base(bf)
        {
            Name = "Klasa biznes";
            NameAndPrice = "Biznes " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Nasza klasa biznes - zobacz, czego możesz oczekiwać w klasie biznes Emirates.\n\nWyśpij się podczas lotu\nFotel, który płynnie rozkłada się w płaskie łóżko z miękkim, wygodnym materacem i przytulnym kocem.Słodkich snów!" +
                "\n\nPrzyleć na miejsce z głową pełną pomysłów\nPołącz interesy i przyjemności w naszej klasie biznes. Wysyłaj e‑maile, napisz kolejny rozdział książki albo opublikuj wpis na blogu.\n\nNawiązuj znajomości na wysokości 12 km\nWłącz się do rozmowy w naszym nowym saloniku pokładowym. Poznawaj ciekawych ludzi, " +
                "delektując się przekąskami.\n\nPoznaj smaki kuchni świata\nWybieraj z karty wykwintnych regionalnych dań i delektuj się potrawami, które zabiorą Cię w podróż po świecie.\n\nSkorzystaj z dodatkowych udogodnień podczas podróży\n" +
                "Odśwież się podczas lotu dzięki wyjątkowym kosmetykom Bvlgari z kolekcji Aqua Pour Homme i Omnia Crystalline. W eleganckim zestawie udogodnień podróżnych znajdziesz wszystko, czego potrzeba zarówno kobietom, jak i mężczyznom – od lusterka" +
                " i kremu do twarzy po balsam do ust i piankę do golenia.\n\nPodróżuj bez stresu\nZarezerwuj bezpłatną usługę prywatnego kierowcy w drodze na lotnisko i z lotniska.\n\nPoczekalnie na lotnisku\nPrzed wylotem poszukaj inspiracji w naszych" +
                " poczekalniach dla klasy biznes na lotniskach.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 6.22 * Price * (passengers + children * 0.65);
        }
    }
}
