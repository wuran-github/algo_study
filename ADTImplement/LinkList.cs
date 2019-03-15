using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class LinkList : IList
    {
        public Node node;
        public int location=0;
        public void Delete(int value)
        {
            throw new NotImplementedException();
        }

        public int Find(int value)
        {
            Node n = next;
            while(next!=null){

            }
        }

        public int FindKth(int location)
        {
            throw new NotImplementedException();
        }

        public IList Header()
        {
            throw new NotImplementedException();
        }

        public void Insert(int value, int location)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return node == null;
        }

        public bool IsLast()
        {
             return node.Next == null;
        }

        public void MakeEmpty()
        {
            throw new NotImplementedException();
        }

        public Node Next()
        {
            if(!IsEmpty() && !IsLast()){
                node = node.Next;
                location++;
            }
            return next;
        }

        public int Previous()
        {
            throw new NotImplementedException();
        }

        public void PrintList()
        {
            throw new NotImplementedException();
        }
    }
}
