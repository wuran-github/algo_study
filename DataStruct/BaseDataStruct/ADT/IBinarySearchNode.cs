using System;

namespace csharpDemo.ADT
{
    public interface IBinarySearchNode<K, V>
    {
        K Key { get; set; }
        V Value { get; set; }
        IBinarySearchNode<K, V> Left { get; set; }
        IBinarySearchNode<K, V> Right { get; set; }
    }
}