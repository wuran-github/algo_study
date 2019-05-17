using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort{

    public class QuickSort<T> : ISort<T> where T : IComparable<T>
    {
        int count = 0;
        public int Count => count;

        public void Sort(T[] array)
        {
            // var list = array.ToList();
            // SimplySort(list);
            // list.CopyTo(array);
            QuickSortArray(array,0, array.Length -1);
        }

        /// <summary>
        /// 快速排序，和归并排序一样，只需要传入索引即可
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">开始索引</param>
        /// <param name="end">结束索引</param>
        void QuickSortArray(T[] array,int start, int end){
            //如果元素是0或1，返回
            if(end - start > 0){
                //第一步，求中值枢纽元
                T left = array[start];
                T right = array[end];
                T center = array[(end+start)/2];
                int midIndex = GetMidIndex(array, start, end);
                //第二步，开始调整
                //先交换
                T pivot = array[midIndex];
                array[midIndex] = array[end];
                array[end] = pivot;
                int j = end - 1;
                int i = start;
                //开始
                while(true){
                    while(array[i].CompareTo(pivot) < 0){
                        i++;
                    }
                    while(array[j].CompareTo(pivot) > 0){
                        j--;
                    }
                    //如果i=j，说明这个数就是和pivot相等，直接结束
                    if(i < j){
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                    else{
                        break;
                    }
                }
                //交换i和pivot
                array[end] = array[i];
                array[i] = pivot;
                //此时分为了2组，对2组继续进行排序
                QuickSortArray(array,start, i-1);
                QuickSortArray(array,i+1, end);
            }
        }
        int GetMidIndex(T[] array,int start, int end)
        {
            int index = 0;
            T left = array[start];
            T right = array[end];
            int mid = (end+start)/2;
            T center = array[mid];
            if (left.CompareTo(right) > 0)
            {
                if (center.CompareTo(left) > 0)
                {
                    index = start;
                }
                else
                {
                    if (center.CompareTo(right) > 0)
                    {
                        index = mid;
                    }
                    else
                    {
                        index = end;
                    }
                }
            }
            else
            {
                if (center.CompareTo(right) > 0)
                {
                    index = end;
                }
                else
                {
                    if (center.CompareTo(left) > 0)
                    {
                        index = mid;
                    }
                    else
                    {
                        index = start;
                    }
                }
            }
            return index;
        }
        //简单排序
        void SimplySort(List<T> array){
            //选择中间的数作为项
            if(array.Count > 1){
                int index = array.Count /2;
                List<T> smaller = new List<T>();
                List<T> equality = new List<T>();
                List<T> bigger = new List<T>();
                T temp = array[index];
                for (int i = 0; i < array.Count; i++)
                {
                    if(temp.CompareTo(array[i]) > 0){
                        smaller.Add(array[i]);
                    }
                    else if(temp.CompareTo(array[i]) == 0){
                        equality.Add(array[i]);
                    }
                    else{
                        bigger.Add(array[i]);
                    }
                }
                SimplySort(smaller);
                SimplySort(equality);
                SimplySort(bigger);
                //combine
                array.Clear();
                array.AddRange(smaller);
                array.AddRange(equality);
                array.AddRange(bigger);
            }
        }
    }

}