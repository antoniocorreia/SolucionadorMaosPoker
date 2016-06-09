using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class CartaAlta
    {
        private Utilities util = new Utilities();

        public bool Jogador1Vence(List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            int[] numerosCartasJogador1 = util.RetornaNumerosCartas(maoJogador1);
            int[] numerosCartasJogador2 = util.RetornaNumerosCartas(maoJogador2);
            Array.Sort(numerosCartasJogador1);
            Array.Sort(numerosCartasJogador2);

            int i = 4;
            while (i >= 0)
            {
                if(numerosCartasJogador1[i] > numerosCartasJogador2[i])
                {
                    return true;
                }
                else if(numerosCartasJogador2[i] > numerosCartasJogador1[i])
                {
                    return false;
                }
                i--;
            }

            return false;
        }
    }
}
