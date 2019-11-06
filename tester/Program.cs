using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string myBinary = "11111111";
            string binary0 = "00000000";



            Console.WriteLine(ConvertBinaryToDouble(myBinary));
            Console.WriteLine(binary0);
            Console.WriteLine(ConvertBinaryToDouble(binary0));
            Console.WriteLine(myBinary);
            Console.ReadLine();
        }

        static double ConvertBinaryToDouble(string binaryNum)
        {
            double myAns = 0;
            int n = 0;
            //take a binary number, and return the integer value

            for (var i = binaryNum.ToString().Length - 1; i >= 0; i--)
            {
                if (binaryNum[i].ToString() == "1")
                {
                    myAns += Math.Pow(2, n);
                    n++;
                }
            }
            return myAns;
        }
    }
}
