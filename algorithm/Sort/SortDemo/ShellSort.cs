using System;
using System.Collections.Generic;

namespace Sort{

    public class ShellSort<T> : ISort<T> where T : IComparable<T>
    {
        public int Count => count;
        int count = 0;
        int[] hibbard = {0,1,3,7};
        void Init(){
            List<int> hibbard = new List<int>();
            hibbard.Add(0);
            int k = 1;
            for(int i = 0;i< 10;i++){
                hibbard.Add((k<<1) -1);
            }
            this.hibbard = hibbard.ToArray();
        }
        public void Sort(T[] array)
        {
            
            count = 0;
            int k = 3;
            //增量序列
            for(int h = hibbard[k]; h > 0;h = hibbard[--k])//更好的增量序列
            //for (int h = array.Length /2; h > 0 ; h /= 2)
            {
                //对间隔为k的元素进行排序,
                //实际上是把间隔为k的元素拿出来做一次排序
                for (int i = h; i < array.Length; i++)
                {
                    int j = i;
                    T temp = array[i];
                    
                    for(j = i; j>= h; j -= h){
                        count++;
                        if(temp.CompareTo(array[j - h]) < 0){
                            array[j] = array[j - h];
                        }else{
                            break;
                        }
                    }
                    array[j] = temp;
                }
            }
            
        }
    }

}