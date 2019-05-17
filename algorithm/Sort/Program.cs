using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Sort
{
    class Program
    {
        static int[] ints ={34,8,64,51,32,21};
        static int[] ints2 = {13,81,43,31,57,75,0,43,26,92,65};
        static int[] sorted = {8,21,32,34,51,64};
        static ISort<int> sorter = null;
        static void Main(string[] args)
        {
            SortTest();
        }

        static void SortTest(){
            // InsertionSortTest();
            // ShellSortTest();
            // HeapSortTest();
            // MergeSortTest();
            QuickSortTest();
        }
        static void InsertionSortTest(){
            int[] datas = ints.ToArray();
            sorter = new InsertionSort<int>();
            sorter.Sort(datas);
            
            Print(datas);
            // System.Console.WriteLine(Assert(datas));
        
        }
        static void ShellSortTest(){
            int[] datas = ints.ToArray();
            sorter = new ShellSort<int>();
            sorter.Sort(datas);
            
            Print(datas);
            // System.Console.WriteLine(Assert(datas));
        
        }
        static void HeapSortTest(){
            int[] datas = ints.ToArray();
            sorter = new HeapSort<int>();
            sorter.Sort(datas);
            Print(datas);
        }
        static void MergeSortTest(){
            int[] datas = ints.ToArray();
            sorter = new MergeSort<int>();
            sorter.Sort(datas);
            Print(datas);
        }
        static void QuickSortTest(){
            int[] datas = ints2.ToArray();
            sorter = new QuickSort<int>();
            sorter.Sort(datas);
            Print(datas);
        }

        #region auxiliary method
        static bool Assert(int[] array){
           return sorted.Except(array).Count() == 0;
        }
        static void Print<T>(IEnumerable<T> array){
            System.Console.WriteLine($"sort count:{sorter.Count}");
            foreach (var item in array)
            {
                System.Console.WriteLine(item);
            }
        }
        #endregion
    }
}
