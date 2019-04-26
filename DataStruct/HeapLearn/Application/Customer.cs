using System;

namespace HeapLearn
{
    public class Customer
    {
        public BEvent Arrive;
        public BEvent Leave;
        string name;
        public Customer(int arrivedTime, int leftTime, string name)
        {
            this.name = name;
            string arrivedMsg = $"{name} was arrived";
            string leftMsg =  $"{name} was left";
            Arrive = new BEvent(arrivedTime,arrivedMsg, true,this);
            Leave = new BEvent(leftTime, leftMsg, false,this);
        }
    }
}