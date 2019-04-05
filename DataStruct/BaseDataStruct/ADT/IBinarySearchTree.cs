using System;

namespace csharpDemo.ADT
{
    public interface IBinarySearchTree<K,V>
    {
        /// <summary>
        /// 递归的都加个无参数的 
        /// </summary>
        void MakeEmpty();
        void MakeEmpty(IBinarySearchNode<K,V> node);
        IBinarySearchNode<K,V> Find(K key);
        IBinarySearchNode<K,V> FindMax();
        IBinarySearchNode<K,V> FindMin();
        IBinarySearchNode<K,V> Insert(K key);
        IBinarySearchNode<K,V> Delete(K key);

    }
}