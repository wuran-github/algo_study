using System;

namespace Sort{

    public class HeapSort<T> : ISort<T> where T : IComparable<T>
    {
        int count = 0;
        public int Count => count;
        //从小到小排序
        //从大到大改变一些堆的有序性即可，这里就不改了
        public void Sort(T[] array)
        {
            Heap<T> heap = new Heap<T>();
            heap.BuildHeap(array);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = heap.DeleteMin();
            }
        }

    }

}