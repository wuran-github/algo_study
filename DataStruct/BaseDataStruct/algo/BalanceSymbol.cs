using System;
using csharpDemo.ADT;
using csharpDemo.ADTImplement;
using System.Linq;
namespace csharpDemo.algo
{

    public class BalanceSymbol
    {
        public BalanceSymbol()
        {
        }
        public void Run()
        {
            string[] testArray = null;
            // testArray =new string[] { "(", ")", "[", "{", "}" };
            // testArray = new string[] { "(", ")", "]", "{", "}"};
            testArray = new string[] { "(", ")", "[",  "}"};
            string[] openElement = { "(", "[", "{" };
            string[] closeElement = { ")", "]", "}" };
            IStack<string> stack = new StackByArray<StringNode, string>();
            for (int i = 0; i < testArray.Length; i++)
            {
                string symbol = testArray[i];
                //判断是开放元素还是封闭元素
                if (openElement.Contains(symbol))
                {
                    stack.Push(symbol);
                }
                else
                {
                    if (stack.IsEmpty())
                    {
                        System.Console.WriteLine("错误，封闭元素遇上栈空");
                        break;
                    }
                    else
                    {
                        string left = stack.Pop().Value;
                        if (IsCouple(left, symbol))
                        {

                        }
                        else
                        {
                            System.Console.WriteLine("错误，开放元素对不上");
                            break;
                        }
                    }
                }
            }
            if(!stack.IsEmpty()){
                System.Console.WriteLine("错误，文件读完栈不为空");
            }
            
        }
        bool IsCouple(string left, string right)
        {
            bool result = false;
            switch (left)
            {
                case "(":
                    if (right == ")")
                    {
                        result = true;
                    }
                    break;
                case "[":
                    if (right == "]")
                    {
                        result = true;
                    }
                    break;
                case "{":
                    if (right == "}")
                    {
                        result = true;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }


    }
}