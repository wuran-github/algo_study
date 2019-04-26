using System;

namespace HeapLearn
{
    public interface INode<TKey,TVal>
    {
        TVal Value{get;set;}
        TKey Key{get;set;}
    }
}