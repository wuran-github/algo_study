using System;
using csharpDemo.ADTImplement;
namespace csharpDemo.ADT
{
    public interface IList<TNode,TVal>
    {
        bool IsEmpty();
        bool IsLast(TNode node);
        INode<TVal> Header();
        void PrintList();
        void MakeEmpty();
        TNode Find(TVal value);
        TNode Insert(TVal value,TNode p);
        TNode Insert(TNode node,TNode p);
        TNode Append(TVal value);
        TNode Append(TNode node);
        void Delete(TVal value);
        INode<TVal> FindPrevious(TVal value);
    }
}
