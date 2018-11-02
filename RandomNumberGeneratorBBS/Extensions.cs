using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RandomNumberGeneratorBBS
{
    public static class Extensions
    {
        public static bool TakeLeastSignificantBit(this long value)
        {
            return (value & 1) == 1;
        }

        public static bool TakeLeastSignificantBit(this int value)
        {
            return (value & 1) == 1;
        }

        public static bool TakeLeastSignificantBit(this BigInteger value)
        {
            return (value & 1) == 1;
        }

        public static string ToBinaryString(this BitArray bitArray)
        {
            var sb = new StringBuilder(bitArray.Length);
            foreach (bool bit in bitArray)
            {
                sb.Append(bit ? "1" : "0");
            }
            return sb.ToString();
        }

        public static IEnumerable<bool> ToEnumerable(this BitArray bitArray)
        {
            return bitArray.Cast<bool>();
        }

        /// <summary>
        /// Takes up to 5 bits from BitArray from specified position and returns it as string.
        /// If 5 bits cannot be taken, method will return shorter string. 
        /// </summary>
        public static string Take5Bits(this BitArray bitArray, int position)
        {
            var sb = new StringBuilder(5);
            for(int i = position; i < position + 5 && i < bitArray.Length; i++)
            {
                sb.Append(bitArray[i] ? "1" : "0");
            }

            return sb.ToString();
        }

        public static void IncrementOrAdd(this Dictionary<string, int> dictionary, string key, int value = 1)
        {
            if(dictionary.ContainsKey(key))
                dictionary[key]++;
            else
                dictionary.Add(key, value);
        }
    }
}
