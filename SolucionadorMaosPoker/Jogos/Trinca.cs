using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class Trinca
    {
        private Utilities util = new Utilities();

        public Boolean ExisteNaMao (List<Carta> mao)
        {
            int existeTrinca = 0;
            int existePar = 0;
            char cartaTrinca = ' '; //cartaTrinca serve para salvar o numero correspondente a trinca, para que o mesmo não contabilize um par depois

            for (int i = 0; i < mao.Count(); i++)
            {
                int j = i + 1;
                int qtd_numeros_iguais = 1;
            
                while (j < mao.Count())
                {
                    if (mao[i].Numero == mao[j].Numero)
                    {
                        qtd_numeros_iguais++;
                    }
                    j++;
                }

                if (qtd_numeros_iguais > 3)
                {
                    return false;
                }

                if (qtd_numeros_iguais == 2 && (mao[i].Numero != cartaTrinca))
                {
                    existePar++;
                }

                if (qtd_numeros_iguais == 3)
                {
                    existeTrinca++;
                    cartaTrinca = mao[i].Numero;
                }
            }

            if (existeTrinca == 1 && existePar == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Jogador1Vence (List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            int numeroTrincaJogador1 = ExtraiNumeroTrinca(maoJogador1);
            int numeroTrincaJogador2 = ExtraiNumeroTrinca(maoJogador2);

            if(numeroTrincaJogador1 > numeroTrincaJogador2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private int ExtraiNumeroTrinca(List<Carta> maoJogador)
        {
            int[] numeroCartasJogador = util.RetornaNumerosCartas(maoJogador);
            Array.Sort(numeroCartasJogador);

            int numeroTrincaJogador;
           
            //Ex.: 2 3 3 3 4 ou 2 2 2 3 4
            if (numeroCartasJogador[1] == numeroCartasJogador[2])
            {
                numeroTrincaJogador = numeroCartasJogador[1];
            }
            else
            {
                //Ex.: 2 3 4 4 4
                numeroTrincaJogador = numeroCartasJogador[2];
            }

            return numeroTrincaJogador;
        }
    }
}
