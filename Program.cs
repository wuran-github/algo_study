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
            //MultiList();

            //栈
            //StackTest();
            // StackArrayTest();
            // BalanceSymbolTest();
            // PostfixTest();
            // InfixToPostfixTest();
            // infixAndPostfixTest();
            
            //队列
            // QueueTest();
            
            //树
            // DirectoryTreeTest();
            // BinaryTreeTest();
            // BinarySearchTreeDeleteTest();
            AVLTreeTest();


            
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
            IList<int> list = new LinkList<Node,int>();
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
    #region 栈（stack)
        public static void StackTest(){
            Stack<Node,int> stack = new Stack<Node,int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            System.Console.WriteLine(stack.Pop().ToString());
            System.Console.WriteLine(stack.Pop().ToString());
            System.Console.WriteLine(stack.Pop().ToString());
        }
        public static void StackArrayTest(){
            IStack<int> stack = new Stack<Node,int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            System.Console.WriteLine(stack.Pop().ToString());
            System.Console.WriteLine(stack.Pop().ToString());
            System.Console.WriteLine(stack.Pop().ToString());
        }
        public static void BalanceSymbolTest(){
            BalanceSymbol balanceSymbol = new BalanceSymbol();
            balanceSymbol.Run();
        }
        public static void PostfixTest(){
            Postfix postfix = new Postfix();
            postfix.run();
        }
        public static void InfixToPostfixTest(){
            InfixToPostfix infix = new InfixToPostfix();
            infix.Translate();
        }
        /// <summary>
        /// 将infix转换为postfix后进行计算
        /// </summary>
        public static void infixAndPostfixTest(){
            char[] infixArray = "4+4/2+(4*5-2^(2^2))*1".ToCharArray();
            InfixToPostfix infix = new InfixToPostfix();
            Postfix postfix = new Postfix();
            string[] postfixArray = infix.Translate(infixArray);
            string result = postfix.GetResult(postfixArray);
            System.Console.WriteLine(result);
        }
    #endregion
    #region 队列（queue)
        public static void QueueTest(){
            IQueue<int> queue = new Queue<Node,int>(3);
            System.Console.WriteLine(queue.IsEmpty());
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            for(int i = 0 ;i < 3; i++){
                
                System.Console.WriteLine(queue.Dequeue()?.Value);
            }
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
        } 
    #endregion
    #region 树
        public static void DirectoryTreeTest(){
            FileTree tree = new FileTree();
            tree.test();
            // tree.ListDir();
            tree.ListDirByPost();
        }
        public static void BinaryTreeTest(){
           PostfixToExpressionTree postfix = new PostfixToExpressionTree();
           postfix.TestPostfix();
        }
        public static void BinarySearchTreeDeleteTest(){
            BinarySearchTree<int,int> tree = new BinarySearchTree<int, int>();
            BinarySearchNode<int,int> root = new BinarySearchNode<int, int>();
            var four = new BinarySearchNode<int, int>(){
                Key = 4
            };
            var eight = new BinarySearchNode<int, int>(){
                Key = 8
            };
            var two = new BinarySearchNode<int, int>(){
                Key = 2
            };
            var one = new BinarySearchNode<int, int>(){
                Key = 1
            };
            var three = new BinarySearchNode<int, int>(){
                Key = 3
            };
            var five = new BinarySearchNode<int, int>(){
                Key = 5
            };
            root.Key = 6;
            root.Left = two;
            root.Right = eight;
            two.Left = one;
            two.Right = five;
            five.Left = three;
            three.Right = four;

            tree.SetRoot(root);
            tree.Delete(2);
            
        }
        public static void AVLTreeTest(){
            AVLTree tree = new AVLTree();
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            for(int i = 16;i >= 10;i--){
                tree.Insert(i);
            }
            tree.Insert(8);
            tree.Insert(9);

        }
    #endregion
    }
}
