using System;

namespace HeapLearn
{
    public class LeftHeap<T> where T : IComparable<T>
    {
        Node root;
        public LeftHeap()
        {
            root = null;
        }
        public void Add(T value)
        {
            Node node = new Node(value);
            root = MergeHeap(root, node);
        }
        public void Merge(LeftHeap<T> other)
        {
            if (this == other)
            {
                return;
            }
            Node otherRoot = null;
            if (other != null)
            {
                otherRoot = other.root;
            }
            root = MergeHeap(root, otherRoot);
        }
        public T DeleteMin()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is null");
            }
            T value = root.Value;
            root = MergeHeap(root.Left, root.Right);
            return value;
        }
        public T FindMin()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is null");
            }
            return root.Value;
        }
        public bool IsEmpty()
        {
            return root == null;
        }
        public void makeEmpty()
        {
            root = null;
        }
        private Node MergeHeap(Node left, Node right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            //merge
            Node big = null;
            Node small = null;
            if (left.Value.CompareTo(right.Value) > 0)
            {
                big = left;
                small = right;
            }
            else
            {
                big = right;
                small = left;
            }
            small.Right = MergeHeap(small.Right, big);
            //change
            if (!CheckNpl(small.Left, small.Right))
            {
                var temp = small.Left;
                small.Left = small.Right;
                small.Right = temp;
            }
            small.Npl = GetNpl(small.Right) + 1;
            return small;
        }
        //没有必要
        private int GetNpl(Node node)
        {
            if (node == null)
            {
                return -1;
            }
            return node.Npl;
        }
        private bool CheckNpl(Node left, Node right)
        {
            return GetNpl(left) >= GetNpl(right);
        }
        private sealed class Node
        {
            public int Npl { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
            public Node(T value)
            {
                Value = value;
                Npl = 0;
            }
            public void UpdateNpl()
            {
                BuildNpl(this);
            }

            private int BuildNpl(Node node)
            {
                if (node == null)
                {
                    return -1;
                }
                var leftNpl = BuildNpl(node.Left);
                var rightNpl = BuildNpl(node.Right);

                // node.npl = (leftNpl > rightNpl?rightNpl:leftNpl)+1;
                node.Npl = Math.Min(leftNpl, rightNpl) + 1;
                return node.Npl;
            }
        }
    }
}