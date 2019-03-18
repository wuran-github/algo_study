using System;
using csharpDemo.ADTImplement;
namespace csharpDemo.ADT
{
    public interface IList<TNode,TVal>
    {
        bool IsEmpty();
        bool IsLast(TNode node);
        TNode Header();
        void PrintList();
        void MakeEmpty();
        TNode Find(TVal value);
        TNode Insert(TVal value,TNode p);
        TNode Insert(TNode node,TNode p);
        TNode Append(TVal value);
        TNode Append(TNode node);
        void Delete(TVal value);
        TNode FindPrevious(TVal value);
    }
}
