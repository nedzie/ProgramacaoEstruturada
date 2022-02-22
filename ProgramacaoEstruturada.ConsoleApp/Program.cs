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
            int contadorNegativos = 0;
            int menorValor;
            bool temNegativos = false;
            #endregion
            ReceberValores(valoresInteiros);
            EncontrarMaiorValor(ref valoresInteiros);
            EncontrarMenorValor(valoresInteiros, out menorValor);
            EncontrarValorMedio(valoresInteiros);
            EncontrarTresMaioresValores(valoresInteiros);
            EncontrarValoresNegativos(valoresInteiros, contadorNegativos, temNegativos);
            MostrarValores(valoresInteiros);
            RemoverUmValor(valoresInteiros, remover);
            Console.ReadKey();
        }
        #region Métodos
        private static void ReceberValores(int[] valoresInteiros)
        {
            for (int numero = 0; numero < 10; numero++)
            {
                Console.Write(">" + (numero + 1) + ": ");
                valoresInteiros[numero] = int.Parse(Console.ReadLine());
            }
            Console.Clear();
        } // Ok
        static void EncontrarMaiorValor(ref int[] valoresInteiros)
        {
            MensagemInformativa("Maior valor:", ConsoleColor.Green);
            Array.Sort(valoresInteiros);
            Array.Reverse(valoresInteiros);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(valoresInteiros[i]);
            }
            Console.WriteLine();
        } // Ok
        static void EncontrarMenorValor(int[] valoresInteiros, out int menorValor)
        {
            menorValor = 0;
            MensagemInformativa("Menor valor:", ConsoleColor.Red);
            Array.Sort(valoresInteiros);
            menorValor = valoresInteiros[0];
            Console.WriteLine(menorValor);
            Console.WriteLine();
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
            Console.WriteLine(media);
            Console.WriteLine();
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
            Console.WriteLine();
        } // Ok
        static void EncontrarValoresNegativos(int[] valoresInteiros, int contadorNegativos, bool temNegativos)
        {  
            Array.Reverse(valoresInteiros);
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                if(valoresInteiros[i] < 0)
                {
                    temNegativos = true;
                }
            }
            if(temNegativos == true) { 
            MensagemInformativa("Valores negativos: ", ConsoleColor.DarkRed);
                foreach (int valor in valoresInteiros)
                {
                    if(valor < 0)
                    {
                        contadorNegativos++;
                    }
                }
                for (int i = 0; i < contadorNegativos; i++)
                {
                    Console.WriteLine(valoresInteiros[i]);
                }
            } else
            {
                MensagemInformativa("Sem números negativos nesse array", ConsoleColor.Red);
            }
            Console.WriteLine();
        } // Ok
        static void MostrarValores(int[] valoresInteiros)
        {
            Array.Reverse(valoresInteiros);
            MensagemInformativa("Valores da sequência ordenada: ", ConsoleColor.DarkCyan);
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                Console.WriteLine((i+1) + "º: " + valoresInteiros[i]);
            }
            Console.WriteLine();
        } // Ok
        static void RemoverUmValor(int[] valoresInteiros, int remover)
        {
            Console.WriteLine("Informe o valor que da sequência que deseja remover:");
            remover = int.Parse(Console.ReadLine());
            int iNovoArray = 0;
            int[] novoArray = new int[9];
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                if(valoresInteiros[i] != remover)
                {
                    novoArray[iNovoArray] = valoresInteiros[i];
                    iNovoArray++;
                }
            }
            Console.WriteLine("item removido: " + remover);
            Console.WriteLine();
            MensagemInformativa("Sequência após remover: ", ConsoleColor.DarkGray);
            for (int i = 0; i < novoArray.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + novoArray[i]);
            }
        }
        static void MensagemInformativa(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        } // Ok
        #endregion
    }
}