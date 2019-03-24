using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class BinaryNode<T>:IBinaryTreeNode<T>
    {
        public BinaryNode()
        {
        }

        public T Value { get ; set ; } = default(T);
        public IBinaryTreeNode<T> Left { get ; set ; } = null;
        public IBinaryTreeNode<T> Right { get ; set ; } = null;
    }
}