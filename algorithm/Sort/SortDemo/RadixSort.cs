using System;
using System.Collections.Generic;

namespace Sort{

    public class RadixSort : ISort<int> {
            int max = 999;

        public int Count => 0;
        public List<int> data = new List<int>();
        public List<Queue<int>> buckets = new List<Queue<int>>();
        public int Heightest = 0;
        public RadixSort(){
            // init bucket
            for (int i = 0; i < 10; i++)
            {
                Queue<int> bucket = new Queue<int>();
                buckets.Add(bucket);
            }
        }
        public int[] Sort(int[] array)
        {
            data = new List<int>(array);
            //必须找到最高位是几位
            //要么遍历找，要么指定一次来找
            foreach (var num in array)
            {
                var l = Math.Abs(num).ToString().Length;
                if(l > Heightest){
                    Heightest = l;
                }
            }
            for (int i = 0; i < Heightest; i++)
            {
                SortBuckets(i);
            }
            array = data.ToArray();
            return array;
        }

        public void SortBuckets(int n){
            foreach (var num in data)
            {
                var figure = GetDigitNum(num, n);
                buckets[figure].Enqueue(num);
            }
            
            data.Clear();
            //放回数组里
            foreach (var bucket in buckets)
            {
                while(bucket.Count!=0){
                    data.Add(bucket.Dequeue());
                }
            }
        }
        /// <summary>
        /// 求数位上得数字规则如下：
        /// 求第n位上得数字
        /// result = (number % 10^n+2) / 10^n+1
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public int GetDigitNum(int number, int digit){
            
            int n = (int)Math.Pow(10,digit+1);
            int result = (number % n*10) / n;
            return result;
        }
    }

}