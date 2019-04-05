using System;
using BPlusTree.ADT;

namespace BPlusTree.ADTImplement
{
    public class IntValue : IValue<int>
    {
        int value;
        public IntValue(int val)
        {
            value = val;
        }

        public int GetValue()
        {
            return value;
        }
    }
}