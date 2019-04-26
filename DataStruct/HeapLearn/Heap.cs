using System;

namespace HeapLearn
{
    public class Heap : IHeap
    {
        int capacity;
        int size;
        int[] elements;
        //使用一个极小值
        int min = int.MinValue;
        public Heap()
        {
            capacity = 10;
            Init();
        }
        public Heap(int capacity){
            this.capacity = capacity+1;
            Init();
        }
        void Init(){
            size = 0;
            elements = new int[capacity];
            elements[0] = min;
        }

        public int DeleteMin()
        {
            int e = 0;
            if(IsEmpty()){
                e = min;
            }
            else{
                e = elements[1];
                int last = size;
                int now = 1;
                int left = 0;
                int right = 0;
                while( elements[last] > elements[now]){
                    left = now * 2;
                    right = now * 2 + 1;
                    if(left <= size && right <= size){
                        int temp = elements[left] < elements[right]? left:right;
                        elements[now] = elements[temp];
                        now = temp;
                    }
                    else if(left <= size){
                        elements[now] = elements[left];
                        now = left;
                    }
                    else{
                        elements[now] = elements[last];
                        now = last;
                    }
                }
                //置0是为了测试
                elements[last] = 0;
                size--;
            }
            return e;
        }

        public int FindMin()
        {
            if(IsEmpty()){
                return 0;
            }else{
                return elements[1];
            }
        }

        public void Insert(int i)
        {
            if(IsFull()){
            }
            else if(IsEmpty()){
                elements[1] = i;
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
                while(elements[parent] > i){
                    elements[now] = elements[parent];
                    now = parent;
                    parent = now/2;
                }
                
                elements[now] = i;

            }
        }
        int PercolateUp(int index){
                int now = index;
                //父节点是 i/2 左节点是2i,右节点是2i+1
                int parent = now / 2;
                int i = elements[index];
                //使用一个极小值放在0节点，可以避免每次判断parent
                ///while(parent > 0 && elements[parent] > i){
                while(elements[parent] > i){
                    elements[now] = elements[parent];
                    now = parent;
                    parent = now/2;
                }
                if(now != 0){
                    elements[now] = i;
                }
                return i;
        }

        int PrecolateDown(int index){

            int now = index;
            int left = 0;
            int right = 0;
            int current = elements[now];
            int temp = now;
            do{
                elements[now] = elements[temp];
                elements[temp] = current;
                now = temp;
                left = now * 2;
                right = left + 1;
                if(left <= size && right <= size){
                     temp = elements[left] < elements[right]? left:right;
                }
                else if(left <= size){
                    temp = left;
                }
                else{
                    break;
                }
            }while(elements[temp] < current);
            return current;
        }

        public bool IsEmpty() => size == 0;

        public bool IsFull() => size == capacity;

        public void MakeEmpty() => size = 0;

        public int DecreaseKey(int i, int val)
        {
            if(i <= size){
                elements[i] -= val;
                return PercolateUp(i);
            }else{
                throw new Exception("OutofRangeException");
            }
        }

        public int IncreaseKey(int i, int val)
        {
            if(i <= size){
                elements[i] += val;
                return PrecolateDown(i);
            }else{                                                                             
                throw new Exception("OutofRangeException");
            }
        }
        public void BuildHeap(int[] values){
            foreach (var value in values)
            {
                Insert(value);
            }
        }
    }

    public class Heap<T> : IHeap<T> where T: IComparable, new()
    {
        int capacity;
        int size;
        T[] elements;
        //使用一个极小值
        T min = default(T);
        public Heap()
        {
            capacity = 256;
            Init();
        }
        public Heap(int capacity){
            this.capacity = capacity+1;
            Init();
        }
        void Init(){
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
                return min;
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