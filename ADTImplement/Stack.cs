using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class Stack<T,TVal> : IStack<TVal> where T:INode<TVal>,new()
    {
        Header<TVal> header;
        public Stack()
        {
            header = new Header<TVal>();
        }

        public bool IsEmpty()
        {
            return header.Next == null;
        }

        public void MakeEmpty()
        {
           header.Next = null;
        }

        public INode<TVal> Pop()
        {
            INode<TVal> node = header.Next;
            if(node != null){
                header.Next = node.Next;
            }
            return node;
        }

        public void Push(INode<TVal> t)
        {
            INode<TVal> node = header.Next;
                header.Next = t;
                t.Next = node;
            
        }
        public void Push(TVal t){

            INode<TVal> node = header.Next;
            T newNode = new T();
            newNode.Value = t;
            header.Next = newNode;
            newNode.Next = node;

        }
        public INode<TVal> Top()
        {
           return header.Next;
        }
    }
}