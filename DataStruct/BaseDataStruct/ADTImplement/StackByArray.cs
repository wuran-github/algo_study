using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class StackByArray<T,TVal> : IStack<TVal> where T:INode<TVal>, new()
    {
        INode<TVal>[] stackArray;
        int topOfStack;
        public StackByArray()
        {
            stackArray = new INode<TVal>[1024];
            topOfStack = -1;
        }

        public bool IsEmpty()
        {
            return topOfStack == -1;
        }

        public void MakeEmpty()
        {
            topOfStack = -1;
        }

        public INode<TVal> Pop()
        {
            INode<TVal> node = null;
            if(!IsEmpty()){
                node = stackArray[topOfStack];
                stackArray[topOfStack] = null;
                topOfStack--;
            }
            return node;
        }

        public void Push(INode<TVal> t)
        {
           if(topOfStack>=1024){
               throw new Exception("stack was full");
           }
           topOfStack++;
           stackArray[topOfStack] = t;
        }

        public void Push(TVal t)
        {
            if(topOfStack>=1024){
               throw new Exception("stack was full");
           }
            T node = new T();
            node.Value = t;
            topOfStack++;
            stackArray[topOfStack] = node;
        }

        public INode<TVal> Top()
        {
            INode<TVal> node = null;
            if(!IsEmpty()){
                node = stackArray[topOfStack];
            }
            return node;
        }
    }
}