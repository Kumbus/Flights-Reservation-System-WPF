namespace Projekt
{
    public class Lot_EconomyClass : Lot
    {
        public Lot_EconomyClass(BasicFlight bf) : base(bf)
        {
            Name = "Economy Class";
            NameAndPrice = "Economy Class " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "LOT Economy Class\n\nLataj komfortowo w wygodnym fotelu w przestronnej kabinie samolotu Dreamliner, poznaj zalety podróżowania klasą ekonomiczną LOT:\n\n" +
                "Bagaż\nNa lotach międzykontynentalnych oferujemy zarówno bilety z bagażem rejestrowanym, jak i bagażem podręcznym.Sam zdecyduj, która taryfa odpowiada na Twoje potrzeby.\n\n" +
                "Komfort podróży\nWszystkie fotele w naszych Dreamlinerach wyposażone są w gniazdko elektryczne, port USB i indywidualny system rozrywki pokładowej. " +
                "W samolocie zamontowane zostało oświetlenie typu LED oraz zaciemniane okna, których zadaniem jest minimalizowanie tzw. jet - lagu. Podróżując na trasach dalekiego zasięgu" +
                " zarówno wygodny, odchylany fotel o szerokości siedziska 43 cm, regulowany zagłówek w każdym fotelu, jak również dołączone koc i poduszka zapewniają komfortowe warunki podróży.\n\n" +
                "Rozrywka pokładowa\nPodczas rejsów dalekiego zasięgu możesz skorzystać z szerokiej oferty rozrywki pokładowej - do Twojej dyspozycji oddajemy ponad 100 filmów" +
                " i seriali(w tym produkcje inspirowane krajami, do których latamy), a także koncerty, programy rozrywkowe i gry. Sprawdź aktualny repertuar(Otwiera się w nowym oknie).\n\n" +
                "Smaczne menu\nW klasie ekonomicznej oferujemy smaczne i wyjątkowe dania. Zawsze czeka na Ciebie ciepły posiłek, w którym możesz wybrać danie gorące spośród dwóch dostępnych" +
                " opcji. Przed lądowaniem podamy drugi posiłek, którym w zależności od długości lotu będzie danie gorące lub przekąska.W trakcie całego lotu serwujemy również bezpłatne " +
                "napoje: kawa, herbata, woda, napoje gazowane i soki owocowe, a także wino białe i czerwone oraz piwo.W każdej chwili możesz skorzystać z naszego płatnego menu LOT Sky Bar " +
                "lub wypróbować posiłek z klasy LOT Premium Economy korzystając z usługi Zamów na pokład posiłek klasy Premium.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return Price * (passengers + children * 0.90);
        }
    }
}
