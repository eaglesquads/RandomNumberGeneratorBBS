using System;
using System.Collections;
using System.Numerics;

namespace RandomNumberGeneratorBBS
{
    public class BBS
    {
        public BigInteger P { get; set; }
        public BigInteger Q { get; set; }
        public BigInteger Seed { get; set; }
        public BigInteger N { get; set; }

        private readonly BigInteger _startingValue;
        private BigInteger _prevValue;

        public BBS(BigInteger p, BigInteger q, BigInteger seed)
        {
            P = p;
            Q = q;
            N = P * Q;
            if(p % 4L != p % 4L)
            {
                throw new ArgumentException("Liczby nie są kongruentne");
            }

            Seed = seed;
            _startingValue = seed * seed % N;
            _prevValue = _startingValue;
        }

        public BitArray GenerateBits(int count = 20000)
        {
            var bitset = new BitArray(count);

            for(int i = 0; i < count; i++)
            {
                bitset[i] = _prevValue.TakeLeastSignificantBit();
                var next = _prevValue * _prevValue % N; 
                _prevValue = next;
            }

            return bitset;
        }

    }
}
