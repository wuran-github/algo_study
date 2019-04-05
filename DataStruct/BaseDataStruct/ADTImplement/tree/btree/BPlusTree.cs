using System;
using System.Collections.Generic;
using csharpDemo.ADT;
namespace csharpDemo.ADTImplement
{
    public class BPlusTree
    {
        IBNode root;
        int M;
        public BPlusTree(int M)
        {
            this.M = M;
        }
        public void Delete(int value)
        {

        }
        #region 删除
        private IBNode Delete(int value, IBNode tree)
        {
            if (tree == null)
            {
            }
            else if (tree.IsLeaf())
            {
                tree = DeleteLeaf(value, tree);
            }
            else//递归去找叶子节点
            {
                var node = (BNode)tree;
                bool finded = false;
                for (int i = 0; i < node.Keys.Count; i++)
                {
                    if (value < node.Keys[i])
                    {
                        tree = Delete(value, node.Children[i]);
                    }
                }
                if (!finded)
                {
                    tree = Delete(value, node.Children[node.Keys.Count]);
                }
            }
            return tree;
        }
        private IBNode DeleteLeaf(int value, IBNode tree)
        {
            BLeaf leaf = (BLeaf)tree;
            bool res = leaf.RemoveValue(value);
            if (res)
            {
                if (leaf.GetChildrenNum() < Math.Ceiling(M / 2m))
                {
                    BNode parent = leaf.Parent;
                    if (parent == null)
                    {
                    }
                    else
                    {
                        //先找到孩子节点
                        var siblings = parent.GetSiblings(leaf);
                        if (siblings.Count == 0)
                        {//非孩子节点
                            //do nothing
                        }
                        else
                        {
                            IBNode sibling = null;
                            foreach (var node in siblings)
                            {
                                if (node.GetChildrenNum() > Math.Ceiling(M / 2m))
                                {
                                    sibling = node;
                                    break;
                                }
                            }
                            if (sibling == null)
                            {//兄弟节点都没有多的元素
                                MergeLeaf((BLeaf)siblings[0], leaf);
                                //开始检索上级
                                parent = (BNode)DeleteNode(parent);
                            }
                            else
                            {
                                ShareLeafValue((BLeaf)sibling, leaf);
                            }
                        }
                    }
                }
                else
                {//do nothing

                }
            }
            else
            {//节点不存在

            }
            return tree;
        }
        private IBNode DeleteNode(IBNode tree)
        {
            
            return tree;
        }
        private void MergeNode(IBNode leftNode,IBNode rightNode){

        }
        private void ShareNode(IBNode leftNode,IBNode rightNode){
            
        }
        private void ShareLeafValue(BLeaf leftLeaf, BLeaf rightLeaf)
        {
            int value = 0;
            if (leftLeaf.GetMinKey() < rightLeaf.GetMinKey())
            {
                int i = leftLeaf.GetChildrenNum() - 1;
                value = leftLeaf.Values[i];

            }
            else
            {
                value = leftLeaf.GetMinKey();
            }
            rightLeaf.AddValue(value);
            leftLeaf.RemoveValue(value);
        }
        private void MergeLeaf(BLeaf leftLeaf, BLeaf rightLeaf)
        {
            BLeaf newLeaf = new BLeaf(M);
            //位置调换一下
            if (leftLeaf.GetMinKey() > rightLeaf.GetMinKey())
            {
                var temp = leftLeaf;
                leftLeaf = rightLeaf;
                rightLeaf = temp;
            }
            var list = leftLeaf.Values;
            list.AddRange(rightLeaf.Values);
            leftLeaf.Values = list;
            leftLeaf.NextLeaf = rightLeaf.NextLeaf;
            var parent = leftLeaf.Parent;
            parent.RemoveChildren(rightLeaf);
        }
        #endregion
        public void Insert(int value)
        {
            root = Insert(value, root);
        }

        #region 简单插入
        /// <summary>
        /// 这是最简单的插入，没有节省空间，
        /// 如果一个节点的孩子数是2，除非关键字在这个节点的范围内，否则基本不会在往这里插入节点
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tree"></param>
        /// <returns></returns>
        private IBNode Insert(int value, IBNode tree)
        {
            //说明空
            if (tree == null)
            {
                BLeaf leaf = new BLeaf(M);
                leaf.AddValue(value);
                tree = leaf;
            }
            else if (tree.IsLeaf())
            {
                tree = InsertLeaf(value, tree);
            }
            else//递归去找叶子节点
            {
                var node = (BNode)tree;
                bool finded = false;
                for (int i = 0; i < node.Keys.Count; i++)
                {
                    if (value < node.Keys[i])
                    {
                        tree = Insert(value, node.Children[i]);
                    }
                }
                if (!finded)
                {
                    tree = Insert(value, node.Children[node.Keys.Count]);
                }
            }
            return tree;
        }
        private IBNode InsertLeaf(int value, IBNode tree)
        {
            var leaf = (BLeaf)tree;
            if (leaf.Values.Count < M)
            {
                //这里改完也得找到父节点返回
                leaf.AddValue(value);

            }
            else
            {
                //不管怎样，都要先加节点
                BLeaf newLeaf;
                SplitLeaf(ref leaf, out newLeaf, value);

                var parent = leaf.Parent;
                if (parent == null)
                {
                    //如果为空，新建一个
                    parent = new BNode(M);
                    parent.InsertChild(leaf);
                    parent.InsertChild(newLeaf);
                    tree = parent;
                }
                else
                {
                    //把叶子插入了，然后开始递归Node节点
                    parent.InsertChild(newLeaf);

                    //如果改编了node，返回的就是parent了，最后返回了最后一层改变的parent
                    tree = InsertNode(parent);
                }
            }
            //因为InsertLeaf和InsertNode都没有递归，所以在这里递归开始往上返回，在这里开始找父节点
            //找到根节点返回
            while (tree.Parent != null)
            {
                tree = tree.Parent;
            }
            return tree;
        }
        private IBNode InsertNode(BNode parent)
        {
            //情况1 父节点的儿子数少于M
            if (parent.GetChildrenNum() <= M)
            {
            }
            else
            {

                //情况2 父亲的儿子节点=M,那就要分裂父节点了
                while (parent.GetChildrenNum() > M)
                {
                    var node = parent;
                    parent = node.Parent;
                    BNode newNode;
                    //然后分裂父节点
                    SplitNode(ref node, out newNode);

                    //如果本来node是根节点
                    if (parent == null)
                    {
                        //新建根节点
                        parent = new BNode(M);
                        parent.InsertChild(node);
                        parent.InsertChild(newNode);
                    }
                    else
                    {
                        parent.InsertChild(newNode);
                    }
                }



            }
            return parent;
        }
        #endregion
        private void SplitLeaf(ref BLeaf oldLeaf, out BLeaf newLeaf, int value)
        {
            newLeaf = new BLeaf(M);
            var list = new List<int>(oldLeaf.Values);
            list.Add(value);
            list.Sort();
            int count = list.Count;
            var list1 = list.GetRange(0, count / 2);
            var list2 = list.GetRange(count / 2, count - count / 2);
            oldLeaf.Values = list1;
            newLeaf.Values = list2;

            //把叶子连起来
            newLeaf.NextLeaf = oldLeaf.NextLeaf;
            newLeaf.PrevLeaf = oldLeaf;
            oldLeaf.NextLeaf = newLeaf;
            // newLeaf.Parent = oldLeaf.Parent;

            // oldLeaf.Parent.AddKey(list2[0]);

        }
        //传进来的oldNode的儿子数已经大于M
        private void SplitNode(ref BNode oldNode, out BNode newNode)
        {
            newNode = new BNode(M);
            var list = oldNode.Children;
            int count = list.Count;
            var list1 = list.GetRange(0, count / 2);
            var list2 = list.GetRange(count / 2, count - count / 2);

            oldNode.Children = list1;
            newNode.Children = list2;

            oldNode.BuildKeys();
            newNode.BuildKeys();

        }
        #region 节省空间插入
        /// <summary>
        /// 节省空间插入主要是在分裂节点的时候，先看兄弟节点是否有空余位置
        /// 例如假设有2个兄弟节点，一个是2一个是3，现在我往3那边插一个节点
        /// 我先查找到兄弟节点，发现有剩余位置，就把3的最左边的数往兄弟节点挪
        /// 然后再插入
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tree"></param>
        /// <returns></returns>
        private IBNode ComplexInsert(int value, IBNode tree)
        {
            //调整内部节点


            return tree;
        }
        #endregion
    }
}