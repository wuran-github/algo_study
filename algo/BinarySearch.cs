using System;
namespace csharpDemo.algo
{
    /// <summary>
    /// 
    /// </summary>
    public class BinarySearch
    {
        public int[] A { get; set; }
        public int X { get; set; }
        public int N { get; set; }
        public int LineAlgo()
        {
            int i = -1;
            for (int l = 0; l < N; l++)
            {
                if (A[l] == X)
                {
                    i = l;
                }
            }
            return i;
        }
        public int MidSearch(){
            int center = N/2;
            int i = -1;
            int left = 0;
            int right = N-1;

            while(left <= right){
                if(center > N-1 || center < 0){
                    break;
                }
                if(A[center] == X){
                    i = center;
                    break;
                }
                else if(A[center] < X){
                    left = center + 1;

                }
                else if(A[center] > X){
                    right = center - 1;
                }

                center = (left+right)/2;
            }

            return i;
        }
    }
}
