using System;

namespace csharpDemo.ADT
{
    public interface IQueue<T>
    {
        bool IsEmpty();
        bool IsFull();
        void MakeEmpty();
        INode<T> Front();

        /// <summary>
        /// 返回空代表进队失败
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        INode<T> Enqueue(T val);
        /// <summary>
        /// 返回空代表进队失败
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        INode<T> Enqueue(INode<T> node);
        INode<T> Dequeue();
        
    }
}