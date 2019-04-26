using System;

namespace HeapLearn
{
    public interface IHeap
    {
        void MakeEmpty();
        void Insert(int i);
        int DeleteMin();
        int FindMin();

        bool IsEmpty();
        bool IsFull();
        int DecreaseKey(int i, int val);
        int IncreaseKey(int i, int val);
        void BuildHeap(int[] values);

    }
    public interface IHeap<T> where T:IComparable
    {
        void MakeEmpty();
        void Insert(T node);
        T DeleteMin();
        T FindMin();

        bool IsEmpty();
        bool IsFull();
        // T DecreaseKey(T node, int val);
        // T IncreaseKey(T node, int val);
        void BuildHeap(T[] values);
    }
}