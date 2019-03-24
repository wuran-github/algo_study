using System;

namespace csharpDemo.ADT
{
    public interface IBinaryTreeNode<T>
    {
        T Value { get; set; }
        IBinaryTreeNode<T> Left { get; set; }
        IBinaryTreeNode<T> Right{ get; set; }
        
    }
}