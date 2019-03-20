using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    /// <summary>
    /// 书上给的方法实际上position不是位置信息，而是一个节点
    /// 也就是他只是返回来一个节点，无法通过节点知道当前是第几个元素
    /// </summary>
    public class LinkList<T,TVal> : IList<T,TVal> where T: INode<TVal>,new()
    {
        public Header<TVal> header;
        public LinkList(){
            header = new Header<TVal>();
        }
        public T Append(TVal value)
        {
            INode<TVal> n = header;
            while (n.Next != null)
            {
                n = (T)n.Next;
            }
            T newNode = new T();
            newNode.Value = value;

            n.Next = newNode;
            return newNode;
        }

        public T Append(T node)
        {
           INode<TVal> n = header;
            while (n.Next != null)
            {
                n = (T)n.Next;
            }
            n.Next = node;
            return node;
        }

        /// <summary>
        /// 删除找到的第一个元素
        /// </summary>
        /// <param name="value"></param>
        public void Delete(TVal value)
        {
            INode<TVal> n = FindPrevious(value);
            if(n != null){
                n.Next = n.Next.Next;
            }
        }

        public T Find(TVal value)
        {
            T n = (T)header.Next;
            while(n != null && n.Value.Equals(value)){
                n =(T)n.Next;
            }
            return n;
        }

        public INode<TVal> FindPrevious(TVal value)
        {
            INode<TVal> n = header;
            while(n.Next != null && n.Next.Value.Equals(value)){
                n = (T)n.Next;
            }
            return n;
        }

        public INode<TVal> Header()
        {
            return header;
        }

        /// <summary>
        /// 在p之后插入,返回新插入的元素
        /// </summary>
        /// <param name="value"></param>
        /// <param name="p"></param>
        public T Insert(TVal value, T p)
        {
           T n = new T(){
               Value = value
           };
           n.Next = p.Next;
           p.Next = n;
           return n;
        }

        public T Insert(T node, T p)
        {
            node.Next = p.Next;
            p.Next = node;
            return node;
        }

        public bool IsEmpty()
        {
            return header.Next == null;
        }

        public bool IsLast(T node)
        {
           return node.Next == null;
        }

        public void MakeEmpty()
        {
           header.Next = null;
        }


        public void PrintList()
        {
           T n = (T)header.Next;
           while(n != null){
               System.Console.WriteLine(n.ToString());
               n = (T)n.Next;
           }
        }
        //实际上位置信息应该是在链表中
        //node不应存储位置信息

    }
}
