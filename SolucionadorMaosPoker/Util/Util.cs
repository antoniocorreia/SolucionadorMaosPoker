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

        public bool CartasDoMesmoNaipe(List<Carta> mao)
        {
            //Checa se cartas são do mesmo naipe
            char naipeAnterior = ' ';
            foreach (var carta in mao)
            {
                if (naipeAnterior == ' ')
                {
                    naipeAnterior = carta.Naipe;
                }
                else
                {
                    if (naipeAnterior != carta.Naipe)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int[] RetornaNumerosCartas(List<Carta> mao)
        {
            int[] numerosCartas = new int[5];
            for (int i = 0; i < mao.Count(); i++)
            {
                numerosCartas[i] = ConverteNumeroCarta(mao[i].Numero);
            }
            return numerosCartas;
        }
        
    }
}
