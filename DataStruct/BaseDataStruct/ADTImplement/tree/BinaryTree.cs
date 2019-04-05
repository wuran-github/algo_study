using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class BinaryTree<T>
    {
        IBinaryNode<T> root;
        public BinaryTree()
        {
            root = new BinaryNode<T>();
            
        }
        public void SetRoot(IBinaryNode<T> root){
            this.root = root;
        }
        /// <summary>
        /// 后序遍历，左右根
        /// </summary>
        public void Postorder(){
            PrintByPostorder(root);
        }
        void PrintByPostorder(IBinaryNode<T> node){
            if(node == null){
                return ;
            }
            var left = node.Left;
            var right = node.Right;
            PrintByPostorder(left);
            PrintByPostorder(right);
            System.Console.Write(" "+node.ToString());
        }
        /// <summary>
        /// 先序遍历，根左右
        /// </summary>
        public void Preorder(){
            PrintByPreorder(root);
        }
        void PrintByPreorder(IBinaryNode<T> node){
            if(node == null){
                return ;
            }
            var left = node.Left;
            var right = node.Right;
            System.Console.Write(" "+node.ToString());
            PrintByPostorder(left);
            PrintByPostorder(right);
        }
        /// <summary>
        /// 中序遍历，左根右
        /// </summary>
        public void Inorder(){
            PrintByInorder(root);
        }
        void PrintByInorder(IBinaryNode<T> node){
            if(node == null){
                return ;
            }
            var left = node.Left;
            var right = node.Right;
            PrintByPostorder(left);
            System.Console.Write(" "+node.ToString());
            PrintByPostorder(right);
        }
    }
}