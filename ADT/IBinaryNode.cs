using System;

namespace csharpDemo.ADT
{
    public interface IBinaryNode<T>
    {
        T Value { get; set; }
        IBinaryNode<T> Left { get; set; }
        IBinaryNode<T> Right{ get; set; }
        
    }
}