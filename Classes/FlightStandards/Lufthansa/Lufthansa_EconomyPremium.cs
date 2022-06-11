namespace Projekt
{
    public class Lufthansa_EconomyPremium : Lufthansa
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Klasa Ekonomiczna Premium";
        public Lufthansa_EconomyPremium(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Klasa Ekonomiczna Premium " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa Ekonomiczna Premium\nWięcej miejsca dla siebie, większy limit bezpłatnego bagażu, bogatszy serwis – podczas rejsów Klasa Ekonomiczna Premium " +
                "zapewnia wysoki komfort. Dzięki temu możesz cieszyć się wygodną podróżą w wybranym kierunku, a zaraz po przyjeździe możesz rozpocząć zwiedzanie" +
                " lub udać się na spotkanie biznesowe.\n\nPrzestrzeń osobista\nPodróżujesz w przestronnym i wygodnym fotelu zapewniajacym do 50 % więcej przestrzeni" +
                " ze wszystkich stron. A co najlepsze: nie tylko Ty będziesz miał swoją strefę komfortu, odpowiednie miejsce znajdzie się również na Twój napój – dzięki" +
                " niewielkiemu stolikowi na podłokietniku.\n\nRelaks\nRozkoszuj się podróżą pełną relaksu.Praktyczny zestaw podróżny, który znajdziesz przy swoim" +
                " fotelu, pomoże Ci odświeżyć się przed przylotem.\n\nRozrywka\nCiesz się bogatym programem rozrywki na pokładzie na naszych 11 - lub 12 - calowych ekranach," +
                " relaksując się w naszych przestronnych fotelach.\n\nPrzyjemności\nWitając Cię w Klasie Ekonomicznej Premium, podajemy bezalkoholowy powitalny napój. " +
                "Dodatkowo, na każdym miejscu czeka butelka wody. Spokojnie wybierz dania z menu i delektuj się znakomitym posiłkiem serwowanym na porcelanie.\n\nDostęp do " +
                "saloników\nMożesz, za opłatą, odwiedzić większość saloników Lufthansa Business Lounge oraz Lufthansa Welcome Lounge we Frankfurcie. Vouchery można " +
                "otrzymać przy stanowisku obsługi Lufthansy, a we Frankfurcie i Monachium bezpośrednio przy wejściu do saloniku.\n\nBezpłatny bagaż\nW ramach bezpłatnego " +
                "limitu możesz nadać dwie sztuki bagażu ważące do 23 kg każda  – dwukrotnie więcej, niż podróżując Klasą Ekonomiczną.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 1.5 * Price * (passengers + children * 0.75);
        }
    }
}
