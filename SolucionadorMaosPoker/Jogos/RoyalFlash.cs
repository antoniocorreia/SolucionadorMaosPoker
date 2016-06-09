using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class RoyalFlash
    {
        private Utilities util = new Utilities();

        public bool ExisteNaMao(List<Carta> mao)
        {
            if (!util.CartasDoMesmoNaipe(mao))
                return false;

            int[] numerosCartas = new int[5];
            for (int i = 0; i < mao.Count(); i++)
            {
                numerosCartas[i] = util.ConverteNumeroCarta(mao[i].Numero);
            }

            Array.Sort(numerosCartas);

            if (numerosCartas[4] == 14 && numerosCartas[0] == 10)
            {
                for (int j = 0; j < numerosCartas.Length - 1; j += 1)
                {
                    if (numerosCartas[j + 1] - numerosCartas[j] != 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

      
    }
}
