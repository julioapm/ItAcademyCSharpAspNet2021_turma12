using System;

namespace Laboratorio2cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            array = new int[5] {10, 20, 30, 40, 50};
            array[2] = 300;
            for(int i=0; i<array.Length; i++)
            {
                Console.WriteLine("Indice = " + i + " & valor = " + array[i]);
            }

            string[] str = new string[3];
            str[0] = "Um";
            str[1] = "Dois";
            str[2] = "Tres";
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }

            DateTime[] dt = new DateTime[2];
            dt[0] = DateTime.Now;
            dt[1] = new DateTime(2021,5,17);
            Console.WriteLine(dt[1]);

            int[,] array2 = new int[4, 2];
            array2[2,1] = -1;
            Console.WriteLine(array2[2,1]);
            Console.WriteLine(array2.Length);
            Console.WriteLine(array2.Rank);

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
        }
    }
}
