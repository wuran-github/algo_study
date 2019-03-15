using System;
using csharpDemo.ADTImplement;
namespace csharpDemo.ADT
{
    public interface IList
    {
        bool IsEmpty();
        bool IsLast();
        IList Header();
        void PrintList();
        void MakeEmpty();
        int Find(int value);
        void Insert(int value,int location);
        void Delete(int value);
        int FindKth(int location);
        Node Next();
        Node Previous();
    }
}
