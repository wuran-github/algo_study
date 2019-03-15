using System;
namespace csharpDemo
{
    public class MaxSequence
    {
        public int[] A;
        public int N;
        public int AlgoOne()
        {
            int thisSum = 0;
            int MaxSum = 0;
            for (int i = 0; i < N; i++)
            {

                for (int j = i; j < N; j++)
                {
                    thisSum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        thisSum += A[k];
                    }
                    if (thisSum > MaxSum)
                    {
                        MaxSum = thisSum;
                    }

                }
            }
            return MaxSum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int AlgoTwo()
        {
            int thisSum = 0;
            int MaxSum = 0;
            for (int i = 0; i < N; i++)
            {
                thisSum = 0;
                for (int j = i; j < N; j++)
                {
                    thisSum += A[j];
                    if (thisSum > MaxSum)
                    {
                        MaxSum = thisSum;
                    }
                }
            }
            return MaxSum;
        }
        public int AlgoThree(int left, int right)
        {
            //递归的基准情形
            if (left == right)
            {
                if (A[left] > 0)
                {
                    return A[left];
                }
                else
                {
                    return 0;
                }
            }


            int center = (right + left) / 2;
            //求左半部
            int leftSum = AlgoThree(left, center);

            //求右半部分
            int rightSum = AlgoThree(center + 1, right);

            //求横跨的
            int leftBoderSum = 0;
            int rightBoderSum = 0;
            int maxLeftBoderSum = 0;
            int maxRightBoderSum = 0;

            //求包含左半部最后一个元素的最大值
            //从中间往前加
            for (int i = center; i >= left; i--)
            {
                leftBoderSum += A[i];
                if (leftBoderSum > maxLeftBoderSum)
                {
                    maxLeftBoderSum = leftBoderSum;
                }
            }

            //求包含右半部最前一个元素的最大值
            //从中间往后加
            for (int i = center + 1; i <= right; i++)
            {
                rightBoderSum += A[i];
                if (rightBoderSum > maxRightBoderSum)
                {
                    maxRightBoderSum = rightBoderSum;
                }
            }

            //对比三个结果



            return getMax3(leftSum, rightSum, maxLeftBoderSum + maxRightBoderSum);
        }

        int getMax3(int n1, int n2, int n3)
        {
            if (n1 > n2)
            {
                if (n1 > n3)
                {
                    return n1;
                }
                else
                {
                    return n3;
                }
            }
            else
            {
                if (n2 > n3)
                {
                    return n2;
                }
                else
                {
                    return n3;
                }
            }
        }
        public int AlgoFour(){
            int thisSum = 0;
            int MaxSum = 0;
            for(int i =0 ;i<N;i++){
                thisSum += A[i];
                if(thisSum > MaxSum){
                    MaxSum = thisSum;
                }
                //当序列小于0，说明需要舍弃了，不然必定不是最大
                //重新开始计算
                else if(thisSum < 0){
                    thisSum = 0;
                }
                
            }
            return MaxSum;
        }
    }
}
