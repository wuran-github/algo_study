using System;
using System.Collections.Generic;
using BPlusTree.ADT;

namespace BPlusTree.ADTImplement
{
    public class BLeaf : IBNode
    {
        public BLeaf(int M)
        {
            this.M = M;
            Values = new List<int>();
        }

            
        
        public int M{get;set;}
        public List<int> Values{get;set;}
        public BNode Parent{get;set;}
        public BLeaf NextLeaf{get;set;}
        public BLeaf PrevLeaf{get;set;}
        /// <summary>
        /// 加入后自动排序
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(int value){
            Values.Add(value);
            Values.Sort();
        }
        public bool RemoveValue(int value){
            bool res = Values.Remove(value);
            return res;
        }
        public int GetMinKey(){
            return Values[0];
        }
        public int GetChildrenNum(){
            return Values.Count;
        }
        public bool IsLeaf()
        {
            return true;
        }

        public void InsertLeafChild(int value)
        {
            AddValue(value);
        }

        public void InsertNodeChild(IBNode value)
        {
            
        }

        public bool RemoveLeafChild(int value)
        {
            return RemoveValue(value);
        }

        public bool RemoveNodeChild(IBNode value)
        {
            return false;
        }
    }
}