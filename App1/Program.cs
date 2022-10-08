using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace App1
{
    class Program
    {

        public static byte[] ToByteCode(string value)
        {
            byte[] buf = Encoding.UTF8.GetBytes(value);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buf)
            {
                sb.Append(Convert.ToString(b, 2));
            }
            string binaryStr = sb.ToString();

            Console.WriteLine(binaryStr);

            return buf;

        }

        public static BitArray ReadBit(byte[] data)
        {
            BitArray bitArr = new BitArray(data);
            PrintValues(bitArr, 8);

            return bitArr;
        }

        public static void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }

        public static void ToBytesString(byte[] data)
        {
            for( int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(Convert.ToString(data[i], 2));
               
            }
            Console.WriteLine(Encoding.UTF8.GetString(data));
        }

        public static void CheckSymbilInString(string mess)
        {
            IEnumerable<char> stringQuery =
              from ch in mess
              where ch.Equals('\n')
              select ch;

            int count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);

            IEnumerable<char> stringQuery2 =
             from ch in mess
             where ch.Equals('\r')
             select ch;


            int coun2 = stringQuery.Count();
            Console.WriteLine("Count = {0}", coun2);
            var newmess = mess.TrimEnd('\n', '\r');
            stringQuery =
              from ch in newmess
              where ch.Equals('\n')
              select ch;

             count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);
        }

       
        static void Main(string[] args)
        {
            string stego = "zarinka";
            Console.WriteLine(stego);

            // CheckSymbilInString(stego);
            var byteMess = ToByteCode(stego);
            var bitMass = ReadBit(byteMess);
            Stack<bool> bitStack = new Stack<bool>();
            foreach (var i in bitMass)
                bitStack.Push((bool)i);
            char[] charsToTrim = { '\n', '\r' };
            var text = Regex.Split(File.ReadAllText("C:/Users/user/Source/Repos/Linear-code/App1/data1.txt"), "\r\n|\r|\n");

            var test = Encoding.ASCII.GetBytes(File.ReadAllText("C:/Users/user/Source/Repos/Linear-code/App1/data1.txt"));
            
            var str = Encoding.ASCII.GetString(test).ToCharArray(); ;

            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 >= str.Length) break;
                if (str[i] == ((char)0xa )&& str[i + 1] == ((char)0xd))
                {
                    str[i] = ((char)'\x0d\x0a');
                    str[i + 1] = ((char)0xa);
                }
                else if(str[i] == ((char)0xd) && str[i + 1] == ((char)0xa))
                {
                    str[i] = ((char)0x0A);
                    str[i + 1] = ((char)0x0D);
                }
            }
            Console.WriteLine(new string(str));
            Console.ReadLine();
            File.WriteAllText("C:/Users/user/Source/Repos/Linear-code/App1/result.txt", new string(str));


           //// var text =( File.ReadAllText("C:/Users/user/Source/Repos/Linear-code/App1/data1.txt")).Split('\n').Select(x => x.Trim(charsToTrim)).ToArray();
           // //var text = File.ReadAllLines("C:/Users/user/Source/Repos/Linear-code/App1/data1.txt");
           // for (int i = 0; i < text.Length; i++)
           // {
           //     if (bitStack.Count > 0 && !string.IsNullOrEmpty(text[i]))
           //     {

            //         var value = bitStack.Pop();
            //         if (value)
            //         {
            //             text[i] += ((char)0xa );
            //             //text[i] += ((char)0xd);
            //         }
            //         else
            //         {
            //             text[i] += ((char)0xd);
            //             text[i] += ((char)0xa);
            //         }
            //     }
            //     else
            //         text[i] += ((char)0xd);

            // }


            // StringBuilder stringBuilder = new StringBuilder();
            // foreach (var i in text)
            //     stringBuilder.Append(i);

            // Console.WriteLine(text.ToString());
            // File.WriteAllText("C:/Users/user/Source/Repos/Linear-code/App1/result1.txt", stringBuilder.ToString());

            // var inputString = File.ReadAllText("C:/Users/user/Source/Repos/Linear-code/App1/result1.txt");
            // List<bool> bits = new List<bool>();
            // for(int i = 1;i < inputString.Length; i++)
            // {
            //     if ((i + 1) < inputString.Length)
            //     {
            //         if (inputString[i] == ((char)0xa) && inputString[i - 1] != (char)0xd)
            //             bits.Add(true);
            //         else if (inputString[i] == (char)0xd && inputString[i + 1] == ((char)0xa))
            //             bits.Add(false);
            //     }
            // }
            // // string CR = "\r\n";
            // // string LR = "\n\r";
            // // string regularExpression = $"({CR}|{LR})";
            // //// string inputString = "Зарина\r\n  \r\n PPPPPPPP \n\r";
            // // for (Match m = Regex.Match(inputString, regularExpression); m.Success; m = m.NextMatch())
            // // {
            // //     GroupCollection gc = m.Groups;
            // //     //Console.WriteLine("The number of captures: " + gc.Count);
            // //     for (int i = 0; i < gc.Count; i++)
            // //     {
            // //         Group g = gc[i];
            // //         if (g.Value.Equals("\r\n"))
            // //             bits.Add(false);
            // //         else if (g.Value.Equals("\n\r"))
            // //             bits.Add(true);
            // //         else if (g.Value.Equals(""))
            // //             continue;
            // //     }

            // // }
            // var bitsArray = bits.ToArray();

            // BitArray array = new BitArray(bitsArray);

            // var resultArr = array.ToByteArray();
            // Array.Reverse(resultArr);
            // ToBytesString(resultArr);
            // //Console.WriteLine();



            // Console.ReadKey();


        }
    }
}




static class BitA
{
    public static byte[] ToByteArray(this BitArray bits)
    {
        int numBytes = bits.Count / 8;
        if (bits.Count % 8 != 0) numBytes++;

        byte[] bytes = new byte[numBytes];
        int byteIndex = 0, bitIndex = 0;

        for (int i = 0; i < bits.Count; i++)
        {
            if (bits[i])
                bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

            bitIndex++;
            if (bitIndex == 8)
            {
                bitIndex = 0;
                byteIndex++;
            }
        }

        return bytes;
    }

}
