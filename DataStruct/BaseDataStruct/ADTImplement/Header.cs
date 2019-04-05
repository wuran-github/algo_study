using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class Header<T>:INode<T>
    {
        public INode<T> Next{get;set;} = null;
        public T Value { get ; set ; }
    }
}
