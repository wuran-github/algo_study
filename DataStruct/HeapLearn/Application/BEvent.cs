using System;

namespace HeapLearn
{
    
    public class BEvent : IComparable<BEvent>,IComparable
    {
        public int Time{get;set;}
        string msg;
        public bool IsArrived{get;}
        public Customer Master{get;}
        public BEvent(int time, string msg, bool isArrived, Customer master)
        {
            this.Time = time;
            this.msg = msg;
            this.IsArrived = isArrived;
            this.Master = master;
        }
        public BEvent(){
            
        }

        public int CompareTo(BEvent other)
        {
            if(other == null){
                return 1;
            }
            return Time.CompareTo(other.Time);
        }

        public int CompareTo(object obj)
        {
            var evn = obj as BEvent;
            return CompareTo(evn);
        }

        /// <summary>
        /// 统计数据
        /// </summary>
        public void CountData(){
            System.Console.WriteLine(msg);
        }
        /// <summary>
        /// 时间发生
        /// </summary>
        public bool Happen(){
            CountData();
            return IsArrived;
        }
    }
}