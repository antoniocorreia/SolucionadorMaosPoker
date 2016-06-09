using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class FullHouse
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

            if (existeTrinca == 1 && existePar == 1)
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
            int numeroTrincaJogador1 = (int)RetornaNumeroTrinca(maoJogador1);
            int numeroTrincaJogador2 = (int)RetornaNumeroTrinca(maoJogador2);

            if(numeroTrincaJogador1 > numeroTrincaJogador2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int? RetornaNumeroTrinca(List<Carta> maoJogador)
        {
            for (int i = 0; i < maoJogador.Count(); i++)
            {
                int qtd_numeros_iguais = 1;
                int j = i + 1;

                while (j < maoJogador.Count())
                {
                    if (maoJogador[i].Numero == maoJogador[j].Numero)
                    {
                        qtd_numeros_iguais++;
                    }

                    if (qtd_numeros_iguais == 3)
                    {
                        return util.ConverteNumeroCarta(maoJogador[i].Numero);
                    }
                    j++;
                }
            }

            return null;
        }
    }
}
