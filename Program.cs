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
            int[] RAs = new int[7];

            RAs[0] = 111;
            RAs[1] = 112;
            RAs[2] = 113;
            RAs[3] = 114;
            RAs[4] = 115;
            RAs[5] = 116;
            RAs[6] = 117;

            string[] duplas = CriarDuplas(RAs);

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
    }
}
