using System;
namespace csharpDemo.ADTImplement
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public int Coefficient { get; set; }
        public int Exponent { get; set; }

        //重写Equals
        public bool Equals(Polynomial other)
        {
            //对比
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            //对比null
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (Coefficient != other.Coefficient || Exponent != other.Exponent)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
             //对比
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            //对比null
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if(obj.GetType() != this.GetType()){
                return false;
            }
            return Equals((Polynomial)obj);
        }

        public override int GetHashCode(){

            return Coefficient.GetHashCode()+Exponent.GetHashCode();
        }

        public static bool operator ==(Polynomial left, Polynomial right) => Equals(left, right);

        public static bool operator !=(Polynomial left, Polynomial right) => Equals(left, right);


    }
}
