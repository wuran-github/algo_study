using System;

namespace HeapLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            // HeapTest();
            // SelectionProblemTest(4);
            // SelectionProblemBtest(4);
            // QueueUpEventMockTest();
            // LeftHeapTest();
            // SkewHeapTest();
            BinomialQueueTest();
        }
        #region Heap
        static void HeapTest(){
            IHeap heap = new Heap(15);
            int[] testArray = {13,14,16,19,21,19,68,65,26,32,31};
            foreach(var i in testArray){
                heap.Insert(i);
            }
            heap.DeleteMin();
        }
        static void SelectionProblemTest(int k){
            IHeap heap = new Heap(256);
            int[] input = {1,2,3,4,5,6,7,8,9,10,11};
            int result = 0;
            heap.BuildHeap(input);
            for (int i = 0; i < k; i++)
            {
                result = heap.DeleteMin();
            }
            System.Console.WriteLine(result);
        }
        static void SelectionProblemBtest(int k){
             IHeap heap = new Heap(256);
            int[] input = {1,2,3,4,5,6,7,8,9,10,11};
            int result = 0;
            for (int i = 0; i < k; i++)
            {
                heap.Insert(input[i]);
            }
            for (int i = k; i < input.Length; i++)
            {
                if(input[i] > heap.FindMin()){
                    heap.DeleteMin();
                    heap.Insert(input[i]);
                }
            }
            result = heap.FindMin();
            System.Console.WriteLine(result);
        }
        static void QueueUpEventMockTest(){
            EventMock mock = new EventMock();
            mock.BeginMock();
        }
        #endregion
        static void LeftHeapTest(){
            int[] values = {3,10,8,21,14,23,17,26};
            int[] values2 = {37,33,24,18,18,12,7,6};
            LeftHeap<int> heap1 = new LeftHeap<int>();
            LeftHeap<int> heap2 = new LeftHeap<int>();
            foreach (var v in values)
            {
                heap1.Add(v);
            }
            foreach (var v in values2)
            {
                heap2.Add(v);
            }
            heap1.Merge(heap2);
        }
        static void SkewHeapTest(){
            int[] values = {3,10,8,21,14,23,17,26};
            int[] values2 = {37,33,24,18,18,12,7,6};
            SkewHeap<int> heap1 = new SkewHeap<int>();
            SkewHeap<int> heap2 = new SkewHeap<int>();
            foreach (var v in values)
            {
                heap1.Add(v);
            }
            foreach (var v in values2)
            {
                heap2.Add(v);
            }
            heap1.Merge(heap2);
        }
        static void BinomialQueueTest(){
            int[] datas = {13,23,51,24,65,12,21,24,65,14,26,16,18};
            BinomialQueue<int> bQueue = new BinomialQueue<int>();
            foreach (var data in datas)
            {
                bQueue.Add(data);
            }
            bQueue.DeleteMin();
        }
    }
}
