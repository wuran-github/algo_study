using System;

namespace csharpDemo.ADT
{
    public interface ITreeNode<T>
    {
        T Value { get; set; }
        ITreeNode<T> FirstChild { get; set; }
        ITreeNode<T> NextSibling { get; set; }
    }
}