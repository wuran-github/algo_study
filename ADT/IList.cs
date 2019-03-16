using System;
using csharpDemo.ADTImplement;
namespace csharpDemo.ADT
{
    public interface IList
    {
        bool IsEmpty();
        bool IsLast(Node node);
        Node Header();
        void PrintList();
        void MakeEmpty();
        Node Find(int value);
        void Insert(int value,Node p);
        void Append(int value);
        void Delete(int value);
        Node FindPrevious(int value);
    }
}
