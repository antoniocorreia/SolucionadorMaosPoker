using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionadorMaosPoker.Jogos
{
    public class StraightFlush 
    {
        public Boolean ExisteNaMao (List<Carta> mao)
        {
            

	 if (!util.CartasDoMesmoNaipe(mao))
                return false;
            
            int[] numerosCartas = util.RetornaNumerosCartas(mao);
            
            Array.Sort(numerosCartas);

	
//Caso venha A e na ordenação o primeiro número seja 2, pode acontecer sequencia com A(14) 2 3 4 5, então substitui o 14 por 1

            if (numerosCartas[4] == 14 && numerosCartas[0] == 2)
            {
                int[] cartasAsComoUm = numerosCartas;
                cartasAsComoUm[4] = 1;
                Array.Sort(cartasAsComoUm);
                for (int j = 0; j < cartasAsComoUm.Length - 1; j += 1)
                {
                    if (cartasAsComoUm[j + 1] - cartasAsComoUm[j] != 1)
                    {
                        return false;
                    }
                }
                return true;
            }

//caso não entre no if acima ele checa se é uma sequencia qualquer
            for (int j = 0; j < numerosCartas.Length - 1; j += 1)
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
           //Aqui já sabemos que os jogos são straight então a gente só compara a maior carta de cada um
            int[] numerosCartasJogador1 = util.RetornaNumerosCartas(maoJogador1);
            
            Array.Sort(numerosCartasJogador1);

int[] numerosCartasJogador2 = util.RetornaNumerosCartas(maoJogador2);
            
            Array.Sort(numerosCartasJogador2);

	//pronto, agora compara só os elementos [4] de cada um, ai no caso tem que checar se o jogador 1 vence
	  int i = 4;
            while(i >= 0){
                if(numerosCartasJogador1[i] > numerosCartasJogador2[i])
                {
                    return true;
                }

                if(numerosCartasJogador2[i] > numerosCartasJogador1[i])
                {
                    return false;
                }

                i--;
            }
            return false;
        }
    } 
}
