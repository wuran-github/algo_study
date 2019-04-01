using System;

namespace csharpDemo.ADTImplement
{
    public class SplayNode
    {
        public SplayNode()
        {
        }
        public int Value { get; set; }
        private SplayNode _parent;
        public SplayNode Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (value != null)
                {
                    if (Value > value.Value)
                    {
                        value.Right = this;
                    }
                    else if (Value < value.Value)
                    {
                        value.Left = this;
                    }
                }
                _parent = value;
            }
        }
        public SplayNode Left { get; set; }
        public SplayNode Right { get; set; }
    }
}