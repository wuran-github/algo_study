using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class NormalNode<T> :INode<T>
    {
        public NormalNode()
        {
        }

        public INode<T> Next { get ; set; } = null;
        public T Value { get ; set ; } = default(T);
    }
}