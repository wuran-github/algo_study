using System;
namespace csharpDemo.algo
{
    public class Gcd
    {
        /// <summary>
        /// 默认n大于m，如果n小于m第一次循环会把他们调转
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Euclidean(int n, int m)
        {
            int rem = 0;
            while (m > 0)
            {
                rem = n % m;
                n = m;
                m = rem;
            }
            return n;
        }
    }
}
