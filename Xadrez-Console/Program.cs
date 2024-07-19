using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez part = new PartidaDeXadrez();
                
                while (!part.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(part.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + part.turno);
                        Console.WriteLine("Aguardando jogada: " + part.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        part.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = part.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(part.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        part.validarPosicaoDeDestino(origem, destino);

                        part.realizaJogada(origem, destino);
                    }
                    catch ( TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch( TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            //rçklgfdrtgbksuyrtwiiwufygioweuyto
            Console.ReadKey();
        }
    }
}
