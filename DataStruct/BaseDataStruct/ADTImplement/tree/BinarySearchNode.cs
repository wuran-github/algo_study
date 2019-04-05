using System;
using csharpDemo.ADT;
namespace csharpDemo.ADTImplement
{
    public class BinarySearchNode<K,V>:IBinarySearchNode<K,V>
    {
        public BinarySearchNode()
        {
        }

        public K Key { get ; set ; } = default(K);
        public V Value { get ; set ; } = default(V);
        public IBinarySearchNode<K, V> Left { get ; set ; } = null;
        public IBinarySearchNode<K, V> Right { get ; set ; } = null;
        public override string ToString(){
            return $"key:{Key.ToString()},value:{Value.ToString()}";
        }
    }
}