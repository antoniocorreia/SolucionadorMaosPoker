using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    

    public class DoisPares
    {
        private Utilities util = new Utilities();

        public Boolean ExisteNaMao (List<Carta> mao)
        {
            int existePar = 0;

            for (int i = 0; i < mao.Count; i++)
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

                if (qtd_numeros_iguais > 2)
                {
                    return false;
                }

                if (qtd_numeros_iguais == 2)
                {
                    existePar++;
                }
            }

            if (existePar == 2)
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
            int[] numeroCartasJogador1 = util.RetornaNumerosCartas(maoJogador1);
            Array.Sort(numeroCartasJogador1);
            int[] numeroCartasJogador2 = util.RetornaNumerosCartas(maoJogador2);
            Array.Sort(numeroCartasJogador2);

            int primeiroParJogador1 = 0;
            int segundoParJogador1 = 0;
            int numeroSobraJogador1 = 0;
            AtualizaNumeroParJogador(numeroCartasJogador1,ref primeiroParJogador1,ref segundoParJogador1,ref numeroSobraJogador1);

            int primeiroParJogador2 = 0;
            int segundoParJogador2 = 0;
            int numeroSobraJogador2 = 0;
            AtualizaNumeroParJogador(numeroCartasJogador2, ref primeiroParJogador2, ref segundoParJogador2, ref numeroSobraJogador2);

            if(segundoParJogador1 > segundoParJogador2)
            {
                return true;
            }
            else if(segundoParJogador2 > segundoParJogador1)
            {
                return false;
            }

            if (primeiroParJogador1 > primeiroParJogador2)
            {
                return true;
            }
            else if(primeiroParJogador2 > primeiroParJogador1)
            {
                return false;
            }

            if (numeroSobraJogador1 > numeroSobraJogador2)
            {
                return true;
            }

            return false;

        }

        private static void AtualizaNumeroParJogador(int[] numeroCartasJogador,ref int primeiroParJogador,ref int segundoParJogador, ref int numeroSobraJogador)
        {
            
            if (numeroCartasJogador[0] == numeroCartasJogador[1])
            {
                primeiroParJogador = numeroCartasJogador[0];
            }
            else
            {
                primeiroParJogador = numeroCartasJogador[1];
            }

            int pParJogador = primeiroParJogador;
            int[] cartasSemPrimeiroParJogador = numeroCartasJogador.Where(x => x != pParJogador).ToArray();

            if (cartasSemPrimeiroParJogador[0] == cartasSemPrimeiroParJogador[1])
            {
                segundoParJogador = cartasSemPrimeiroParJogador[0];
            }
            else
            {
                segundoParJogador = cartasSemPrimeiroParJogador[1];
            }
            int sParJogador = segundoParJogador;
            numeroSobraJogador = cartasSemPrimeiroParJogador.Where(x => x != sParJogador).First();


        }
    }
}
