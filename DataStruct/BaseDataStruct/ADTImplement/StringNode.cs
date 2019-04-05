using System;
using csharpDemo.ADT;
namespace csharpDemo.ADTImplement
{
    public class StringNode:INode<string>
    {
        public StringNode()
        {
        }
        public INode<string> Next { get; set; } = null;
        public string Value { get; set; }

        public override string ToString(){
            return Value;
        } 
    }
}