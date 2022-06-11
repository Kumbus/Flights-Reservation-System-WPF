namespace Projekt
{
    public class Emirates_EconomyPremium : Emirates
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Klasa ekonomiczna Premium";
        public Emirates_EconomyPremium(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Klasa ekonomiczna Premium " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa ekonomiczna Premium - nowa klasa ekonomiczna Premium jest dostępna w najnowszych samolotach linii Emirates. Czas odkryć nową strefę komfortu.\n\nZapraszamy do Twojej nowej strefy komfortu\nZapewnij sobie wyższy poziom wygody" +
                " i relaksu w naszej nowej klasie ekonomicznej Premium.Zapewniamy więcej przestrzeni i elegancką jadalnię urządzoną w wyszukanym stylu.\n\nWięcej miejsca na relaks\nOprzyj się wygodnie w szerszym fotelu z kremowej skóry i skorzystaj" +
                " z dodatkowego miejsca, by Twoje nogi mogły odpocząć na miękkim podnóżku.Regulowane podłokietniki i większy stopień odchylenia pozwolą Ci na przybranie maksymalnie komfortowej pozycji, zanim zaśniesz w delikatnym blasku nastrojowego górnego" +
                " oświetlenia. Przestronne fotele w klasie ekonomicznej Premium są usytuowane w przedniej części samolotu, dzięki czemu będziesz mieć pierwszeństwo wysiadania po wylądowaniu.\n\nWyjątkowa jadalnia\nPoznaj lokalne przysmaki dostępne" +
                " w naszych comiesięcznych regionalnych kartach dań, serwowane na porcelanowej zastawie Royal Doulton ze sztućcami ze stali nierdzewnej. Stolik z polerowanego, drewnopodobnego materiału można wygodnie złożyć obok siedzenia. " +
                "Dostępny jest też boczny stolik, na którym można postawić szklankę z ulubionym napojem. Oferujemy szeroki wybór napojów z listy, w tym doskonałe wina, które nie są serwowane w klasie ekonomicznej.\n\nUlepszona rozrywka\nKabina" +
                " w klasie ekonomicznej Premium wyposażona jest w najnowocześniejszy, ulepszony system rozrywki pokładowej z telewizorem HD o przekątnej 13,3 cala.Oferujemy tysiące filmów, programów telewizyjnych, albumów i innych programów. " +
                "Możesz również podłączyć do systemu własne słuchawki bezprzewodowe poprzez Bluetooth. Nasze samoloty są wyposażone jest również w szybki bezprzewodowy dostęp do Internetu.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 2.1 * Price * (passengers + children * 0.75);
        }
    }
}
