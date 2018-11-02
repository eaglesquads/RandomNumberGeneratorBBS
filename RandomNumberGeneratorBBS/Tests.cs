using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace RandomNumberGeneratorBBS
{
    public static class Tests
    {
        public static void FullTest((BigInteger p, BigInteger q, BigInteger seed) tuple)
        {
            Console.WriteLine($"Testy dla parametrów P={tuple.p}, Q={tuple.q}, Seed={tuple.seed}:");

            var bbs = new BBS(tuple.p, tuple.q, tuple.seed);
            var bits = bbs.GenerateBits();

            SingleBitTest(bits);
            DoubleBitTest(bits);
            LongSeriesTest(bits);
            PockerTest(bits);

            Console.WriteLine();
        }

        public static int SingleBitTest(BitArray bitset)
        {
            Console.WriteLine("Test Pojedyńczego Bitu:");

            var count = bitset.Cast<bool>().Count(bit => bit);
            Console.WriteLine($"\tLiczba 1: {count}");

            return count;
        }

        public static int[] DoubleBitTest(BitArray bitset)
        {
            Console.WriteLine("Test podwójnych bitów:");

            var counts = new int[4];

            for (int i = 0; i < bitset.Length - 1; i++)
            {
                if (!bitset[i] && !bitset[i + 1])
                    counts[0]++;
                else if (!bitset[i] && bitset[i + 1])
                    counts[1]++;
                else if (bitset[i] && !bitset[i + 1])
                    counts[2]++;
                else
                    counts[3]++;
            }

            Console.WriteLine($"\tLiczba par 00 = {counts[0]}");
            Console.WriteLine($"\tLiczba par 01 = {counts[1]}");
            Console.WriteLine($"\tLiczba par 10 = {counts[2]}");
            Console.WriteLine($"\tLiczba par 11 = {counts[3]}");

            return counts;
        }

        public static int LongSeriesTest(BitArray bitArray)
        {
            Console.WriteLine("Test najdłuższej serii:");
            var maxCount = 0;
            int i = 1;
            while (i < bitArray.Length)
            {
                int currentCount = 1;
                while (i < bitArray.Length && bitArray[i - 1] == bitArray[i])
                {
                    currentCount++;
                    i++;
                }
                maxCount = Math.Max(maxCount, currentCount);
                i++;
            }

            Console.WriteLine($"\t Maksymalna długość najdłuższego podciągu {maxCount}");
            return maxCount;
        }

        public static Dictionary<string, int> PockerTest(BitArray bitArray)
        {
            Console.WriteLine("Test pokerowy:");
            var counts = new Dictionary<string, int>();
            for(int i = 0; i < bitArray.Length - 5; i++)
            {
                var pockerFigure = bitArray.Take5Bits(i);
                counts.IncrementOrAdd(pockerFigure);
            }

            Console.WriteLine($"\tLiczba figur {counts.Count}");
            Console.WriteLine($"\tŚrednia ilość elementów dla każdej figury powinna wynosić {(float)bitArray.Length / counts.Count:0.00}");

            var results = counts.ToList().OrderBy(pair => pair.Key);

            foreach (var pair in results)
            {
                Console.WriteLine($"\tDla figury {pair.Key} mamy {pair.Value} wystąpień");
            }

            return counts;
        }
    }
}
