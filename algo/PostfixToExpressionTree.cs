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
        public void TestPostfix()
        {
            string[] testArray = null;
            testArray = new string[] { "6", "5", "2", "3", "+", "8", "*", "+", "3", "+", "*" };
            PostFixToTree(testArray);
        }

        void PostFixToTree(string[] array)
        {
            BinaryTree<string> expressionTree = new BinaryTree<string>();
            IStack<BinaryNode<string>> stack = new Stack<NormalNode<BinaryNode<string>>, BinaryNode<string>>();
            foreach (string element in array)
            {
                if (IsSymbol(element))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    BinaryNode<string> node = new BinaryNode<string>();
                    node.Value = element;
                    node.Left = left.Value;
                    node.Right = right.Value;
                    stack.Push(node);
                }
                else
                {
                    BinaryNode<string> node = new BinaryNode<string>();
                    node.Value = element;
                    stack.Push(node);
                }
            }
            var root = stack.Pop();
            expressionTree.SetRoot(root.Value);
            expressionTree.Postorder();
        }   
        bool IsSymbol(string element)
        {
            switch (element)
            {
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