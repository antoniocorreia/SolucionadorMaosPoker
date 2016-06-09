using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class UmPar
    {
        private Utilities util = new Utilities();
        //
        public Boolean ExisteNaMao(List<Carta> mao)
        {
            int ExistePar = 0;

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
                if (qtd_numeros_iguais > 2)
                {
                    return false;
                }
                if (qtd_numeros_iguais == 2)
                {
                    ExistePar++;
                }

            }

            if (ExistePar == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Jogador1Vence(List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            int numeroParJogador1 = (int)ExtraiNumeroPar(maoJogador1);
            int numeroParJogador2 = (int)ExtraiNumeroPar(maoJogador2);

            if(numeroParJogador1 > numeroParJogador2)
            {
                return true;
            }
            else if(numeroParJogador2 > numeroParJogador1)
            {
                return false;
            }
            else
            {
                int[] cartasForaParJogador1 = util.RetornaNumerosCartas(maoJogador1).Where(x=>x != numeroParJogador1).ToArray();
                int[] cartasForaParJogador2 = util.RetornaNumerosCartas(maoJogador1).Where(x => x != numeroParJogador2).ToArray();

                Array.Sort(cartasForaParJogador1);
                Array.Sort(cartasForaParJogador2);

                int i = 2;
                while(i >= 0)
                {
                    if(cartasForaParJogador1[i] > cartasForaParJogador2[i])
                    {
                        return true;
                    }
                    else if(cartasForaParJogador2[i] > cartasForaParJogador1[i])
                    {
                        return false;
                    }

                    i--;
                }
                return false;
            }

        }

        private int? ExtraiNumeroPar(List<Carta> maoJogador)
        {
            //aqui já sabemos que a maoJogador tem um par, então não precisamos checar, apenas queremos o número das cartas do par.
            for (int i = 0; i < maoJogador.Count(); i++)
            {
                int j = i + 1;
                int qtd_numeros_iguais = 1;

                while (j < maoJogador.Count())
                {
                    if (maoJogador[i].Numero == maoJogador[j].Numero)
                    {
                        qtd_numeros_iguais++;
                    }

                    j++;
                }
                
                if (qtd_numeros_iguais == 2)
                {
                    return util.ConverteNumeroCarta(maoJogador[i].Numero);
                }

            }

            return null;

        }
    }
}
