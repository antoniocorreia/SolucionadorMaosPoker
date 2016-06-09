using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class Quadra
    {
        private Utilities util = new Utilities();

        public Boolean ExisteNaMao (List<Carta> mao)
        {
            for (int i = 0; i < mao.Count; i++)
            {
                int j = i + 1;
                int qtd_numeros_iguais = 1;
                while (j < mao.Count())
                {
                    if (mao[i].Numero == mao[j].Numero)
                    {
                        qtd_numeros_iguais += 1;
                    }
                    j += 1;
                }
                
                if (qtd_numeros_iguais == 4)
                {
                    return true;
                }

            }
            return false;
        }

        public bool Jogador1Vence (List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            int numeroQuadraJogador1 = ExtraiNumeroQuadra(maoJogador1);
            int numeroQuadraJogador2 = ExtraiNumeroQuadra(maoJogador2);

            if(numeroQuadraJogador1 > numeroQuadraJogador2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int ExtraiNumeroQuadra(List<Carta> maoJogador)
        {
            int[] numeroCartasJogador = util.RetornaNumerosCartas(maoJogador);
            Array.Sort(numeroCartasJogador);
            int numeroQuadraJogador;
            //Caso em que o numero da quadra é menor que a outra carta na mão
            //Ex.: 4 4 4 4 5
            if (numeroCartasJogador[0] == numeroCartasJogador[1])
            {
                numeroQuadraJogador = numeroCartasJogador[0];
            }
            else
            {
                //Caso em que o número da quadra é maior que a outra carta na mão
                //Ex.: 2 3 3 3 3
                numeroQuadraJogador = numeroCartasJogador[1];
            }

            return numeroQuadraJogador;
        }
    }
}
