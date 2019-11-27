using System;
using System.Linq;
namespace Sort{

    public class MergeSort<T> : ISort<T> where T : IComparable<T>
    {
        int count = 0;
        public int Count => count;
        
        public T[] Sort(T[] array)
        {
            // //因为返回的是新的对象，而不是改变原来的对象
            // T[] temp = array.ToArray();
            // T[] left = null;
            // T[] right = null;
            // SplitArray(array, out left, out right);
            // temp = Merge(left, right);
            // temp.CopyTo(array,0);
            #region 直接修改原本对象的方法，但是这个方法存在问题
            // int center = (array.Length-1)/2;
            // MergeArray(array, 0,center+1,array.Length - 1);
            #endregion
            #region 更完善的做法
            T[] temp = new T[array.Length];
            // MergeArray2(array,0,array.Length - 1);
            MergeArray2(array,temp,0,array.Length - 1);
            #endregion
            return array;
        }
        #region 更好的想法直到最后才创建数组
        //
        /// <summary>
        /// 根本不需要rightPos，只需要传递两端即可
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left">数组开始索引</param>
        /// <param name="right">数组结束索引</param>
        private void MergeArray2(T[] array, int left, int right){
            //如果索引不相等，说明数组元素大于1，需要切分
            if(left < right){
                //对半切分
                int center = (left+right)/2;
                MergeArray2(array,left, center);
                MergeArray2(array,center+1,right);
                //切分完毕了，开始合并排序
                //每次创建临时数组法
                MergeByTemp(array,left,center+1,right);
                //用一个大小相等的数组的方法

            }
        }
        private void MergeArray2(T[] array, T[] temp, int left, int right){
            //如果索引不相等，说明数组元素大于1，需要切分
            if(left < right){
                //对半切分
                int center = (left+right)/2;
                MergeArray2(array,temp,left, center);
                MergeArray2(array,temp,center+1,right);
                //切分完毕了，开始合并排序
                //用一个大小相等的数组的方法
                MergeByTemp(array,temp,left,center+1,right);
            }
        }
        /// <summary>
        /// 一直使用一个数组，不用每次都创建
        /// </summary>
        /// <param name="array"></param>
        /// <param name="temp"></param>
        /// <param name="leftPos"></param>
        /// <param name="rightPos"></param>
        /// <param name="rightEnd"></param>
        private void MergeByTemp(T[] array,T[] temp, int leftPos,int rightPos, int rightEnd){
            int Actr = leftPos;
            int Bctr = rightPos;
            int Cctr = leftPos;
            while(Actr < rightPos && Bctr <= rightEnd){
                if(array[Actr].CompareTo(array[Bctr]) < 0){
                    temp[Cctr] = array[Actr];
                    Actr++;
                }
                else{
                    temp[Cctr] = array[Bctr];
                    Bctr++;
                }
                Cctr++;
            }
            if(Actr == rightPos){
                Array.Copy(array,Bctr,temp,Cctr,rightEnd + 1 - Bctr);
            }
            else{
                Array.Copy(array,Actr,temp,Cctr,rightPos - Actr);
            }
            //把数组复制回去
            int elementCount = rightEnd - leftPos + 1;
            int l = leftPos;
            for(int i = 0; i< elementCount;i++){
                array[leftPos] = temp[leftPos];
                leftPos++;
            }
        }
        private void MergeByTemp(T[] array, int leftPos,int rightPos, int rightEnd){
            T[] temp = new T[rightEnd - leftPos + 1];
            int Actr = leftPos;
            int Bctr = rightPos;
            int Cctr = 0;
            while(Actr < rightPos && Bctr <= rightEnd){
                if(array[Actr].CompareTo(array[Bctr]) < 0){
                    temp[Cctr] = array[Actr];
                    Actr++;
                }
                else{
                    temp[Cctr] = array[Bctr];
                    Bctr++;
                }
                Cctr++;
            }
            if(Actr == rightPos){
                Array.Copy(array,Bctr,temp,Cctr,rightEnd + 1 - Bctr);
            }
            else{
                Array.Copy(array,Actr,temp,Cctr,rightPos - Actr);
            }
            //把数组复制回去
            int l = leftPos;
            for(int i = 0; i< temp.Length;i++){
                array[leftPos] = temp[i];
                leftPos++;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="leftPos">左数组开始索引，到rightPos - 1</param>
        /// <param name="rightPos">右数组开始索引，到rightEnd</param>
        /// <param name="rightEnd">右数组结束索引</param>
        private void MergeArray(T[] array, int leftPos, int rightPos, int rightEnd){
            if(rightPos - leftPos != 1){
                MergeArray(array,leftPos, (leftPos+rightPos)/2, rightPos - 1 - leftPos);
            }
            if(rightEnd +1 - rightPos != 1){
                //要保证rightPos 大于 leftPos，正如第一次调用一样，应该为长度/2+1 
                MergeArray(array,rightPos,(rightEnd+1+ rightPos)/2, rightEnd);
            }
            T[] temp = new T[rightEnd - leftPos + 1];
            int Actr = leftPos;
            int Bctr = rightPos;
            int Cctr = 0;
            while(Actr < rightPos && Bctr <= rightEnd){
                if(array[Actr].CompareTo(array[Bctr]) < 0){
                    temp[Cctr] = array[Actr];
                    Actr++;
                }
                else{
                    temp[Cctr] = array[Bctr];
                    Bctr++;
                }
                Cctr++;
            }
            if(Actr == rightPos){
                Array.Copy(array,Bctr,temp,Cctr,rightEnd + 1 - Bctr);
            }
            else{
                Array.Copy(array,Actr,temp,Cctr,rightPos - Actr);
            }
            //把数组复制回去
            int l = leftPos;
            for(int i = 0; i< temp.Length;i++){
                array[leftPos] = temp[i];
                leftPos++;
            }
        }
        #endregion
        #region 原始想法，每次都创建一个数组，这样很浪费空间和时间
        private void SplitArray(T[] array, out T[] left, out T[] right){
            left = new T[array.Length/2];
            right = new T[array.Length - array.Length/2];
            Array.Copy(array,left,array.Length/2);
            Array.Copy(array, array.Length/2, right,0,array.Length - array.Length/2);
        }
        private T[] Merge(T[] left, T[] right){
            T[] temp = new T[left.Length+right.Length];
            int Actr = 0;
            int Bctr = 0;
            int Cctr = 0;
            int lLength = left.Length;
            int rLength = right.Length;
            //递归归并排序
            if(left.Length != 1){
                T[] lleft = null;
                T[] lright = null;
                SplitArray(left, out lleft, out lright);
                left = Merge(lleft, lright);
            }
            if(right.Length != 1){
                T[] rleft = null;
                T[] rright = null;
                SplitArray(right, out rleft, out rright);
                right = Merge(rleft, rright);
            }

            while(Actr < left.Length && Bctr < right.Length){
                if(left[Actr].CompareTo(right[Bctr]) < 0){
                    temp[Cctr] = left[Actr];
                    Actr++;
                }
                else{
                    temp[Cctr] = right[Bctr];
                    Bctr++;
                }
                Cctr++;
            }
            if(Actr == left.Length){
                Array.Copy(right,Bctr,temp,Cctr,right.Length - Bctr);
            }else{
                Array.Copy(left,Actr,temp,Cctr,left.Length-Actr);
            }
            return temp;
        }
        #endregion
    }

}