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
            int funcionalidades = 0;
            bool temNegativos = false;
            #endregion

            ReceberValores(valoresInteiros);
            while(true)
            {
                funcionalidades = MenuDeFuncionalidades(funcionalidades);
                switch(funcionalidades) 
                { 
                    case 0:
                    EncontrarMaiorValor(ref valoresInteiros);
                        break;
                    case 1:
                    EncontrarMenorValor(valoresInteiros, out menorValor);
                        break;
                    case 2:
                    EncontrarValorMedio(valoresInteiros);
                        break;
                    case 3:
                    EncontrarTresMaioresValores(valoresInteiros);
                        break;
                    case 4:
                    EncontrarValoresNegativos(valoresInteiros, contadorNegativos, temNegativos);
                        break;
                    case 5:
                    MostrarValores(valoresInteiros);
                        break;
                    case 6:
                        valoresInteiros = RemoverUmValor(valoresInteiros, remover);
                        break;
                    case 7:
                        goto sair;
                }
            }
        sair:;
        }
        #region Métodos
        static int MenuDeFuncionalidades(int funcionalidades)
        {
            Console.Write("0 - Encontrar maior valor\n1 - Encontrar menor valor\n2 - Encontrar valor médio\n" +
                          "3 - Encontrar 3 maiores valores\n4 - Encontrar valores negativos\n5 - Mostrar todos os valores\n" +
                          "6 - Remover um valor\n7 - Sair\n");
            Console.WriteLine("Selecione uma das funcionalidades: ");
            funcionalidades = int.Parse(Console.ReadLine());
            return funcionalidades;
        }
        static void ReceberValores(int[] valoresInteiros)
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
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                if(valoresInteiros[i] < menorValor)
                {
                    menorValor = valoresInteiros[i];
                }
            }
            Console.WriteLine(menorValor);
            Console.WriteLine();
        } // Ok
        static void EncontrarValorMedio(int[] valoresInteiros)
        {
            Array.Sort(valoresInteiros);
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
        }
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
        }
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
        }
        static void MostrarValores(int[] valoresInteiros)
        {
            Array.Reverse(valoresInteiros);
            MensagemInformativa("Valores da sequência ordenada: ", ConsoleColor.DarkCyan);
            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                Console.WriteLine((i+1) + "º: " + valoresInteiros[i]);
            }
            Console.WriteLine();
        }
        static int[] RemoverUmValor(int[] valoresInteiros, int remover)
        {
            Console.WriteLine("Informe o valor que da sequência que deseja remover:");
            remover = int.Parse(Console.ReadLine());
            int contadorRemocoes = 0;
            int[] novoArray = new int[valoresInteiros.Length - 1]; // Obrigado José
            for (int y = 0; y < valoresInteiros.Length; y++)
            {
                if(remover == valoresInteiros[y])
                {
                    contadorRemocoes++;
                }
            }
            int[] posicoesDeremocao = new int[contadorRemocoes];
            if (contadorRemocoes > 1) { 
                int z = 0;
                
                for (int x = 0; x < valoresInteiros.Length; x++)
                {
                    if(remover == valoresInteiros[x])
                    {
                        posicoesDeremocao[z] = x;
                        z++;
                    }
                }
                Console.WriteLine("Foi encontrado o número " + remover + " nas seguintes posições do array: ");
                foreach (int h in posicoesDeremocao)
                {
                    Console.Write(h + ", ");
                }
                Console.WriteLine("Em qual das duas posições gostaria de remover?");
                int resposta = int.Parse(Console.ReadLine());
                remover = resposta;
                int posicao = 0;
                novoArray = new int[valoresInteiros.Length-1]; // Obrigado José
                for (int i = 0; i < valoresInteiros.Length; i++)
                {
                    if(i == remover)
                    {
                        continue;
                    } 
                    else {
                        novoArray[posicao] = valoresInteiros[i];
                        posicao++;
                    }
                }
                Console.WriteLine("item removido: " + remover);
                Console.WriteLine();
                MensagemInformativa("Sequência após remover: ", ConsoleColor.DarkGray);
                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + novoArray[i]);
                }
            } else
            {
                int posicao = 0;
                for(int i = 0; i < valoresInteiros.Length; i++)
                {
                    if (valoresInteiros[i] == remover)
                    {
                        continue;
                    }
                    else
                    {
                        novoArray[posicao] = valoresInteiros[i];
                        posicao++;
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
            return novoArray;
        }
        static void MensagemInformativa(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        } // Ok
        #endregion
    }
}