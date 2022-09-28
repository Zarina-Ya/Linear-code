using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearСode

{
    public class CreaterLinearBlock
    {
		private int k;
		private int n;
		private int wordCount;
		///private int t;
		private int d;
		private Matrix G;
		Matrix[] codeWord;

		public CreaterLinearBlock(int n, int k)
        {
			this.n = n;
			this.k = k;
			this.wordCount = (int)Math.Pow(2, k);
			this.G = new Matrix(k, n);
			G.GenerationRandomMatrix();
			PrintParameters();
			GenerationCodeWords();
			this.d = ToFindD();



			HammingBoundary(d);
			VarshamovGilbertBorder(d);
			SingletonBoundary(d);
		}
		void PrintParameters()
        {
			Console.WriteLine("N: " + n);
			Console.WriteLine("K: " + k);
			Console.WriteLine("Число кодовых слов данного кода: " + wordCount);
			Console.WriteLine("G:" );
			Console.WriteLine( G);
		}
		void GenerationCodeWords()
		{
			codeWord = new Matrix[wordCount];
			for (int i = 0; i < wordCount; i++)
			{
				String s = i.ToString();
				s = Shift(ConvertIntToString(s), k);
				Matrix word = new Matrix(s);
				codeWord[i] = word.Multi(this.G);
				Console.WriteLine(s + " = " + "[" + codeWord[i] + "]");
			}
		}

		int ToFindD()
        {
			int min = n + 1;
			for (int i = 1; i < this.wordCount; i++)
			{

				int d_min = codeWord[i].BitCountNew();
				if (d_min < min)
				{
					min = d_min;
				}

			}
			Console.WriteLine("Минимальное расстояние кода: " + min);
			return min;

		}

		public String ConvertIntToString(String s)
		{
			int from = 10;
			int to = 2;
			return Convert.ToString(Convert.ToInt32(s, from), to);
		}

		private String Shift(String s, int size)
		{
			StringBuilder res = new StringBuilder();
			for (int i = 0; i < size - s.Length; i++)
				res.Append("0");
			
			res.Append(s);
			return res.ToString();
		}


		public void HammingBoundary(int d)
		{

			double d_min = (double)d;

			int t = (int)Math.Floor((d_min - 1) / 2);// корректирующая способность.

			double hamming = Math.Pow(2, n) / SumC(t) /*Math.Log(SumC( t), 2)*/;



			Console.WriteLine(" HammingBoundary " + hamming.ToString());


			Console.WriteLine(" На сколько полученные параметры далеки от границ существования(Хемминга) : " + (hamming - (double)wordCount).ToString());
			Console.WriteLine();


		}

		//n!k!(n−k)!
		long SumC(int t)
		{



			
			long sum = 0;




			for(int i = 0; i <= t ; i++)
            {
				long a = Fact(i);
				long b = (Fact(n - i));
				long c = (Fact(n));
				long d = (c / (a * b));
				sum += d;
			}
			//if (t == 0)
			//{
			//	for (int i = 0; i <= t; i++)
			//	{
			//		long a = Fact(i);
			//		long b = (Fact(n - i));
			//		long c = (Fact(n));
			//		long d = (c / (a * b));
			//		sum += d;
			//	}
			//}
			//else
			//{
			//	for (int i = 0; i < t; i++)
			//	{
			//		long a = Fact(i);
			//		long b = (Fact(n - i));
			//		long c = (Fact(n));
			//		long d = (c / (a * b));
			//		sum += d;
			//	}
			//}
			Console.WriteLine(sum);


			return sum;
		}


		long SumCGilbert(int t)
		{




			long sum = 0;




			for (int i = 0; i <=t ; i++)
			{
				long a = Fact(i);
				long b = (Fact(n - i));
				long c = (Fact(n));
				long d = (c / (a * b));
				sum += d;
			}


			Console.WriteLine(sum);
			return sum;
		}


        public long GetFact(long val)
        {
			long a = Fact(val);
			long b = (Fact(n - val));
			long c = (Fact(n));
			return (c / (a * b));
		}


        public long Fact(long n)
		{
			if (n == 0)
				return 1;
			else
				return n * Fact(n - 1);
		}
		void VarshamovGilbertBorder(int d)
		{
			int t = d - 1;
			double varshamov = /*Math.Log(SumC(t), 2)*/(double)Math.Pow(2, n) / SumCGilbert(t);

			Console.WriteLine(" VarshamovGilbertBorder " + varshamov.ToString());
			

			Console.WriteLine(" На сколько полученные параметры далеки от границ существования( Варшамова - Гилберта ) : " + (varshamov - (double)wordCount).ToString());


			//// НИже графницы и выше границ и пояснение о том что это значит о качесиве кода, даже если получили Бк 
			Console.WriteLine();
		}


		// qn – (d – 1).
		void SingletonBoundary(int d)
		{
			double singleton = Math.Pow(2, n - d + 1); /*n - d + 1*/;
			Console.WriteLine(" SingletonBoundary " + singleton.ToString());
			

			Console.WriteLine(" На сколько полученные параметры далеки от границ существования(Синглтона) : " + (singleton - (double)wordCount).ToString());
			Console.WriteLine();

		}
	}
}

//... среда либо до 13 , либо после 14 до 18 , в четверг тоже можно с 14 - 15 и не больше 
//	пятницв весь день  и для за 3 до экзамена лучше уточнять 