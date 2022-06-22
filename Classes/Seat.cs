namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca fotel w samolocie
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Właściwość, która odpowiada czy fotel jest zajęty(false) czy wolny(true)
        /// </summary>
        public bool Free { get; set; } 
        /// <summary>
        /// Właściwość odpowiadakąca czy fotel w oknie wyboru miejsc jest naciśnięty czy nie 
        /// </summary>
        public bool Clicked { get; set; } = false;
        /// <summary>
        /// Numer siedzenia
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Klasa podróży w jakiej znajduje się fotel
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Przypisuje nazwę na podstawie lini lotniczej i numeru siedzenia
        /// </summary>
        /// <param name="name">Linia lotnicza</param>
        public void SetClass(string name)
        {
            switch(name)
            {
                case "Lot":
                    {
                        switch(Number[0])
                        {
                            case 'E':
                                {
                                    Class = "Economy Class";
                                    break;
                                }
                            case 'P':
                                {
                                    Class = "Economy Class Premium";
                                    break;
                                }
                            case 'B':
                                {
                                    Class = "Business Class";
                                    break;
                                }
                        }
                        break;
                    }
                case "RyanAir":
                    {
                        switch (Number[0])
                        {
                            case 'E':
                                {
                                    Class = "Value";
                                    break;
                                }
                            case 'P':
                                {
                                    Class = "Regular";
                                    break;
                                }
                            case 'B':
                                {
                                    Class = "Plus";
                                    break;
                                }
                            case 'F':
                                {
                                    Class = "FlexiPlus";
                                    break;
                                }
                        }
                        break;
                    }
                case "Emirates":
                    {
                        switch (Number[0])
                        {
                            case 'E':
                                {
                                    Class = "Klasa ekonomiczna";
                                    break;
                                }
                            case 'P':
                                {
                                    Class = "Klasa ekonomiczna Premium";
                                    break;
                                }
                            case 'B':
                                {
                                    Class = "Klasa biznes";
                                    break;
                                }
                            case 'F':
                                {
                                    Class = "Pierwsza klasa";
                                    break;
                                }
                        }
                        break;
                    }
                case "Lufthansa":
                    {
                        switch (Number[0])
                        {
                            case 'E':
                                {
                                    Class = "Klasa Ekonomiczna";
                                    break;
                                }
                            case 'P':
                                {
                                    Class = "Klasa Ekonomiczna Premium";
                                    break;
                                }
                            case 'B':
                                {
                                    Class = "Klasa Biznes";
                                    break;
                                }
                            case 'F':
                                {
                                    Class = "Klasa Pierwsza";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
    }
}
