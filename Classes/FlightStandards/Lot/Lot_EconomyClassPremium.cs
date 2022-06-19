namespace Projekt
{ 
    public class Lot_EconomyClassPremium : Lot
    {
        public Lot_EconomyClassPremium(BasicFlight bf) : base(bf)
        {
            Name = "Economy Class Premium";
            NameAndPrice = "Economy Class Premium " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

    public override string Describe()
    {
            return "LOT Premium Economy\n\nWiększy bagaż, wygodniejsze fotele, więcej usług dodatkowych - LOT Premium Economy to nowoczesna klasa podróży gwarantująca idealny " +
                "wypoczynek nie tylko podczas lotu.A wszystko w bardzo przystępnej cenie. Skorzystaj z wyjątkowych udogodnień podczas podróży Dreamlinerem!\n\n" +
                "Relaks przed podróżą\nPodróż klasą ekonomiczną premium LOT może być przyjemnością już na lotnisku. Z biletem w LOT Premium Economy możesz wykupić dostęp do saloników " +
                "biznesowych na lotnisku.\n\nPriorytetowa obsługa na lotnisku\nJako Pasażerowi klasy LOT Premium Economy przysługuje Ci priorytetowy check-in w dedykowanej strefie odpraw, " +
                "fast track na Lotnisku Chopina w Warszawie oraz możliwość wejścia na pokład samolotu w dowolnym momencie. Jako pierwszy możesz również odebrać swój bagaż tuż po lądowaniu." +
                " Do Twojej dyspozycji oddajemy dedykowaną linię premium w LOT Contact Center oraz LOT Transfer Center.\n\nWiększy bagaż\nNa wszystkich trasach w LOT Premium Economy " +
                "przysługuje Ci wyższy limit bagażowy. Zabierzesz ze sobą 2 x 23 kg sztuki bagażu rejestrowanego.\n\nKomfort i rozrywka na pokładzie\nDbamy o to, aby sama podróż była " +
                "przyjemnością, a nie tylko jej cel. Właśnie dlatego na trasy międzykontynentalne zabierzemy Cię naszym Dreamlinerem - jednym z najnowocześniejszych, " +
                "najbardziej komfortowych samolotów świata.Podróż Dreamlinerem to czysta przyjemność - wypoczynek i błogi relaks nawet na kilkugodzinnych rejsach gwarantowany!" +
                "Wszystkie fotele w naszych Dreamlinerach wyposażone są w gniazdko elektryczne, port USB i indywidualny system rozrywki pokładowej. W samolocie zamontowane zostało " +
                "oświetlenie typu LED oraz zaciemniane okna, których zadaniem jest minimalizowanie tzw. jet - lagu. Wygodny fotel o szerokości 50 cm z regulowanymi zagłówkami i podnóżkami, " +
                "wraz z zestawem niezbędników, zapewniają idealne warunki do wypoczynku.Podczas rejsów możesz skorzystać również z szerokiej oferty rozrywki pokładowej - do Twojej dyspozycji" +
                " oddajemy ponad 100 filmów i seriali(w tym produkcje inspirowane krajami, do których latamy), a także koncerty, audiobooki, programy rozrywkowe oraz gry.\n\n" +
                "Menu LOT Premium Economy\nMenu w LOT Premium Economy skomponowane zostało przez naszych najlepszych szefów kuchni. Smaczne potrawy, przygotowane wyłącznie z najlepszych " +
                "składników, serwowane na wysokiej jakości porcelanie sprawią, że poczujesz się jak w eleganckiej restauracji. Zapewniamy niezwykłe doznania kulinarne, proponując nie tylko " +
                "dania kuchni międzynarodowej, ale również regionalnej.Jeszcze przed startem nasza załoga przywita Cię powitalnym drinkiem. Po starcie otrzymasz danie główne podane z sałatką" +
                ", przystawką oraz deserem, rozkoszując się przy tym kieliszkiem dobrego wina. Przed lądowaniem natomiast dostarczymy Ci kolejny smakowity posiłek, który pomoże nabrać sił " +
                "przed końcem podróży. Do naszego menu wybieramy najlepsze wina z różnych regionów świata, oceniając ich jakość oraz bogactwo smaku i aromatu.Na pokładzie naszych samolotów " +
                "znajdziesz również doskonałe wina z polskich winnic.Białe czy czerwone? Wytrawne czy półsłodkie? Wybór należy do Ciebie!";
    }

        public override double GetPrice(int passengers, int children)
        {
            return 1.8 * Price * (passengers + children * 0.90);
        }
    }
}
