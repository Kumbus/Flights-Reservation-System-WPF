
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Seat
    {
        public bool Free { get; set; } 

        public bool Clicked { get; set; } = false;

        public string Number { get; set; }

        public string Class { get; set; }


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
