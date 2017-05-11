using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIQ_3239
{
    class Program
    {
        static void Main(string[] args)
        {
            // 標準入力からテストデータを取得
            string inputText = Console.ReadLine();
            int input = int.Parse(inputText);
            //int input = 22;
            //int input = 1000000; // 100010100000000000101000000000,10111110101010101111101010101 ?

            List<int> fiboList = GenerateFibonacciSequence(input);

            //for (int i = 1; i < 10000; i++)
            //{
            //    List<int> list = GenerateFibonacciSequence(i);

            //    int val = GetFibonacciMinValue(i, list);
            //    Console.WriteLine(i + " = " + Convert.ToString(val, 2));
            //}

            int min = GetFibonacciMinValue(input, fiboList);
            int max = GetFibonacciMaxValue(input, fiboList);

            // 標準出力へ結果出力
            Console.WriteLine(Convert.ToString(max, 2) + "," + Convert.ToString(min, 2));
        }

        private static List<int> GenerateFibonacciSequence(int max)
        {
            var result = new List<int>();
            result.Add(1);
            result.Add(1);

            while(result[result.Count - 1] < max)
            {
                result.Add(result[result.Count - 2] + result[result.Count - 1]);
            }

            return result;
        }

        private static int GetFibonacciMinValue(int target, List<int> fiboList)
        {
            int fiboSum = 0;
            int min = 0;
            //int max = 1 << fiboList.Count;
            do
            {
                min++;
                //if (min >= max) break;

                fiboSum = 0;
                int i = min;
                foreach (int fibo in fiboList)
                {
                    if ((i & 0x01) != 0)
                    {
                        fiboSum += fibo;
                    }

                    i >>= 1;
                }
            } while (fiboSum != target);

            return min;
        }

        private static int GetFibonacciMaxValue(int target, List<int> fiboList)
        {
            int fiboSum = 0;
            //int min = 0;
            int max = 1 << fiboList.Count;
            do
            {
                max--;
                //if (max <= min) break;

                fiboSum = 0;
                int i = max;
                foreach (int fibo in fiboList)
                {
                    if ((i & 0x01) != 0)
                    {
                        fiboSum += fibo;
                    }

                    i >>= 1;
                }
            } while (fiboSum != target);

            return max;
        }
    }
}
