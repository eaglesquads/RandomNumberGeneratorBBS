using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumberGeneratorBBS
{
    public struct Bit
    {
        private bool _value;
        public long Value { get => _value ? 1 : 0; set => _value = value != 0; }

    }
}
