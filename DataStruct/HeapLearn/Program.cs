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
            QueueUpEventMockTest();
        }
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
    }
}
