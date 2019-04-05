using System;
using csharpDemo.ADT;
namespace csharpDemo.ADTImplement
{
    public class BinarySearchTree<K, V> : IBinarySearchTree<K, V> where K : IComparable
    {
        IBinarySearchNode<K, V> root;
        public BinarySearchTree()
        {
        }
        /// <summary>
        /// 递归法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IBinarySearchNode<K, V> Delete(K key,IBinarySearchNode<K, V> tree)
        {
            if(tree == null){
                return null;
            }
            if(tree.Key.CompareTo(key) > 0){
               tree.Left = Delete(key,tree.Left);
            }
            else if(tree.Key.CompareTo(key) < 0){
               tree.Right = Delete(key,tree.Right);
            }
            else{//找到节点
                if (tree.Left != null && tree.Right != null){
                    var node = FindMin(tree.Right);
                    //替代有两种，一种直接拿过来替代，另一种就是替换值
                    //替换值
                    // tree.Key = node.Key;
                    // tree.Right = Delete(node.Key,tree.Right);
                    //替换地址 和换值没什么区别了
                    tree.Right = Delete(node.Key,tree.Right);
                    node.Right = tree.Right;
                    node.Left = tree.Left;
                    tree = node;
                    
                }else{
                    
                    if(tree.Left == null){
                        tree = tree.Right;
                    }
                    else if(tree.Right == null){
                        tree = tree.Left;
                    }
                    else{
                        tree = null;
                    }

                }
            }
            return tree;
        }
        public IBinarySearchNode<K, V> Delete(K key)
        {
            root = Delete(key,root);
            return root;
        }

        public IBinarySearchNode<K, V> Find(K key)
        {
            var node = root;
            while (node != null && node.Key.CompareTo(key) != 0)
            {
                if (node.Key.CompareTo(key) > 0)
                {
                    node = node.Right;
                }
                else if (node.Key.CompareTo(key) < 0)
                {
                    node = node.Left;
                }
            }
            return node;
        }

        public IBinarySearchNode<K, V> FindMax()
        {
            var node = root;
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

        public IBinarySearchNode<K, V> FindMin()
        {
            var node = root;
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        public IBinarySearchNode<K, V> FindMin(IBinarySearchNode<K, V> tree)
        {
            var node = tree;
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public IBinarySearchNode<K, V> Insert(K key)
        {
            var node = root;
            var newNode = new BinarySearchNode<K, V>();
            newNode.Key = key;
            while (node != null)
            {
                if (node.Key.CompareTo(key) == 0)
                {
                    newNode = null;
                    break;
                }
                else if (node.Key.CompareTo(key) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        break;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else if (node.Key.CompareTo(key) < 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        break;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
            return newNode;
        }
        public void SetRoot(IBinarySearchNode<K, V> root){
            this.root = root;
        }
        public void MakeEmpty(IBinarySearchNode<K, V> node)
        {
            if (node == null)
            {
                return;
            }
            var left = node.Left;
            var right = node.Right;
            MakeEmpty(left);
            MakeEmpty(right);
            node = null;

        }
        public void MakeEmpty()
        {
            MakeEmpty(root);
        }
    }
}