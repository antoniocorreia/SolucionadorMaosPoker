using SolucionadorMaosPoker.Enum;
using SolucionadorMaosPoker.Jogos;
using SolucionadorMaosPoker.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SolucionadorMaosPoker
{
    class Program
    {
        public static CartaAlta cartaAlta = new CartaAlta();
        public static RoyalFlash royalFlash = new RoyalFlash();
        public static StraightFlush straightFlush = new StraightFlush();
        public static Quadra quadra = new Quadra();
        public static FullHouse fullhouse = new FullHouse();
        public static Flush flush = new Flush();
        public static Sequencia sequencia = new Sequencia();
        public static Trinca trinca = new Trinca();
        public static DoisPares doispares = new DoisPares();
        public static UmPar umpar = new UmPar();
        public static Utilities util = new Utilities();

        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch(); //melhor acuracia nos testes de performance

            int qtdVitoriasJogador1 = 0;

            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2); //usa o segundo core ou processador para o teste
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; //Previne que eventos de prioridade "Normal" interrompam threads
            Thread.CurrentThread.Priority = ThreadPriority.Highest;  //Previne threads de prioridade "Normal" interromperem esta thread


            stopwatch.Reset();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 1200) { } //fase de aquecimento de 1000-1500 mS para estabilizar a cache da CPU e pipeline 

            stopwatch.Stop();

            //for (int repeat = 0; repeat < 40; ++repeat)
            //{
            stopwatch.Reset();
            stopwatch.Start();
            
            try
            {
                qtdVitoriasJogador1 = SolucionadorMaosPoker();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }

            stopwatch.Stop();
            Console.WriteLine("Tempo gasto para execucao em segundos: " + stopwatch.ElapsedMilliseconds * 0.001);
            
            //}

            Console.WriteLine("Quantidade de vitorias do jogador 1: " + qtdVitoriasJogador1.ToString());
            Console.ReadLine();
        }

        public static int SolucionadorMaosPoker()
        {
            int qtdVitoriasJogador1 = 0;

            int qtdLinhas = 0;
            string linha;

            System.IO.StreamReader arquivo = new System.IO.StreamReader("c:/users/antonio/documents/visual studio 2015/Projects/SolucionadorMaosPoker/SolucionadorMaosPoker/pokerm.txt");
            while ((linha = arquivo.ReadLine()) != null)
            {
                List<Carta> cartas = linha.Split(' ').ToList().Select(x=> new Carta { Numero = x[0], Naipe = x[1]}).ToList();
                List<Carta> maoJogador1 = cartas.Take(5).ToList();
                List<Carta> maoJogador2 = cartas.Skip(5).Take(5).ToList();

                EnumJogos jogo1 = RetornaJogo(maoJogador1);
                EnumJogos jogo2 = RetornaJogo(maoJogador2);

                if((int)jogo1 > (int)jogo2)
                {
                    qtdVitoriasJogador1++;
                }
                else if ((int)jogo1 == (int)jogo2)
                {
                    if (Jogador1VenceDesempate(jogo1, maoJogador1, maoJogador2)) {
                        qtdVitoriasJogador1++;
                    }       
                }

                //Console.WriteLine(linha);
                qtdLinhas++;
            }

            arquivo.Close();
            //Console.WriteLine(qtdLinhas.ToString());




            return qtdVitoriasJogador1;
        }

        private static bool Jogador1VenceDesempate(EnumJogos jogo, List<Carta> maoJogador1, List<Carta> maoJogador2)
        {
            if(jogo == EnumJogos.RoyalFlash)
            {
                //cartas são iguais, então acontece empate
                return false;
            }
            else if (jogo == EnumJogos.StraightFlush)
            {
                return straightFlush.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.Quadra)
            {
                return quadra.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.FullHouse)
            {
                return fullhouse.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.Flush)
            {
                return flush.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.Sequencia)
            {
                return sequencia.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.Trinca)
            {
                return trinca.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.DoisPares)
            {
                return doispares.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else if (jogo == EnumJogos.UmPar)
            {
                return umpar.Jogador1Vence(maoJogador1, maoJogador2);
            }
            else
            {
                return cartaAlta.Jogador1Vence(maoJogador1, maoJogador2);
            }
        }

        private static EnumJogos RetornaJogo(List<Carta> maoJogador)
        {
            if (PossuiSequencia(maoJogador))
            {
                if (royalFlash.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.RoyalFlash;
                }
                else if (straightFlush.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.StraightFlush;
                }
                else
                    return EnumJogos.Sequencia;
            }
            else if (PossuiCartaIgual(maoJogador))
            {
                if (quadra.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.Quadra;
                }
                else if (fullhouse.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.FullHouse;
                }
                else if (trinca.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.Trinca;
                }
                else if (doispares.ExisteNaMao(maoJogador))
                {
                    return EnumJogos.DoisPares;
                }
                else
                    return EnumJogos.UmPar;
            }
            else if (flush.ExisteNaMao(maoJogador))
            {
                return EnumJogos.Flush;
            }
            else
                return EnumJogos.CartaAlta;
        }

        private static bool PossuiCartaIgual(List<Carta> maoJogador)
        {

            for(int i = 0; i < maoJogador.Count(); i++)
            {
                int j = 1;
                while(j < maoJogador.Count())
                {
                    if (j > i && (maoJogador[i].Numero == maoJogador[j].Numero))
                    {
                        return true;
                    }
                    j++;
                }
            }

            return false;

        }

        private static bool PossuiSequencia(List<Carta> maoJogador)
        {
            int[] numerosCartas = new int[5];
            for (int i = 0; i < maoJogador.Count(); i++){
                numerosCartas[i] = util.ConverteNumeroCarta(maoJogador[i].Numero);
            }

            Array.Sort(numerosCartas);
            
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

            if (numerosCartas[4] <= 14 && numerosCartas[0] >= 2)
            {
                for (int j = 0; j < numerosCartas.Length - 1; j += 1)
                {
                    if (numerosCartas[j + 1] - numerosCartas[j] != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
    }
}
