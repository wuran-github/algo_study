using System;
using System.Diagnostics;
using csharpDemo.algo;
namespace csharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            // int before = 0;
            // int after = 0;
            // before = DateTime.Now.Millisecond;


            // MaxSequenceAlgo();
            // BinarySearchAlgo();
            // GetGcd();
            // Pow();



            watch.Stop();
            // after = DateTime.Now.Millisecond;
            // System.Console.WriteLine(after-before);
            System.Console.WriteLine(watch.Elapsed.Milliseconds); 
        }
        #region 子序列
        /// <summary>
        /// 最大子序列
        /// </summary>
        public static void MaxSequenceAlgo(){
                        int[] A ={-2,11,-4,13,-5,-2};
            int N = 6;
            MaxSequence sequence = new MaxSequence(){
                A = A,
                N = N,
            };
            
            Console.WriteLine("algo 1:"+sequence.AlgoOne());
            Console.WriteLine("algo 2:"+sequence.AlgoTwo());
            Console.WriteLine("algo 3:"+sequence.AlgoThree(0,5));
            Console.WriteLine("algo 4:"+sequence.AlgoFour());
        }
        #endregion
        #region 对分查找
        /// <summary>
        /// 对分查找
        /// </summary>
        public static void BinarySearchAlgo(){
            int[] A = {1,2,3,4,5,6,7};
            int X = -1;
            int N = 7;
            var binarySearch = new BinarySearch(){
                A = A,
                X = X,
                N = N,
            };
            System.Console.WriteLine("i:"+binarySearch.MidSearch());
        }
        #endregion
        #region 辗转相除
        public static void GetGcd(){
            int n = 50;
            int m = 15;
            var gcd = new Gcd();
            System.Console.WriteLine("GCD({0},{1}) = {2}",n,m,gcd.Euclidean(n,m));
        }
        #endregion
        #region 幂运算
        public static void Pow(){
            Pow pow = new Pow();

            System.Console.WriteLine(pow.GetPow(2,20)); 

        }
        #endregion
        
    }
}
