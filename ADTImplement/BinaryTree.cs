using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class BinaryTree<T>
    {
        BinaryNode<T> root;
        public BinaryTree()
        {
            root = new BinaryNode<T>();
            
        }
        public void TestPostfix(){
            string[] testArray = null;
            testArray = new string[] { "6", "5", "2", "3", "+", "8", "*", "+", "3", "+", "*" };
        }
        
        void PostFixToTree(string[] array){
            IStack<BinaryNode<T>> stack = new Stack<NormalNode<BinaryNode<T>>,BinaryNode<T>>();
            foreach(string element in array){
                
            }
        }

    }
}