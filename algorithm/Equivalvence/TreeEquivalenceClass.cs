using System;
using System.Collections.Generic;

namespace Equivalence{
    /// <summary>
    /// 默认y的根父节点为x的根节点
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class TreeEquivalenceClass<TElement>  {
        Dictionary<TElement, TElement> tree = new Dictionary<TElement, TElement>();
        public TreeEquivalenceClass(params TElement[] elements){
            foreach (var el in elements)
            {
                tree.Add(el,default(TElement));
            }
        }
        public TElement Find(TElement x){
            TElement root = tree[x];
            TElement name = x;
            while(!object.Equals(root,default(TElement))){
                name = root;
                root = tree[name];
            }
            return name;
        }
        /// <summary>
        /// 默认y的根父节点为x的根节点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Union(TElement x, TElement y){
            TElement leftRoot = Find(x);
            TElement rightRoot = Find(y);
            tree[rightRoot] = leftRoot;
        }

    }

}