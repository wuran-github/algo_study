using System;

namespace csharpDemo.ADT
{
    public interface IValue<T>
    {
        T GetValue();
    }
}