using System;
using csharpDemo.ADTImplement;
namespace csharpDemo.ADT
{
    public interface IList<TVal>
    {
        bool IsEmpty();
        bool IsLast(INode<TVal> node);
        INode<TVal> Header();
        void PrintList();
        void MakeEmpty();
         INode<TVal> Find(TVal value);
         INode<TVal> Insert(TVal value, INode<TVal> p);
         INode<TVal> Insert( INode<TVal> node, INode<TVal> p);
         INode<TVal> Append(TVal value);
         INode<TVal> Append( INode<TVal> node);
        void Delete(TVal value);
        INode<TVal> FindPrevious(TVal value);
    }
}
