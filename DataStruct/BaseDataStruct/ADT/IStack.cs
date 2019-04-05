using System;

namespace csharpDemo.ADT
{
    public interface IStack<T>
    {
        bool IsEmpty();
        void MakeEmpty();
        void Push(INode<T> t);
        void Push(T t);
        /// <summary>
        /// 如果为空返回null
        /// </summary>
        /// <returns></returns>
        INode<T> Pop();
        /// <summary>
        /// 如果为空返回null
        /// </summary>
        /// <returns></returns>
        INode<T> Top();


    }
}