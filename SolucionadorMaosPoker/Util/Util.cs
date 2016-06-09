using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Util
{
    public class Utilities
    {
        public int ConverteNumeroCarta(char numero)
        {
            if (numero == 'A')
            {
                return 14;
            }
            else if (numero == 'K')
            {
                return 13;
            }
            else if (numero == 'Q')
            {
                return 12;
            }
            else if (numero == 'J')
            {
                return 11;
            }
            else if (numero == 'T')
            {
                return 10;
            }
            return int.Parse(numero.ToString());
        }
    }
}
