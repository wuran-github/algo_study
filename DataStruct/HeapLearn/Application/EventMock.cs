using System;
using System.Collections.Generic;

namespace HeapLearn
{
    public delegate bool EventHappen();
    public class EventMock
    {
        public event EventHappen EventHappens;
        readonly int cashierCount;
        int idleCashier;
        Heap<BEvent> eventHeap;
        Queue<BEvent> waitQueue;
        Heap<BEvent> LeaveEvents;
        public EventMock():this(2)
        {
        }
        public EventMock(int count){
            cashierCount = count;
            Init();
        }
        private void Init(){
            idleCashier = cashierCount;
            eventHeap = new Heap<BEvent>();
            waitQueue = new Queue<BEvent>();
        }
        public void BeginMock(){
            PrepareData();
            Begin();
        }
        public void PrepareData(){
            Random random = null;
            int arrivedTime = 0;
            for (int i = 0; i < 10; i++)
            {
                random = new Random(Guid.NewGuid().GetHashCode());
                arrivedTime += random.Next(200);
                var leftTime = random.Next(50);
                Customer customer = new Customer(arrivedTime, leftTime, i.ToString());
                //所有到达事件都放到一个堆中
                eventHeap.Insert(customer.Arrive);
            }

        }
        private void Begin(){
            int nowTime = 0;

            while(!eventHeap.IsEmpty() || idleCashier != cashierCount){
                BEvent bEvent = eventHeap.DeleteMin();
                nowTime = bEvent.Time;
                if(bEvent.IsArrived){
                    if(idleCashier > 0){
                        CustomerArrived(bEvent, nowTime);
                    }else{
                        waitQueue.Enqueue(bEvent);
                    }
                }
                else{
                    idleCashier ++;
                    bEvent.Happen();
                    if(waitQueue.Count != 0){
                        var arrive = waitQueue.Dequeue();
                        CustomerArrived(arrive, nowTime);
                    }
                }
            }

        }
        private void CustomerArrived(BEvent arrive, int nowTime){
             var leave = arrive.Master.Leave;
                leave.Time += nowTime;
                eventHeap.Insert(leave);
                arrive.Happen();
                idleCashier --;
        }
    }

}