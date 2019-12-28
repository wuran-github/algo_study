using System;
using System.Collections.Generic;

namespace Equivalence{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class TreeEquivalenceClass2<TElement>  {
        Dictionary<TElement, TElement> tree = new Dictionary<TElement, TElement>();
        //树的大小
        Dictionary<TElement, int> treeSize = new Dictionary<TElement, int>();
        public TreeEquivalenceClass2(params TElement[] elements){
            foreach (var el in elements)
            {
                tree.Add(el,default(TElement));
                treeSize.Add(el, 1);
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
        /// 大的成为小的根
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Union(TElement x, TElement y){
            TElement leftRoot = Find(x);
            TElement rightRoot = Find(y);
            if(leftRoot.Equals(rightRoot)){
                return;
            }
            int leftSize = treeSize[leftRoot];
            int rightSize = treeSize[rightRoot];
            TElement smallRoot = default(TElement);
            TElement bigRoot = default(TElement);
            if(leftSize > rightSize){
                smallRoot = rightRoot;
                bigRoot = leftRoot;
            }
            else{
                smallRoot = leftRoot;
                bigRoot = rightRoot;
            }     
            tree[smallRoot] = bigRoot;
            treeSize[bigRoot] = leftSize + rightSize;
            treeSize.Remove(smallRoot);
        }

    }

}