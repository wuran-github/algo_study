using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class BinaryNode<T>:IBinaryNode<T>
    {
        public BinaryNode()
        {
        }

        public T Value { get ; set ; } = default(T);
        public IBinaryNode<T> Left { get ; set ; } = null;
        public IBinaryNode<T> Right { get ; set ; } = null;
        public override string ToString(){
            return Value.ToString();
        }
    }
}