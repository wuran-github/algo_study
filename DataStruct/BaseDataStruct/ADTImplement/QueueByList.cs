using System;
// using System.Collections.Generic;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    /// <summary>
    /// 链表实现方法不需要尾部，出队只需要把最前头元素拿出
    /// 入队只需要append,往最后插入
    /// 链表的Api好像没有append，所以我们可以采用不用append使用r
    /// c#的链表有prev节点，是双循环链表，因此找到尾节点很简单，这里我们找到尾节点只能通过遍历
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TVal"></typeparam>
    public class QueueByList<T, TVal> : IQueue<TVal> where T : INode<TVal>, new()
    {
        int capacity;
        int size;
        LinkList<T,TVal> list;
        //不使用append的时候需要用到
        INode<TVal> rear;
        public QueueByList()
        {
            list = new LinkList<T,TVal>();
            size = 0;
            // rear = default(T);
            //  LinkedList<int> l = new LinkedList<int>();
        }

        public INode<TVal> Dequeue()
        {
            if(IsEmpty()){
                return null;
            }
            var node = list.Header().Next;
            list.Header().Next = node.Next;
            return node;
        }

        public INode<TVal> Enqueue(TVal val)
        {
            INode<TVal> node = new T();
            node.Value = val;
            
            return Enqueue(node);
        }

        public INode<TVal> Enqueue(INode<TVal> node)
        {
            if(IsFull()){
                return null;
            }
            // var lastNode = list.Append(node);
            // size++;
            // return lastNode;
            if(rear == null){
                rear = list.Append(node);
            }
            else{
                rear = list.Insert(node,rear);
            }
            size ++;
            return rear;
        }

        public INode<TVal> Front()
        {
            return list.Header().Next;
        }

        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        public bool IsFull()
        {
            return false;
        }

        public void MakeEmpty()
        {
            list.MakeEmpty();
            size = 0;
            // rear = default(T);
        }
    }
}