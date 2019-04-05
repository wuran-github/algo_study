using System;
using System.Collections.Generic;
using csharpDemo.ADT;
using System.Linq;

namespace csharpDemo.ADTImplement
{
    public class BNode : IBNode
    {
        public BNode(int M)
        {
            this.M = M;
            Keys = new List<int>();
            Children = new List<IBNode>();
        }
        public int M { get; set; }
        public List<int> Keys { get; set; }
        public BNode Parent { get; set; }
        public List<IBNode> _children;
        /// <summary>
        /// 赋值自动把所有元素的parent设为当前对象
        /// </summary>
        /// <value></value>
        public List<IBNode> Children
        {
            get
            {
                return _children;
            }
            set
            {
                if(value != null){
                    foreach(var node in value){
                        node.Parent = this;
                    }
                }
                _children = value;
            }
        }
        public void AddKey(int key)
        {
            Keys.Add(key);
            Keys.Sort();
        }
        public void InsertChild(IBNode child)
        {
            var key = child.GetMinKey();
            bool inserted = false;
            for (int i = 0; i < Children.Count; i++)
            {
                if (key < Children[i].GetMinKey())
                {
                    inserted = true;
                    Children.Insert(i, child);
                    break;
                }
            }
            if(!inserted){
                Children.Add(child);
            }
            //设置父节点
            child.Parent = this;
            //重新整理key
            BuildKeys();

            

        }
        /// <summary>
        /// 根据children生成key
        /// </summary>
        public void BuildKeys(){
            Keys.Clear();
            for (int i = 1; i < Children.Count; i++)
            {
                Keys.Add(Children[i].GetMinKey());
            }
        }
        public void SortChildren()
        {
            //linq 一步到位
            Children = (List<IBNode>)Children.OrderBy(en => en.GetMinKey());

            // 自己排序
            // int i = Children.Count / 2;

            //重新整理key
            

        }
        public int GetMinKey()
        {
            return Keys[0];
        }
        public List<IBNode> GetSiblings(IBNode node){
            List<IBNode> siblings = new List<IBNode>();
            for (int i = 0; i < GetChildrenNum(); i++)
            {
                if(Children[i].Equals(node)){
                    if(i == 0){//开头
                        siblings.Add(Children[i+1]);
                    }
                    else if(i == (GetChildrenNum() - 1)){//结尾
                        siblings.Add(Children[i-1]);
                    }
                    else{
                        siblings.Add(Children[i-1]);
                        siblings.Add(Children[i+1]);
                    }
                    break;
                }
            }
            return siblings;
        }
        public bool RemoveChildren(IBNode node){
            bool res = Children.Remove(node);
            if(res){
                BuildKeys();
            }
            return res;
        }
        public bool IsLeaf()
        {
            return false;
        }

        public int GetChildrenNum()
        {
            return Children.Count;
        }



        public void InsertLeafChild(int value)
        {
            
        }

        public void InsertNodeChild(IBNode value)
        {
            InsertChild(value);
        }

        public bool RemoveLeafChild(int value)
        {
            return false;
        }

        public bool RemoveNodeChild(IBNode value)
        {
            return RemoveChildren(value);
        }
    }
}