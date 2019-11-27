using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort{

    public class OuterSort : ISort<int>
    {
        public int Count => 0;
        //内存容量
        int MemorySize = 10;
        //要排序的记录大小
        int RecordSize = 50;
        //磁盘数量
        int DiskNum = 4;
        //模拟磁盘
        List<List<List<int>>> Disks = new List<List<List<int>>>();
        //使用快速排序算法
        ISort<int> sorter = new QuickSort<int>();

        //最后存放的磁盘
        List<List<int>> finalDisk = null;
        public OuterSort(){
            //初始化磁盘
            for (int i = 0; i < DiskNum; i++)
            {
                Disks.Add(new List<List<int>>());
            }
        }
        public OuterSort(int memorySize, int recordSize):this(){
            this.MemorySize = memorySize;
            this.RecordSize = recordSize;
        }
        public int[] Sort(int[] array)
        {
            Disks[0].Add(array.ToList());
            Sort();
            
            return finalDisk[0].ToArray();
        }
        public void Sort(){
            List<List<int>> disk1 = Disks[0];
            List<List<int>> disk2 = Disks[1];
            List<List<int>> disk3 = Disks[2];
            List<List<int>> disk4 = Disks[3];

            var inDisk1 = disk1;
            var inDisk2 = disk2;
            var outDisk1 = disk3;
            var outDisk2 = disk4;
            var inFile = inDisk1[0];
            int i = 0;
            while (inFile.Count > 0)
            {
                int size = Math.Min(inFile.Count, MemorySize);
                //第一步，读入M个记录
                List<int> record = inFile.GetRange(0,size);
                //删掉这个数据
                inFile.RemoveRange(0,size);
                // 排序
                record = sorter.Sort(record.ToArray()).ToList();
                //交替写入
                if(i%2 != 0){
                    outDisk1.Add(record);
                }else{
                    outDisk2.Add(record);
                }
                i++;
            }
            //删除掉空文件
            RemoveFile(inDisk1);
            Tuple<List<List<int>>,List<List<int>>>[] diskGroups = {
                Tuple.Create(disk1,disk2), Tuple.Create(disk3, disk4)
            };
            int groupIndex = 1;
            while (true)
            {
                var inGroup = diskGroups[groupIndex];
                var outGroup = diskGroups[(groupIndex+1)%diskGroups.Length];
                groupIndex = (groupIndex+1)%diskGroups.Length;
                //开始合并顺串
                inDisk1 = inGroup.Item1;
                inDisk2 = inGroup.Item2;
                outDisk1 = outGroup.Item1;
                outDisk2 = outGroup.Item2;
                List<List<int>>[] outDisks = { outDisk1, outDisk2 };
                int outDiskIndex = 0;
                List<List<int>> outDisk = null;
                int disk1Index = 0;
                int disk2Index = 0;

                while (true)
                {
                    //取出文件（即顺串
                    var inFile1 = inDisk1[disk1Index];
                    var inFile2 = inDisk2[disk2Index];
                    //要写入的新文件
                    List<int> newFile = new List<int>();
                    outDisk = outDisks[outDiskIndex];
                    int firstIndex = 0;
                    int secondIndex = 0;
                    //合并
                    while (true)
                    {
                        int e1 = inFile1[firstIndex];
                        int e2 = inFile2[secondIndex];

                        if (e1 < e2)
                        {
                            newFile.Add(e1);
                            firstIndex++;
                        }
                        else
                        {
                            newFile.Add(e2);
                            secondIndex++;
                        }
                        if (firstIndex >= inFile1.Count)
                        {
                            for (int index = secondIndex; index < inFile2.Count; index++)
                            {
                                newFile.Add(inFile2[index]);
                            }
                            break;
                        }
                        else if (secondIndex >= inFile2.Count)
                        {
                            for (int index = firstIndex; index < inFile1.Count; index++)
                            {
                                newFile.Add(inFile1[index]);
                            }
                            break;
                        }

                    }
                    inFile1.Clear();
                    inFile2.Clear();
                    outDisk.Add(newFile);
                    outDiskIndex = (outDiskIndex + 1) % outDisks.Length;
                    outDisk = outDisks[outDiskIndex];
                    disk1Index++;
                    disk2Index++;
                    if (disk1Index >= inDisk1.Count && disk2Index < inDisk2.Count)
                    {
                        outDisk.Add(inDisk2[disk2Index].ToList());
                        inDisk2[disk2Index].Clear();
                        RemoveFile(inDisk1);
                        RemoveFile(inDisk2);
                        break;
                    }
                    else if (disk1Index < inDisk1.Count && disk2Index >= inDisk2.Count)
                    {
                        outDisk.Add(inDisk1[disk1Index].ToList());
                        inDisk1[disk1Index].Clear();
                        RemoveFile(inDisk1);
                        RemoveFile(inDisk2);
                        break;
                    }
                    else if(disk1Index >= inDisk1.Count && disk2Index >= inDisk2.Count){
                        RemoveFile(inDisk1);
                        RemoveFile(inDisk2);
                        break;
                    }
                }
                if(outDisk1.Count+outDisk2.Count == 1){
                    break;
                }
            }
            if(outDisk1.Count == 1){
                finalDisk = outDisk1;
            }else{
                finalDisk = outDisk2;
            }

        }
        private void RemoveFile(List<List<int>> disk){
            disk.RemoveAll(en=>en.Count == 0);
        }
    }

}