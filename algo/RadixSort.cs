using System;
using csharpDemo.ADTImplement;
using csharpDemo.ADT;
namespace csharpDemo.algo
{
    public class RadixSort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="m">最大位数</param>
        public int[] Sort(int[] array, int m)
        {
            IList<int> finalList = new LinkList<Node, int>();
            IList<int>[] tempLists = new LinkList<Node, int>[10];
            int[] tempArray = array;
            for (int i = 0; i < 10; i++)
            {
                tempLists[i] = new LinkList<Node, int>();
            }

            for (int i = 0; i < m; i++)
            {
                //放入链表中
                foreach (int num in tempArray)
                {
                    //求位数
                    int temp = num;
                    temp = temp / (int)Math.Pow(10, i);
                    int l = temp % 10;
                    tempLists[l].Append(num);

                }
                //记录取了第几个数
                int n = 0;
                //从链表中取出放到新数组里
                for (int l = 0; l < 10; l++)
                {
                    Node node = (Node)tempLists[l].Header().Next;
                    while (node != null)
                    {
                        tempArray[n] = node.Value;
                        node = (Node)node.Next;
                        n++;
                    }
                    //清空链表
                    tempLists[l].MakeEmpty();
                }

            }
            return tempArray;

        }
    }
}
