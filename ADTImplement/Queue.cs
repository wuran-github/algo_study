using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class Queue<T,TVal> : IQueue<TVal> where T:INode<TVal>,new()
    {
        int capacity = 1024;
        int size;
        INode<TVal>[] queue;
        int front;
        int rear;
        public Queue()
        {
            InitQueue();
        }
        public Queue(int capacity){
            this.capacity = capacity;
            InitQueue();
        }
        private int CalcLocation(int num){
            num++;
            num = num % (capacity);
            return num;
        }
        private void InitQueue(){
            front = 0;
            rear = -1;
            size = 0;
            queue = new INode<TVal>[capacity];
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
            size++;
            rear = CalcLocation(rear);
            queue[rear] = node;
            return node;
        }

        public INode<TVal> Front()
        {
            if(IsEmpty()){
                return null;
            }
            return queue[front];
        }


        /// <summary>
        /// 通过front 和rear的值判断是否为空
        /// 有几种情况可以判断，这里我们用一个单元记录队列大小
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return size == 0;
        }
        
        public bool IsFull()
        {
            return size == capacity;
        }

        public void MakeEmpty()
        {
            // InitQueue();

            queue[0] = null;
            front = 0;
            rear = -1;
            size = 0;
        }


        public INode<TVal> Dequeue()
        {
            if(IsEmpty()){
                return null;
            }
            INode<TVal> node = queue[front];
            front = CalcLocation(front);
            size--;
            return node;
        }
    }
}