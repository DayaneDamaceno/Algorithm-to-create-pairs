using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio01_FormarDuplas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numAlunos = ValidaInt("Quantos alunos tem na turma?");
            int[] RAs = new int[numAlunos];

            for (int i = 0; i < RAs.Length; i++)
            {
                RAs[i] = ValidaInt($"RA do {i + 1}º aluno:");
            }

            string[] duplas = CriarDuplas(RAs);
            Console.WriteLine("\nDuplas:");

            foreach (var dupla in duplas)
            {
                Console.WriteLine(dupla);
            }

            Console.ReadKey();
        }
        
        static string[] CriarDuplas(int[] RAs)
        {
            string[] duplas = new string[RAs.Length / 2];

            int[] numerosAleatorios = GerarArrayAleatorio(RAs.Length);

            int i = 0;
            int n = 0;

            if (RAs.Length % 2 != 0)
            {
                duplas[0] = $"{RAs[numerosAleatorios[0]]}, {RAs[numerosAleatorios[1]]}, {RAs[numerosAleatorios[2]]}";
                i = 1;
                n = 3;
            }

            while (i < duplas.Length)
            {
                duplas[i] = $"{RAs[numerosAleatorios[n]]}, {RAs[numerosAleatorios[n + 1]]}";

                n = n + 2;
                i++;
            }


            return duplas;
        }
        
        static int[] GerarArrayAleatorio(int valorMax)
        {
            Random gerador = new Random();

            int[] numerosAleatorios = new int[valorMax];

            for (int n = 0; n < numerosAleatorios.Length; n++)
            {
                bool existe;
                do
                {
                    existe = false;
                    numerosAleatorios[n] = gerador.Next(0, valorMax);
                    for (int p = 0; p < n; p++)
                    {
                        if (numerosAleatorios[p] == numerosAleatorios[n])
                        {
                            existe = true;
                            break;
                        }
                    }
                }
                while (existe);
            }

            return numerosAleatorios;
        }

        static int ValidaInt(string mensagem)
        {
            int valor = -1;
            do
            {
                try
                {
                    Console.Write(mensagem);
                    valor = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nPor favor digite apenas números, maiores que 0!!\n");

                }
            } while (valor <= 0);

            return valor;
        }
    }
}
