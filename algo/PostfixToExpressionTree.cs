using System;
using csharpDemo.ADT;
using csharpDemo.ADTImplement;

namespace csharpDemo.algo
{
    public class PostfixToExpressionTree
    {
        public PostfixToExpressionTree()
        {
        }
        void PostFixToTree(string[] array){
            BinaryTree<string> expressionTree = new BinaryTree<string>();
            IStack<BinaryNode<string>> stack = new Stack<NormalNode<BinaryNode<string>>,BinaryNode<string>>();
            foreach(string element in array){
                
            }
        }
        bool IsSymbol(string element)
        {
            switch(element){
                case "(":
                case ")":
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                return true;
                default:
                return false;
            }
        }
    }
}