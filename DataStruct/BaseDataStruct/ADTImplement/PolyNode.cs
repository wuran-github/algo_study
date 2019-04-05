using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class PolyNode : INode<int>
    {
        public INode<int> Next { get ; set; } = null;
        
        // public Polynomial Value { get ; set; }
        public int Value { get=>Polynomial.Exponent ; set=>Polynomial.Exponent = value; }
        public Polynomial Polynomial{get;set;} = new Polynomial();

        public override string ToString(){
            return "Coefficient:"+Polynomial.Coefficient+",Exponent:"+Polynomial.Exponent;
        } 
    }
}
