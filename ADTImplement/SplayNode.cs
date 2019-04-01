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
                //使用私有字段避免无限递归
                //类可以访问属于他的所有对象的私有字段
                if (value != null)
                {
                    if (Value > value.Value)
                    {
                        value._right = this;
                    }
                    else if (Value < value.Value)
                    {
                        value._left = this;
                    }
                }
                _parent = value;
            }
        }
        // public SplayNode Left { get; set; }
        // public SplayNode Right { get; set; }
        //另一种方法，自动修改parent
        private SplayNode _left;
        private SplayNode _right;
        public SplayNode Left
        {
            get
            {
                return _left;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }
                _left = value;
            }
        }
        public SplayNode Right
        {
            get
            {
                return _right;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }
                _right = value;
            }
        }

    }
}