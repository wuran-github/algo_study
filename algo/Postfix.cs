using System;
using csharpDemo.ADT;
using csharpDemo.ADTImplement;

namespace csharpDemo.algo
{
    public class Postfix
    {
        public Postfix() 
        {
        }
        public string GetResult(string[] array){

            IStack<string> stack = new StackByArray<StringNode,string>();
            for(int i = 0; i< array.Length ; i++){
                string element = array[i];
                if(!IsSymbol(element)){
                    stack.Push(element);
                }
                else{
                    var node = stack.Pop();
                    var node2 = stack.Pop();
                    if(node == null || node2 == null){
                        // throw new Exception("栈中数字不足");
                        System.Console.WriteLine("栈中数字不足");
                        return null;
                    }
                    string left = node.Value;
                    string right = node2.Value;
                    double result = Calculate(element,left,right);
                    stack.Push(result.ToString());
                }
            }
            var finalNode = stack.Pop();
            if(finalNode == null){
                System.Console.WriteLine("错误，栈中无结果");
                return null;
            }
            else{
                System.Console.WriteLine("result:"+finalNode.Value);
            }
            return finalNode.Value;

        } 
        public void run()
        {
            string[] testArray = null;
            testArray = new string[] { "6", "5", "2", "3", "+", "8", "*", "+", "3", "+", "*" };
            GetResult(testArray);
        }
        double Calculate(string symbol, string left, string right)
        {
            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = double.Parse(right) + double.Parse(left);
                    break;
                case "*":
                    result = double.Parse(right) * double.Parse(left);
                    break;
                case "-":
                    result = double.Parse(right) - double.Parse(left);
                    break;
                case "/":
                    result = double.Parse(right) / double.Parse(left);
                    break;
                case "^":
                    result = Math.Pow(double.Parse(right),double.Parse(left));
                    break;
            }
            return result;
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