using System;
namespace csharpDemo.algo
{
    /// <summary>
    /// 幂运算，使用递归的方法减少运算次数
    /// </summary>
    public class Pow
    {
        public int GetPow(int x,int n){
            if(n == 0){
                return 1;
            }
            if(n == 1){
                return x;
            }
            if(n%2 == 0){
                //这是双递归，用错了
                // return GetPow(x,n/2)*GetPow(x,n/2);
                return GetPow(x*x,n/2);
            }
            else{
                // return GetPow(x,n/2)*GetPow(x,n/2)*x;
                return GetPow(x*x,n/2)*x;
            }
        }
    }
}
