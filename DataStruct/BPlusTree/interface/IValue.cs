using System;

namespace BPlusTree.ADT
{
    public interface IValue<T>
    {
        T GetValue();
    }
}