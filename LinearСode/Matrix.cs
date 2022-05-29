using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearСode
{
    public class Matrix
    {

		private int height;
		private int width;
		private int[,] array;
		Random rand = new Random();


        public int[,] Array { get => array; set => array = value; }



        public Matrix(int height, int width)
		{
			this.height = height;
			this.width = width;
			this.Array = new int[height,width];
		}

		public Matrix(String vector)
		{
			this.height = 1;
			this.width = vector.Length;
			this.Array = new int[height,width];

			char[] a = vector.ToCharArray();
            for (int i = 0; i < width; i++)
            {
                if (a[i] == '1')
                {
					this.Array[0, i] = 1;
                }
                else
                {
					this.Array[0, i] = 0;
                }
            }
            
		}


		public int BitCountNew()
		{
			int count = 0;
			for (int j = 0; j < width; j++)
			{
				if (Array[0,j] == 1)
				{
					count++;
				}
			}
			return count;

		}

		public void GenerationRandomMatrix()
		{
			for (int i = 0; i < height; i++)
			{
				this.Array[i,i] = 1;
			}
			Random rand = new Random();
			for (int i = 0; i < height; i++)
			{
				for (int j = height; j < width; j++)
				{
					this.Array[i,j] = rand.Next(2);
				}
			}
		}

		public Matrix multiply(Matrix obj)
		{
			if (this.width != obj.height)
			{
				return null;
			}
			int h = this.height;
			int w = obj.width;
			Matrix result = new Matrix(h, w);
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < w; j++)
				{
					int tmp = 0;
					for (int k = 0; k < obj.height; k++)
					{
						tmp += this.Array[i,k] * obj.Array[k,j];
					}
					result.Array[i,j] = tmp % 2;
				}
			}
			return result;
		}


		public Matrix Multi(Matrix obj)
		{
			if (this.width != obj.height)
			{
				return null;
			}
			int h = this.height;
			int w = obj.width;
			Matrix result = new Matrix(h, w);
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < w; j++)
				{
					int tmp = 0;
					for (int k = 0; k < obj.height; k++)
					{
						tmp += this.Array[i, k] * obj.Array[k, j];
					}
					result.Array[i, j] = tmp % 2;
				}
			}
			return result;
		}

		public Matrix T()
		{
			int h = this.width;
			int w = this.height;
			Matrix result = new Matrix(h, w);
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < w; j++)
				{
					result.Array[i,j] = this.Array[j,i];
				}
			}
			return result;
		}

		public bool isZeros()
		{
			for (int i = 0; i < this.height; i++)
			{
				for (int j = 0; j < this.width; j++)
				{
					if (this.Array[i,j] == 1)
					{
						return false;
					}
				}
			}
			return true;
		}

		public void PrintMatrix()
        {

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(Array[i, j]);
                }

				if (height > 1)
				{
					Console.WriteLine();
				}
				
            }

            Console.ReadKey();
        }

        public override string ToString()
        {
           
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        str.Append(this.Array[i,j]);
                    }
                    if (height > 1)
                    {
                        str.Append("\n");
                    }
                }
                return str.ToString();
        
        }


       
    }
}
