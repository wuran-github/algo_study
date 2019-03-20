using System;
using System.Diagnostics;
using csharpDemo.algo;
using csharpDemo.ADT;
using csharpDemo.ADTImplement;
using System.Linq;
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
            

            // 表
            //ListAlgo();
            //PolynomialList();
            //RadixSortTest();
            MultiList();



            watch.Stop();
            // after = DateTime.Now.Millisecond;
            // System.Console.WriteLine(after-before);
            // System.Console.WriteLine(watch.Elapsed.Milliseconds);
        }
    #region 第二章 算法分析
        #region 子序列
        /// <summary>
        /// 最大子序列
        /// </summary>
        public static void MaxSequenceAlgo()
        {
            int[] A = { -2, 11, -4, 13, -5, -2 };
            int N = 6;
            MaxSequence sequence = new MaxSequence()
            {
                A = A,
                N = N,
            };

            Console.WriteLine("algo 1:" + sequence.AlgoOne());
            Console.WriteLine("algo 2:" + sequence.AlgoTwo());
            Console.WriteLine("algo 3:" + sequence.AlgoThree(0, 5));
            Console.WriteLine("algo 4:" + sequence.AlgoFour());
        }
        #endregion
        #region 对分查找
        /// <summary>
        /// 对分查找
        /// </summary>
        public static void BinarySearchAlgo()
        {
            int[] A = { 1, 2, 3, 4, 5, 6, 7 };
            int X = -1;
            int N = 7;
            var binarySearch = new BinarySearch()
            {
                A = A,
                X = X,
                N = N,
            };
            System.Console.WriteLine("i:" + binarySearch.MidSearch());
        }
        #endregion
        #region 辗转相除
        public static void GetGcd()
        {
            int n = 50;
            int m = 15;
            var gcd = new Gcd();
            System.Console.WriteLine("GCD({0},{1}) = {2}", n, m, gcd.Euclidean(n, m));
        }
        #endregion
        #region 幂运算
        public static void Pow()
        {
            Pow pow = new Pow();

            System.Console.WriteLine(pow.GetPow(2, 20));

        }
        #endregion
    #endregion 
    #region 表
        public static void ListAlgo(){
            IList<Node,int> list = new LinkList<Node,int>();
            list.Append(1);
            list.Append(2);
            Node node = (Node)list.FindPrevious(1);
            list.Insert(3,node);
            list.PrintList();
            // System.Console.WriteLine("delete");
            // list.Delete(3);
            // list.PrintList();
        }
        public static void PolynomialList(){
            //左边是系数，右边是次幂
            // string[] leftPolys = {"2,1492","10,1000","5,14","5,1","1,0"};
            // string[] rightPolys = {"3,1990","-2,1492","11,1","5,0"};
            string[] leftPolys = {"2,1492","10,1000","5,14","5,1","1,0"};
            string[] rightPolys = {"3,1990","-2,1492","11,1","5,0"};
            
            
            PolyList left = new PolyList();
            PolyList right = new PolyList();
            foreach (var poly in leftPolys)
            {
                string[] param = poly.Split(',');
                int coefficient = int.Parse(param[0]);
                int exponent = int.Parse(param[1]);

                PolyNode node = new PolyNode();

                node.Polynomial.Coefficient = coefficient;
                node.Polynomial.Exponent = exponent;

                left.Append(node);
            }

             foreach (var poly in rightPolys)
            {
                string[] param = poly.Split(',');
                int coefficient = int.Parse(param[0]);
                int exponent = int.Parse(param[1]);

                PolyNode node = new PolyNode();

                node.Polynomial.Coefficient = coefficient;
                node.Polynomial.Exponent = exponent;

                right.Append(node);
            }

            PolyList sum = left + right;
            sum.PrintList();
            System.Console.WriteLine("multiply:");
            PolyList multi = left * right;
            multi.PrintList();
        }
        public static void RadixSortTest(){
            int[] array ={64,8,216,512,27,729,0,1,343,125};
            int[] array2 = {278,109,63,930,589,184,505,269,8,83};
            int[] array3 = array.Union(array2).ToArray();
            int[] result = null;
            int m = 3;
            RadixSort sort = new RadixSort();
            result = sort.Sort(array3,m);
            foreach(int num in result){
                System.Console.Write(num+" ");
            }
        }
        public static void MultiList(){
            StudentList mary = new StudentList(){
                Name = "mary",
                Age = 11
            };
            StudentList mike = new StudentList(){
                Name = "mike",
                Age = 12
            };
            StudentList john = new StudentList(){
                Name = "john",
                Age = 13
            };
            CourseList chinese = new CourseList(){
                Name = "Chinese",
                Teacher = "欧阳胜利"
            };
            CourseList english = new CourseList(){
                Name = "English",
                Teacher = "东方建设"
            };
            CourseList math = new CourseList(){
                Name = "Math",
                Teacher = "西门建国"
            };

            chinese.Enroll(mary);
            chinese.Enroll(mike);
            chinese.Enroll(john);

            english.Enroll(mike);

            math.Enroll(mary);
            math.Enroll(john);

            System.Console.WriteLine("mary:");
            mary.PrintList();
            System.Console.WriteLine("mike:");
            mike.PrintList();
            System.Console.WriteLine("john:");
            john.PrintList();
            System.Console.WriteLine("chinese:");
            chinese.PrintList();
            System.Console.WriteLine("english:");
            english.PrintList();
            System.Console.WriteLine("math:");
            math.PrintList();
        }
    #endregion
    }
}
