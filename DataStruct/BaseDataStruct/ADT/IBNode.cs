using System;
using System.Collections.Generic;
using csharpDemo.ADTImplement;

namespace csharpDemo.ADT
{
    public interface IBNode
    {
    
        bool IsLeaf();
        BNode Parent{ get; set;}
        int GetMinKey();
        int GetChildrenNum();
        void InsertLeafChild(int value);
        void InsertNodeChild(IBNode value);
        bool RemoveLeafChild(int value);
        bool RemoveNodeChild(IBNode value);
    }

}