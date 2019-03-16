using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    /// <summary>
    /// 书上给的方法实际上position不是位置信息，而是一个节点
    /// 也就是他只是返回来一个节点，无法通过节点知道当前是第几个元素
    /// </summary>
    public class LinkList : IList
    {
        public Node header;
        public LinkList(){
            header = new Node();
        }
        public void Append(int value)
        {
                Node n = header;
                while(n.Next != null){
                    n = n.Next;
                }
                Node newNode = new Node(){
                    value = value
                };
                n.Next = newNode;
            
        }
        /// <summary>
        /// 删除找到的第一个元素
        /// </summary>
        /// <param name="value"></param>
        public void Delete(int value)
        {
            Node n = FindPrevious(value);
            if(n != null){
                n.Next = n.Next.Next;
            }
        }

        public Node Find(int value)
        {
            Node n = header.Next;
            while(n != null && n.value != value){
                n = n.Next;
            }
            return n;
        }

        public Node FindPrevious(int value)
        {
            Node n = header;
            while(n.Next != null && n.Next.value != value){
                n = n.Next;
            }
            return n;
        }

        public Node Header()
        {
            return header;
        }

        /// <summary>
        /// 在p之后插入
        /// </summary>
        /// <param name="value"></param>
        /// <param name="p"></param>
        public void Insert(int value, Node p)
        {
           Node n = new Node(){
               value = value
           };
           n.Next = p.Next;
           p.Next = n;
        }

        public bool IsEmpty()
        {
            return header.Next == null;
        }

        public bool IsLast(Node node)
        {
           return node.Next == null;
        }

        public void MakeEmpty()
        {
           header.Next = null;
        }


        public void PrintList()
        {
           Node n = header.Next;
           while(n != null){
               System.Console.WriteLine(n.value);
               n = n.Next;
           }
        }
        //实际上位置信息应该是在链表中
        //node不应存储位置信息

    }
}
