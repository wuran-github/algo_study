using System;
namespace csharpDemo.ADT
{
    public interface INode<TVal>
    {
        INode<TVal> Next { get; set; }
        TVal Value { get; set; }
    }
}
