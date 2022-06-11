namespace Projekt
{
    public class Lot_BusinessClass : Lot
    {

        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Business Class";
        public Lot_BusinessClass(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Business Class " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "LOT Business Class\n\nDzięki LOT Business Class każda podróż staje się unikatowa i niezapomniana. To chwile tylko dla ciebie - dzięki nim poczujesz się zrelaksowany" +
                " i gotowy do nowych wyzwań. Skorzystaj z wyjątkowych udogodnień podczas podróży Dreamlinerem i poznaj zalety podróżowania w LOT Business Class!\n\n" +
                "Relaks przed podróżą\nPodróż staje się przyjemnością już na lotnisku. Z biletem w LOT Business Class masz dostęp do saloników biznesowych na wszystkich głównych lotniskach " +
                "na świecie. Podróżując w LOT Business Class możesz wypocząć przed podróżą lub znaleźć miejsce do pracy w komfortowych warunkach.\n\n" +
                "Priorytetowa obsługa na lotnisku\nJako pasażerowi klasy biznes przysługuje Ci priorytetowy check-in w dedykowanej strefie odpraw, Fast Track oraz możliwość wejścia na pokład" +
                " samolotu w dowolnym momencie. Jako pierwszy możesz również odebrać swój bagaż tuż po lądowaniu. Do Twojej dyspozycji oddajemy dedykowaną linię premium w LOT Contact Center " +
                "oraz LOT Transfer Center.\n\nWiększy bagaż\nNa wszystkich trasach w LOT Business Class przysługuje Ci wyższy limit bagażowy. Możesz zabrać ze sobą 3 x 32 kg sztuki bagażu " +
                "rejestrowanego.\n\nKomfort i rozrywka na pokładzie\nWiększa prywatność, niezwykła przestrzenność, dyskretne wsparcie personelu pokładowego - podróż w klasie biznesowej " +
                "gwarantuje pełny odpoczynek podczas długiej podróży. A to wszystko na pokładzie innowacyjnych, zaawansowanych technologicznie samolotów Boeing 787 Dreamliner. " +
                "W naszych samolotach możesz zapomnieć o niewygodzie! Szerokie, rozkładane do pozycji leżącej fotele wraz z zestawem niezbędnych akcesoriów, jak miękkie koce i poduszki, " +
                "zapewniają doskonałe warunki zarówno do snu, jak i do pracy. Przyjazne oświetlenie LED oraz duże, przyciemniane okna, wprowadzają w stan głębokiego relaksu, minimalizując " +
                "objawy jet - lagu czyli zespołu nagłej zmiany strefy czasowej. W naszym Dreamlinerze poczujesz się jak w domu. Podróż z LOT to niekończące się inspiracje. Zapewnij sobie " +
                "dodatkową porcję przyjemności dzięki naszemu systemowi rozrywki pokładowej. Oferujemy Ci ponad 100 filmów i seriali(w tym produkcje polskie, angielskie / hollywoodzkie, " +
                "chińskie, rosyjskie, japońskie, koreańskie, węgierskie, niemieckie oraz bollywoodzkie), a także koncerty, utwory muzyczne, programy rozrywkowe i gry. Z nami pozostaniesz " +
                "online przez cały lot!\n\nWykwintne menu\nRejsy w LOT Business Class to prawdziwa uczta dla podniebienia! Delektuj się wykwintnymi potrawami, przygotowanymi przez " +
                "najlepszych szefów kuchni z wyselekcjonowanych, naturalnych składników. Poznaj smaki z różnych stron świata dzięki bogatemu menu. Serwowane na wysokiej jakości porcelanie, " +
                "na starannie nakrytym stole sprawią, że poczujesz się jak w eleganckiej restauracji. Jeszcze przed startem nasza załoga przywita Cię powitalnym drinkiem i drobną przekąską. " +
                "Po starcie otrzymasz menu z różnorodnym wyborem dań głównych podanych z sałatką i przystawką. Zamów ulubiony posiłek i rozkoszuj się kieliszkiem pierwszorzędnego wina. " +
                "W trakcie lotu skorzystasz również z szerokiej oferty deserów i serów, a przed samym lądowaniem zaprosimy Cię do degustacji drugiego posiłku. Posiłki w LOT Business Class " +
                "to doświadczenie jedyne w swoim rodzaju! W naszym menu, oprócz smakowitych dań, znajdziesz szeroki wybór win czerwonych, białych i różowych z różnych regionów świata," +
                " a także porto i szampana. Interesujesz się enoturystyką? Na pokładach naszych samolotów zasmakujesz w znakomitych winach z polskich winnic. " +
                "Zachęcamy do odkrywania nowych nut smakowych i aromatów! ";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 4.8 * Price * (passengers + children * 0.75);
        }
    }
}
