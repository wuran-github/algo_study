using System;
using System.Collections.Generic;

namespace HeapLearn{
    public interface IBinomialQueue<T>
    {
         void Merge(IBinomialQueue<T> other);
         void Insert(T value);
        T FindMin();
         bool IsEmpty();
         void makeEmpty();
    }
    public class BinomialQueue<T> where T:IComparable<T> {
        private Node[] queue;
        private int capacity;
        private int k;
        private T min;
        public BinomialQueue():this(10){

        }
        public BinomialQueue(int capacity){
            this.capacity = capacity;
            queue = new Node[this.capacity];
            k = 0;
            min = default(T);
        }
        /// <summary>
        /// 测试方法
        /// </summary>
        public void Test(){

        }
        public bool IsEmpty(){
            return k == 0;
        }
        public void Add(T value){

            if(IsEmpty()){
                Node node = new Node(value);
                k = 1;
                queue[0] = node;
                min = value;
            }else{
                BinomialQueue<T> tempQueue = new BinomialQueue<T>(capacity);
                tempQueue.Add(value);
                this.Merge(tempQueue);
            }
        }
        public void DeleteMin(){
            if(IsEmpty()){
                throw new Exception("is Empty");
            }
            int index = -1;
            Node node = null;
            for (int i = 0; i < k; i++)
            {
                node = queue[i];
                if(node!= null){
                    if(node.Value.CompareTo(min) <= 0){
                        index = i;
                        break;
                    }
                }
            }
            //remove Bk
            queue[index] = null;
            //Build B0-Bk-1
            BinomialQueue<T> other = new BinomialQueue<T>();
            int num = 0;
            var sibling = node.FirstChild;
            while(sibling != null){
                
                other.AddNode(sibling, num);
                var temp = sibling.Sibling;
                sibling.Sibling = null;
                sibling = temp;
                num++;
            }
            //merge
            this.Merge(other);
        }
        public void Merge(BinomialQueue<T> other){
            int maxIndex = 0;
            if(other != null){
                maxIndex = Math.Max(k, other.k);
                Node lastNode = null;
                for (int i = 0; i < maxIndex; i++)
                {
                    var node1 = queue[i];
                    var node2 = other.queue[i];   
                    Node[] nodes = MergeTree(node1, node2);
                    if(nodes[0] == null){
                        nodes[0] = lastNode;
                    }
                    else{
                        nodes = MergeTree(nodes[0], lastNode);
                    }
                    lastNode = nodes[1];
                    queue[i] = nodes[0];
                    CheckMin(queue[i]);
                }
                this.queue[maxIndex] = lastNode;
                maxIndex = lastNode == null? maxIndex: maxIndex+1;
                this.k = maxIndex;
                CheckMin(lastNode);
            }
        }
        private void AddNode(Node node, int i){
            queue[i] = node;
            if(k <= i){
                k = i+1;
            }
        }
        private void CheckMin(Node node){
            if(node != null){
                min = node.Value.CompareTo(min) > 0 ? min : node.Value;
            }
        }
        private Node[] MergeTree(Node left, Node right){
            Node[] newNodes = new Node[2];
            if(left == null){
                newNodes[0] = right;
                return newNodes;
            }
            if(right == null){
                newNodes[0] = left;
                return newNodes;
            }
            Node big = null;
            Node small = null;
            if(left.Value.CompareTo(right.Value) > 0){
                big = left;
                small = right;
            }
            else{
                big = right;
                small = left;
            }
            small.AddChild(big);
            newNodes[1] = small;
            return newNodes;
        }
        // public override string ToString(){
        //     string str ="";
        //     for (int i = 0; i < k; i++)
        //     {
        //         var node = queue[i];
        //         Queue<Node> iteartorQueue = new Queue<Node>();
        //         while(node != null){
        //             str += node.Value;
        //             var iterator = node.SiblingIterator();
        //             while(iterator.MoveNext()){
        //                 str+= " " + iterator.Current;
        //                 iteartorQueue.Enqueue(iterator.Current.FirstChild);
        //             }
        //             str +=System.Environment.NewLine;
        //         }
        //     }
        //     return str;
        // }
        private sealed class Node {
            public T Value{get;set;}
            public Node FirstChild{get;set;}
            public Node Sibling{get;set;}
            public Node(T value){
                Value = value;
            }
            public void AddChild(Node child)
            {
                if (FirstChild == null)
                {
                    FirstChild = child;
                }
                else
                {
                    var node = FirstChild;
                    while (node.Sibling != null)
                    {
                        node = node.Sibling;
                    }
                    node.Sibling = child;
                }
            }
            public IEnumerator<Node> SiblingIterator(){
                var sibling = Sibling;
                while(sibling != null){
                    yield return sibling;
                    sibling = sibling.Sibling;
                }
            }
            
        }
    }
    public class BinomialQueue2<T> : IBinomialQueue<T> where T : IComparable<T>
    {
        private int currentSize;
        private Node[] trees;
        public BinomialQueue2(){
            trees = new Node[10];
            currentSize = 0;
        }
        public BinomialQueue2(T value):this(){
            Node node = new Node(value);
            trees[0] = node;
            currentSize = 1;
        }
        public T FindMin()
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            Merge(new BinomialQueue2<T>(value));
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        public void makeEmpty()
        {
            for (int i = 0; i < currentSize; i++)
            {
                trees[i] = null;
            }
            currentSize = 0;
        }

        public void Merge(IBinomialQueue<T> other)
        {
            if(this == other){
                return;
            }

            
        }
        /// <summary>
        /// 大的节点成为小的第一个儿子，会自动转换大小
        /// </summary>
        /// <param name="t1">元素较小的节点</param>
        /// <param name="t2">大的节点</param>
        /// <returns></returns>
        private Node CombineTrees(Node t1, Node t2){
            if(t1.Value.CompareTo(t2.Value) > 0){
                return CombineTrees(t2,t1);
            }
            t2.NextSibling = t1.FirstChild;
            t1.FirstChild = t2;
            return t1;
        }
        /// <summary>
        /// 自己实现的方法，不用判断那多情况
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>大小为2的数组，元素1代表k的二项树，元素2代表k+1的二项树</returns>
        private Node[] MergeTrees(Node t1, Node t2){
            Node[] nodes = new Node[2];
            if(t1 == null){
                nodes[0] = t2;
                return nodes;
            }
            if(t2 == null){
                nodes[0] = t1;
                return nodes;
            }
            //确保t1一定是小节点，t2是大节点
            if(t1.Value.CompareTo(t2.Value) > 0){
                return MergeTrees(t2,t1);
            }
            t2.NextSibling = t1.FirstChild;
            t1.FirstChild = t2;
            nodes[1] = t1;
            return nodes;
        }
        private sealed class Node{
            public T Value{get;set;}
            public Node FirstChild{get;set;}
            public Node NextSibling{get;set;}
            public Node(T value):this(value,null,null){

            }
            public Node(T value, Node child, Node sibling){
                Value = value;
                FirstChild = child;
                NextSibling = sibling;
            }
        }
    }
}