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
         int Count{get;}
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
    public class BinomialQueue2<T> where T : IComparable<T>
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

        public int Count => currentSize;

        public T FindMin()
        {
            int index = FindMinIndex();
            return trees[index].Value;
        }
        public T DeleteMin(){
            int index = FindMinIndex();
            var node = trees[index];
            trees[index] = null;
            BinomialQueue2<T> newQueue = new BinomialQueue2<T>();
            //第k个节点有k-1个子节点,由于节点存放是从大到小的，所以反向遍历
            var child = node.FirstChild;
            for (int i = index - 1; i >= 0; i--)
            {
                newQueue.trees[i] = child;
                child = child.NextSibling;
                newQueue.trees[i].NextSibling = null;
            }
            newQueue.currentSize = index;
            //如果是最后一棵树，那么树被删除根放到另外一个二项队列里了
            //所以现在只有currentSize -1 棵树
            if(index == Count - 1){
                currentSize--;
            }
            Merge(newQueue);
            return node.Value;
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

        public void Merge(BinomialQueue2<T> other)
        {
            if(this == other){
                return;
            }
            Node carry = null;
            int maxIndex = Math.Max(Count, other.Count);
            for (int i = 0; i < maxIndex; i++)
            {
                Node newNode = null;
                Node t1 = this.trees[i];
                Node t2 = other.trees[i];
                Node[] nodes = MergeTrees(t1,t2);
                //t1 t2均为Null 或者均有值
                //当前节点可以直接设为上一次增加的节点
                if(nodes[0] == null){
                    newNode = carry;
                    carry = nodes[1];
                }else{//如果有值，必然nodes[1]无值
                    //如果carry不为空，就合并，否则就返回nodes[0]
                    nodes = MergeTrees(nodes[0],carry);
                    newNode = nodes[0];
                    carry = nodes[1];
                }
                trees[i] = newNode;
                //顺便清空other
                other.trees[i] = null;
            }
            //加一
            if(carry!=null){
                trees[maxIndex] = carry;
                this.currentSize = maxIndex+1;
            }
            other.currentSize = 0;
        }
        private int FindMinIndex(){
            if(IsEmpty()){
                throw new Exception("queue is Empty");
            }
            Node minNode = trees[0];
            int minIndex = 0;
            for (int i = 0; i < Count; i++)
            {
                var node = trees[i];
                if(node != null){
                    if(minNode == null){
                        minNode = node;
                        minIndex = i;
                    }
                    else{
                        if(minNode.Value.CompareTo(node.Value) > 0){
                            minNode = node;
                            minIndex = i;
                        }
                    }
                }
            }
            return minIndex;
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