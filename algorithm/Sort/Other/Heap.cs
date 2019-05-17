using System;

namespace Sort
{
    public class Heap<T> where T: IComparable<T>
    {
        int capacity;
        int size;
        T[] elements;
        bool isMin = true;
        //使用一个极小值
        T min = default(T);
        public Heap():this(256)
        {
            
        }
        public Heap(int capacity, T min = default(T)){
            
            this.capacity = capacity+1;
            this.min = min;
            size = 0;
            elements = new T[capacity];
            elements[0] = min;
        }

        public T DeleteMin()
        {
            T e;
            if(IsEmpty()){
                e = min;
            }
            else{
                e = elements[1];
                int last = size;
                int now = 1;
                int left = 0;
                int right = 0;
                int temp = 0;
                while( elements[last].CompareTo(elements[now]) > 0){
                    left = now * 2;
                    right = left + 1;
                    if(left <= size && right <= size){
                        temp = elements[left].CompareTo(elements[right]) < 0? left:right;
                    }
                    else if(left <= size){
                        temp = left;
                    }
                    else{
                        temp = last;
                    }
                    if(elements[last].CompareTo(elements[temp]) < 0){
                        elements[now] = elements[last];
                    }
                    else{
                        elements[now] = elements[temp];
                        now = temp;
                    }
                }
                //置0是为了测试
                elements[last] = default(T);
                size--;
            }
            return e;
        }

        public T FindMin()
        {
            if(IsEmpty()){
                throw new Exception("Heap is Empty");
            }else{
                return elements[1];
            }
        }
        public void Insert(T node)
        {
            if(IsFull()){
                throw new Exception("Heap is full");
            }
            else if(IsEmpty()){
                elements[1] = node;
                size++;
            }
            else
            {
                size++;
                int now = size;
                //父节点是 i/2 左节点是2i,右节点是2i+1
                int parent = now / 2;
                
                //使用一个极小值放在0节点，可以避免每次判断parent
                ///while(parent > 0 && elements[parent] > i){
                while(node.CompareTo(elements[parent]) < 0){
                    elements[now] = elements[parent];
                    now = parent;
                    parent = now/2;
                }
                
                elements[now] = node;

            }
        }
        T PercolateUp(int index){
                int now = index;
                //父节点是 i/2 左节点是2i,右节点是2i+1
                int parent = now / 2;
                T node = elements[index];
                //使用一个极小值放在0节点，可以避免每次判断parent
                ///while(parent > 0 && elements[parent] > i){
                while(node.CompareTo(elements[parent]) < 0){
                    elements[now] = elements[parent];
                    now = parent;
                    parent = now/2;
                }
                if(now != 0){
                    elements[now] = node;
                }
                return node;
        }

        T PrecolateDown(int index){

            int now = index;
            int left = 0;
            int right = 0;
            T current = elements[now];
            int temp = now;
            do{
                elements[now] = elements[temp];
                elements[temp] = current;
                now = temp;
                left = now * 2;
                right = left + 1;
                if(left <= size && right <= size){
                     temp = elements[left].CompareTo(elements[right]) < 0? left:right;
                }
                else if(left <= size){
                    temp = left;
                }
                else{
                    break;
                }
            }while(elements[temp].CompareTo(current) < 0);
            return current;
        }
        private bool GreatThenOrLessThen(T left, T right){
            if(isMin){
                return left.CompareTo(right) < 0;
            }
            return left.CompareTo(right) > 0;
        }
        public bool IsEmpty() => size == 0;

        public bool IsFull() => size == capacity;

        public void MakeEmpty() => size = 0;

        // public T DecreaseKey(int i, int val)
        // {
        //     if(i <= size){
        //         elements[i] -= val;
        //         return PercolateUp(i);
        //     }else{
        //         throw new Exception("OutofRangeException");
        //     }
        // }

        // public int IncreaseKey(int i, int val)
        // {
        //     if(i <= size){
        //         elements[i] += val;
        //         return PrecolateDown(i);
        //     }else{                                                                             
        //         throw new Exception("OutofRangeException");
        //     }
        // }
        public void BuildHeap(T[] values){
            foreach (var value in values)
            {
                Insert(value);
            }
        }
    }
}