using System;
using System.Linq;

namespace ProgramacaoEstruturada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variáveis
            int remover = 0;
            int[] valoresInteiros = new int[10];
            string mensagem;
            #endregion
            ReceberValores(valoresInteiros);
            EncontrarMaiorValor(ref valoresInteiros);
            EncontrarMenorValor(valoresInteiros);
            EncontrarValorMedio(valoresInteiros);
            EncontrarTresMaioresValores(valoresInteiros);
            EncontrarValoresNegativos(valoresInteiros);
            MostrarValores(valoresInteiros);
            Console.WriteLine("Informe o valor que da sequência que deseja remover:");
            remover = int.Parse(Console.ReadLine());
            RemoverUmValor(valoresInteiros, remover);
        }
        #region Métodos
        private static void ReceberValores(int[] valoresInteiros)
        {
            for (int numero = 0; numero < 10; numero++)
            {
                Console.Write(">" + (numero + 1) + ": ");
                valoresInteiros[numero] = int.Parse(Console.ReadLine());
            }
        } // Ok
        static void EncontrarMaiorValor(ref int[] valoresInteiros)
        {
            MensagemInformativa("Maiores valores:", ConsoleColor.Green);
            Array.Sort(valoresInteiros);
            Array.Reverse(valoresInteiros);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Maior valor: " + valoresInteiros[i]);
            }
        } // Ok
        static void EncontrarMenorValor(int[] valoresInteiros)
        {
            MensagemInformativa("Menores valores:", ConsoleColor.Red) ;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Menores valores:");
            //Console.ResetColor();
            Array.Sort(valoresInteiros);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Menor valor: " + valoresInteiros[i]);
            }
        } // Ok
        static void EncontrarValorMedio(int[] valoresInteiros)
        {
            int somador = 0;
            int divisor = valoresInteiros.Length;
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                somador += valoresInteiros[i];
            }
            float media = somador / divisor;
            MensagemInformativa("Média dos valores:", ConsoleColor.DarkMagenta);
            Console.WriteLine("Media: " + media);
        } // Ok
        static void EncontrarTresMaioresValores(int[] valoresInteiros)
        {
            MensagemInformativa("Maiores valores: ", ConsoleColor.DarkYellow);
            Array.Sort(valoresInteiros);
            Array.Reverse(valoresInteiros);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i+1) + "º maior valor: "+ valoresInteiros[i]);
            }
        } // Ok
        static void EncontrarValoresNegativos(int[] valoresInteiros)
        {
            bool temNegativos = false;
            int[] valoresNegativos = new int[valoresInteiros.Length];
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                if(valoresInteiros[i] < 0)
                {
                    valoresNegativos[i] = valoresInteiros[i];
                }
            }
            Array.Sort(valoresNegativos);
            valoresNegativos = valoresNegativos.Where(T => T != 0).ToArray();
            for (int i = 0; i <= valoresNegativos.Length; i++)
            {
                if (valoresNegativos.Contains(i))
                {
                    temNegativos = true;
                    valoresNegativos[i] += valoresNegativos[i];
                }
            }
            if(temNegativos == true) {
                MensagemInformativa("Valores negativos: ", ConsoleColor.DarkRed);
                for (int i = 0; i < valoresNegativos.Length; i++)
                {
                    Console.WriteLine((i+1) + "º valor negativo: " + valoresNegativos[i]);
                }
            } else 
            {
                MensagemInformativa("Valores negativos: ", ConsoleColor.DarkRed);
                Console.WriteLine("Sem valores negativos nessa sequência!");
            }
        } // Ok
        static void MostrarValores(int[] valoresInteiros)
        {
            MensagemInformativa("Valores da sequência ordenada: ", ConsoleColor.DarkCyan);
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                Console.WriteLine((i+1) + "º valor da sequência: " + valoresInteiros[i]);
            }
        }
        static void RemoverUmValor(int[] valoresInteiros, int remover)
        {
            MensagemInformativa("Sequência após remover: ", ConsoleColor.DarkGray);
            Console.WriteLine("Item removido: " + remover);
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                Console.WriteLine((i + 1) + "º valor da sequência, após remover: " + remover);
            }
        }
        static void MensagemInformativa(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        #endregion
    }
}