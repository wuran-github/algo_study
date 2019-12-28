using System;
using System.Collections.Generic;

namespace Equivalence{

    public class Maze {
        //迷宫长度
        public int Length = 5;
        //迷宫宽度
        public int Width = 5;
        //计算构建迷宫用了多久
        public int Count = 0;
        //计算打破了多少墙
        public int WallCount = 0;
        TreeEquivalenceClass2<int> maze = null;
        //打破的墙，key是位置，value是该位置打破的墙
        Dictionary<int, List<int>> breakWalls = new Dictionary<int, List<int>>();
        public Maze(){
            
        }
        /// <summary>
        /// 初始化迷宫
        /// </summary>
        public void Init(){
            List<int> ints = new List<int>();
            for (int i = 0; i < Length*Width; i++)
            {
                ints.Add(i);
                breakWalls.Add(i,new List<int>());
            }
            maze = new TreeEquivalenceClass2<int>(ints.ToArray());
            Random random = new Random(Guid.NewGuid().GetHashCode());
            Random random2 = new Random(Guid.NewGuid().GetHashCode());
            //随机拆墙
            //要注意一个数字最多只有4面墙可以拆
            //最少只有2面墙可以拆
            //得判断该数字是不是相邻的墙
            //随机拆墙要选墙，而不是选数字
            //怎么确定墙？
            //还需要记录拆掉了哪些墙
            while(maze.Find(0) != maze.Find(Length*Width-1)){
                int x = random.Next(0,Length*Width);
                var neighbors = GetNeighbors(x);
                int y = neighbors[random2.Next(neighbors.Count)];
                if(maze.Find(x) != maze.Find(y)){
                    maze.Union(x,y);
                    WallCount++;
                    breakWalls[x].Add(y);
                    breakWalls[y].Add(x);
                }
                Count++;
                random = new Random(Guid.NewGuid().GetHashCode());
                random2 = new Random(Guid.NewGuid().GetHashCode());
            }
        }
        /// <summary>
        /// 打印迷宫
        /// </summary>
        public void Print(){
            string border = "";
            for (int i = 0; i < Length*Width - 1; i++)
            {
                System.Console.Write($"{i:00}");
                if(!breakWalls[i].Contains(i+1))
                {
                    System.Console.Write("|");
                }
                else{
                    System.Console.Write(" ");
                }
                if(i<(Width*(Length-1))){
                    if(breakWalls[i].Contains(i+Length)){
                        border+="   ";
                    }
                    else{
                        border+=" - ";
                    }
                }

                if(i%Length == Length-1){
                    System.Console.Write("\n");
                    System.Console.WriteLine(border);
                    border="";
                }
            }
            System.Console.Write($"{(Length*Width - 1):00}");
        }
        public bool IsNeighbor(int x, int y){
            //要考虑最左侧的的情况
            bool one = (x-Length)==y || ((x-1)==y && (x%Length!=0));
            //要考虑最右侧的情况
            bool two = (x+Length)==y || ((x+1)==y && (x%Length!=Length-1));

            return one || two;
             
        }
        public List<int> GetNeighbors(int x){
            List<int> neighbors = new List<int>();
            if(x%Length!=0){
                neighbors.Add(x-1);
            }
            if(x%Length!=Length-1)
            {
                neighbors.Add(x+1);
            }
            if(x >= Length){
                neighbors.Add(x-Length);
            }
            if(x<(Width*(Length-1))){
                neighbors.Add(x+Length);
            }
            return neighbors;
        }
    }

}