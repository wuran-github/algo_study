using System;
namespace csharpDemo.ADTImplement
{
    public class AVLNode
    {
        public int Value { get; set; }
        public int Height { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }
    }
}
