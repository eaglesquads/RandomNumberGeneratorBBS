using System;
using System.Numerics;

namespace RandomNumberGeneratorBBS
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = new (long p, long q, long seed)[]
                {
                    (15485867L,23878409L,8353L),
                    (31415821L,772531L,1878892440L),
                    (3264011L,472990951L,131893L),
                    (3263849L,1302498943L,6367859L),
                    (3264011L,472990951L,9883L),
                    (4990364893L,58105693L,6681193L),
                    (87566873L,15485143L,193945L)
                };

            foreach(var testCase in testCases)
            {
                Tests.FullTest(testCase);
            }

            Console.ReadLine();
        }
    }
}
