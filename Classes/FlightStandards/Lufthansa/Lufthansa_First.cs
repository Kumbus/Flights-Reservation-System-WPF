namespace Projekt
{
    public class Lufthansa_First : Lufthansa
    {
        public Lufthansa_First(BasicFlight bf) : base(bf)
        {
            Name = "Klasa Pierwsza";
            NameAndPrice = "Klasa Pierwsza " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa Pierwsza Lufthansy\nCzęsto drobiazgi i małe przyjemności mogą sprawić, że chwila staje się wyjątkowa.Na lotnisku docelowym czeka osobisty " +
                "asystent, ponad chmurami można delektować się kulinarnymi kreacjami, a indywidualna przestrzeń zapewnia prywatność na pokładzie – to chwile, które " +
                "pozostają w pamięci.Poprzez wielką dbałość o szczegóły oraz o indywidualne wymagania naszych gości sprawiamy, że podróż Klasą Pierwszą Lufthansy jest " +
                "tak przyjemna, jak to tylko jest to możliwe. Fantastyczny komfort i doskonały serwis podczas wyjątkowej podróży Klasą Pierwszą.\n\nUsługa Valet parking\n" +
                "Przyjazd na lotnisko powinien być tak prosty i przyjemny jak tylko jest to możliwe. Dlatego w naszym Terminalu Klasy Pierwszej oferujemy usługę valet " +
                "parking, zarówno dla samochodów wypożyczonych jak i prywatnych.\n\nOsobisty asystent\nNie trzeba spoglądać na zegarek - można skupić się na tym, co ważne. " +
                "Pasażerowie Klasy Pierwszej, zawsze korzystają z indywidualnej obsługi.\n\nTerminal Klasy Pierwszej\nRozpoczynając podróż w Terminalu Klasy Pierwszej na " +
                "lotnisku, możesz rozkoszować się usługami najwyższej jakości.\n\nSaloniki Klasy Pierwszej\nSalonik zapewnia relaks i pozwala odciąć się od lotniskowego" +
                " zgiełku.\n\nLimuzyna z szoferem\nWsiadasz do limuzyny lub eleganckiego autobusiku i szofer zawozi Cię wprost do samolotu.\n\nFlota Klasy Pierwszej\n" +
                "Jest absolutnie zrozumiałe, że możliwość korzystania z najnowszej wersji Klasy Pierwszej powinna być dostępna we wszystkich samolotach międzykontynentalnej" +
                " floty Lufthansy.\n\nKomfort na pokładzie Klasy Pierwszej\nPonadczasowe eleganckie wzornictwo, wysokogatunkowe materiały i przyjemne oświetlenie to raj" +
                " dla zmysłów.Każda chwila należy do Ciebie\n\nKulinarne kreacje oraz doskonałe wina\nChwile kulinarnych rozkoszy to jeden z ważnych punktów podczas podróży " +
                "Klasą Pierwszą Lufthansy.\n\nŚwiat rozrywki\nDoskonała oferta wielkiego świata rozrywki. Nasz program rozrywki w Klasie Pierwszej zapewnia szeroki wybór.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 7 * Price * (passengers + children * 0.75);
        }
    }
}
