using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearСode
{
    public class LinearBlockCode
    {
		private int k;
		private int n;

		private int wordCount;
		private Matrix G;
		//private Matrix H;
		Matrix[] codeWord;

		public LinearBlockCode(int k, int n)
		{
			this.n = n;
			this.k = k;
			this.wordCount = (int)Math.Pow(2, k);
			this.G = new Matrix(k, n);
			this.G.GenerationRandomMatrix();

			//this.HMatrixGenerate();
			CodeClovo();
		}

		//private void HMatrixGenerate()
		//{
		//	int h = this.n - this.k;
		//	int w = this.n;
		//	this.H = new Matrix(h, w);
		//	for (int i = 0; i < h; i++)
		//	{
		//		this.H.Array[i, w - h + i] = 1;
			
		//	}
		//	Matrix tmp = this.G.T();
		//	for (int i = 0; i < h; i++)
		//	{
		//		for (int j = 0; j < w - h; j++)
		//		{
		//			this.H.Array[i, j] = tmp.Array[i + this.k, j];
		//		}
		//	}
		//}

		private String zeroAdder(String s, int size)
		{
			StringBuilder res = new StringBuilder();
            for (int i = 0; i < size - s.Length; i++)
            {
                res.Append("0");
            }
            res.Append(s);
            return res.ToString();
        }

		public String ConvertIntToString(String s)
        {
            int from = 10;
            int to = 2;
            return Convert.ToString(Convert.ToInt32(s, from), to);
        }



		void CodeClovo()
        {
			codeWord = new Matrix[wordCount];
			for(int i = 0; i < wordCount; i++)
            {
				String s = i.ToString();
				s = zeroAdder(ConvertIntToString(s), k);

				Matrix vector = new Matrix(s);

				codeWord[i] = vector.multiply(this.G);
			}
		}

        public String getCodeBook()
        {
            StringBuilder res = new StringBuilder();
			res.Append("----------CODE BOOK----------\n");
            for (int i = 0; i < wordCount; i++)
            {

				String s = i.ToString();
				s = zeroAdder(ConvertIntToString(s), k);
				res.Append( s + " ---> " + codeWord[i] + "\n");
               
            }
			
			res.Append("-----------------------------\n");
			return res.ToString();
		}

 

		//public bool isContains(String vector)
		//{
		//	Matrix m = new Matrix(vector);
		//	Matrix res = m.multiply(this.H.T());
		//	if (res.isZeros())
		//	{
		//		return true;
		//	}
		//	return false;
		//}

		
	

		

		public void minDistance()
		{
			
			int min = n + 1;
			for (int i =1; i < this.wordCount; i++)
			{
				
				int d_min = codeWord[i].BitCountNew();
				if (d_min < min)
                {
                    min = d_min;
                }
               
            }
			Console.WriteLine("Minimun distance is " + min);
			HammingBoundary(min);
			VarshamovGilbertBorder(min);
			SingletonBoundary(min);
		}

		public int Conver2To10(int num)
        {
			string Number = num.ToString();
			
			Int32 DecimalNumber = 0;

			for (int i = 0; i < Number.Length; i++)
			{
				if (Number[Number.Length - i - 1] == '0') continue;
				DecimalNumber += (int)Math.Pow(2, i);
			}

			return DecimalNumber;
		}

		





		public override string ToString()
        {
			StringBuilder str = new StringBuilder();
			str.Append("Word count = " + this.wordCount + "\n\n");
			str.Append("G:\n" + this.G + "\n");
			//str.Append("H:\n" + this.H + "\n");
			str.Append(this.getCodeBook());
			return str.ToString();
		}




		public void HammingBoundary(int d)
        {
		
			double d_min =(double) d;
		
			int t = (int)Math.Floor((d_min - 1 )/ 2);// корректирующая способность.

			double hamming = Math.Pow(2, n) / SumC(t) /*Math.Log(SumC( t), 2)*/;

			
			Console.WriteLine("HammingBoundary " + hamming.ToString());

		}

		//n!k!(n−k)!
		long SumC(int t)
        {
			long sum = 0;
			if (t ==0) {
				for (int i = 0; i <= t; i++)
				{
					long a = Fact(i);
					long b = (Fact(n - i));
					long c = (Fact(n));
					long d = (c / (a * b));
					sum += d;
				}
			}
            else
            {
				for (int i = 0; i < t; i++)
				{
					long a = Fact(i);
					long b = (Fact(n - i));
					long c = (Fact(n));
					long d = (c / (a * b));
					sum += d;
				}
			}
		
	
			return sum;
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
			double varshamov = /*Math.Log(SumC(t), 2)*/(double )Math.Pow(2, n) / SumC(t);
			Console.WriteLine(" VarshamovGilbertBorder " + varshamov.ToString());
		}


		// qn – (d – 1).
		void SingletonBoundary(int d)
        {
			/// k <= n - d + 1
			double singleton = Math.Pow(2, n - d + 1); /*n - d + 1*/;
			Console.WriteLine(" SingletonBoundary " + singleton.ToString());
		}
	}
}
