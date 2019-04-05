using System;
using csharpDemo.ADT;
using csharpDemo.ADTImplement;

namespace csharpDemo.algo
{
    public class InfixToPostfix
    {
        public InfixToPostfix()
        {
        }
        /// <summary>
        /// 测试版
        /// </summary>
        /// <returns></returns>
        public string[] Translate(){
            char[] testArray = null;
            testArray = "a+b*c+(d*e+f)*g".ToCharArray();
            return Translate(testArray);
        }
        /// <summary>
        /// 正式使用
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[] Translate(char[] array)
        {
            string outputStr = "";
            string[] outputArray = null;
            
            IStack<string> stack = new StackByArray<StringNode, string>();
            for (int i = 0; i < array.Length; i++)
            {
                string element = array[i].ToString();
                if (IsSymbol(element))
                {
                    var node = stack.Top();
                    try
                    {
                        while (node != null && node.Value!="(" && GetPriority(element) <= GetPriority(node.Value))
                        {
                            outputStr += stack.Pop().Value + " ";
                            node = stack.Top();
                        }
                        if(element == ")" && node!= null && node.Value == "("){
                            stack.Pop();
                            continue;
                        }
                        stack.Push(element);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                        System.Console.WriteLine("输入数组不正确");
                        return null;
                    }
                }
                else
                {
                    outputStr += element + " ";
                }
                
            }
            //文件尾把剩余符号输出
            while(stack.Top() != null){
                outputStr += stack.Pop().Value + " ";
            }
            //截掉最后一个空格
            outputStr = outputStr.Substring(0,outputStr.Length-1);
            outputArray = outputStr.Split(" ");
            return outputArray;
        }
        int GetPriority(string symbol)
        {
            int priority = 0;
            switch (symbol)
            {
                case "+":
                case "-":
                    priority = 1;
                    break;
                case "*":
                case "/":
                    priority = 2;
                    break;
                case "(":
                    priority = 10;
                    break;
                case "^":
                    priority = 3;
                    break;
                case ")": //给)也赋最低的优先级，这样遇到)就会全部弹出
                    priority = -1;
                    break;
            }
            return priority;
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