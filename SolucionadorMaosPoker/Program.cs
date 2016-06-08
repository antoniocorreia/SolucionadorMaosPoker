using SolucionadorMaosPoker.Enum;
using SolucionadorMaosPoker.Jogos;
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
            Console.WriteLine("Tempo gasto para execução em segundos: " + stopwatch.ElapsedMilliseconds * 0.001);
            
            //}

            Console.WriteLine("Quantidade de vitorias do jogador 1: " + qtdVitoriasJogador1.ToString());
            Console.ReadLine();
        }

        public static int SolucionadorMaosPoker()
        {
            int qtdVitoriasJogador1 = 0;

            int qtdLinhas = 0;
            string linha;

            System.IO.StreamReader arquivo = new System.IO.StreamReader("c:/users/antonio/documents/visual studio 2015/Projects/SolucionadorMaosPoker/SolucionadorMaosPoker/pokerK.txt");
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

                Console.WriteLine(linha);
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
            //todo criar casos dos outros jogos
            else 
            {
                return cartaAlta.Jogador1Vence(maoJogador1,maoJogador2);
            }
        }

        private static EnumJogos RetornaJogo(List<Carta> maoJogador)
        {
            //todo completar método com jogos, checar do maior para o menor

            if (royalFlash.ExisteNaMao(maoJogador))
            {
                return EnumJogos.RoyalFlash;
            }
            else
            {
                return EnumJogos.CartaAlta;
            }
        }
    }
}
