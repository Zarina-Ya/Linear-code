using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearСode
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int k = 3;// Ennter
            int n = 15;//Exit 10

            CreaterLinearBlock block = new CreaterLinearBlock(n, k);
            //int d = 5;// минимальное расстояние
            //LinearBlockCode lbc = new LinearBlockCode(k, n);

            //Console.WriteLine( lbc);
            //lbc.minDistance();


            //lbc.GetAllDistance();
            // lbc.NewMinDistanceForD();

            //Console.ReadLine();
            ////Console.WriteLine(lbc.isContains("0101100000"));
            ////Console.WriteLine(lbc.isContains("0000011001"));
            ////Console.ReadLine();



            Console.ReadLine();
        }
    }
}
