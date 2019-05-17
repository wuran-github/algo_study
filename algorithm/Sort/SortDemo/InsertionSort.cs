using System;

namespace Sort{

    public class InsertionSort<T> : ISort<T> where T : IComparable<T>
    {
        int count = 0;

        public int Count => count;

        public void Sort(T[] array)
        {
            count = 0;
            T temp = default(T);
            int length = array.Length;
            for (int i = 1; i < length; i++)
            {
                int j = i -1;
                temp = array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    count++;
                    if(array[j].CompareTo(temp) > 0){
                        array[j+1] = array[j];
                    }else{
                        break;
                    }
                }
                array[j+1] = temp;

            }
        }
    }

}