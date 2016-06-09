using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class Sequencia
    {
        private Utilities util = new Utilities();

        public Boolean ExisteNaMao (List<Carta> mao)
        {
            int[] numerosCartas = util.RetornaNumerosCartas(mao);

            Array.Sort(numerosCartas);


            //Caso venha A e na ordenação o primeiro número seja 2, pode acontecer sequencia com A(14) 2 3 4 5, então substitui o 14 por 1
            if (numerosCartas[4] == 14 && numerosCartas[0] == 2)
            {
                int[] cartasAsComoUm = numerosCartas;
                cartasAsComoUm[4] = 1;
                Array.Sort(cartasAsComoUm);
                for (int j = 0; j < cartasAsComoUm.Length - 1; j++)
                {
                    if (cartasAsComoUm[j + 1] - cartasAsComoUm[j] != 1)
                    {
                        return false;
                    }
                }
                return true;
            }

            for (int j = 0; j < numerosCartas.Length - 1; j++)
            {
                if (numerosCartas[j + 1] - numerosCartas[j] != 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Jogador1Vence (List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            int[] numerosCartasJogador1 = util.RetornaNumerosCartas(maoJogador1);
            Array.Sort(numerosCartasJogador1);

            int[] numerosCartasJogador2 = util.RetornaNumerosCartas(maoJogador2);
            Array.Sort(numerosCartasJogador2);

            if(numerosCartasJogador1[0] == numerosCartasJogador2[0])
            {
                return false;
            }

            int i = 4;
            while (i >= 0)
            {
                if (numerosCartasJogador1[i] > numerosCartasJogador2[i])
                {
                    return true;
                }
                else if (numerosCartasJogador2[i] > numerosCartasJogador1[i])
                {
                    return false;
                }
                i--;
            }

            return false;
        }
    }
}
