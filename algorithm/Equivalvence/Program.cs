using System;

namespace Equivalence
{
    class Program
    {
        static IEquivalence eq = null;
        static void Main(string[] args)
        {
            Test();
        }
        static void Test(){
            // ConstFindTest();
            // TreeTest();
            MazeTest();
        }
        static void ConstFindTest(){
            eq = new ConstFind(1,2,3,4,5);
            ITest();
        }
        static void ConstFind2Test(){
            
        }
        static void TreeTest(){
            TreeEquivalenceClass<int> treeEquivalenceClass = new TreeEquivalenceClass<int>(1,2,3,4,5,6);
            System.Console.WriteLine(treeEquivalenceClass.Find(1) == treeEquivalenceClass.Find(2));
            treeEquivalenceClass.Union(1,2);
            System.Console.WriteLine(treeEquivalenceClass.Find(1) == treeEquivalenceClass.Find(2));

        }
        static void ITest(){
            System.Console.WriteLine(eq.Find(1) == eq.Find(2));
            eq.Add(1,2);
            System.Console.WriteLine(eq.Find(1) == eq.Find(2));
        }

        static void MazeTest(){
            Maze maze = new Maze();
            maze.Init();
            System.Console.WriteLine($"打开的墙的数量:{maze.WallCount}");
            System.Console.WriteLine($"尝试的的次数:{maze.Count}");
            maze.Print();
        }
    }
}
