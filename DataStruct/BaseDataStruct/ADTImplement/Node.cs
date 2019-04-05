using System;
using csharpDemo.ADT;
namespace csharpDemo.ADTImplement
{
    public class Node : INode<int>
    {
        public INode<int> Next { get; set; } = null;
        public int Value { get; set; }

        public override string ToString(){
            return Value.ToString();
        } 
    }
}
