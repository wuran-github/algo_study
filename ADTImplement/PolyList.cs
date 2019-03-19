using System;
namespace csharpDemo.ADTImplement
{
    public class PolyList : LinkList<PolyNode, int>
    {
        public PolyList Add(PolyList other)
        {
            PolyList polySum = new PolyList();

            PolyNode rightNode = (PolyNode)other.Header().Next;
            PolyNode leftNode = (PolyNode)this.Header().Next;

            while (leftNode != null || rightNode != null)
            {
                //当右边为空时
                if(rightNode == null){
                    PolyNode temp = leftNode;
                    leftNode = rightNode;
                    rightNode = temp;
                }
                //当左边为空的时候
                if (leftNode == null)
                {
                    while (rightNode != null)
                    {
                        PolyNode temp = polySum.Append(rightNode.Value);
                        temp.Polynomial.Coefficient = rightNode.Polynomial.Coefficient;

                        rightNode = (PolyNode)rightNode.Next;
                    }
                }
                //当大于
                else if (leftNode.Value > rightNode.Value)
                {

                    PolyNode temp = polySum.Append(leftNode.Value);
                    temp.Polynomial.Coefficient = leftNode.Polynomial.Coefficient;

                    leftNode = (PolyNode)leftNode.Next;
                }
                //等于 等于是记得考虑系数为空后去掉
                else if (leftNode.Value == rightNode.Value)
                {
                    int coefficient = leftNode.Polynomial.Coefficient + rightNode.Polynomial.Coefficient;
                    //为0就不需要插入元素了
                    if (coefficient != 0)
                    {
                        PolyNode temp = polySum.Append(leftNode.Value);
                        temp.Polynomial.Coefficient = coefficient;

                    }
                    leftNode = (PolyNode)leftNode.Next;
                    rightNode = (PolyNode)rightNode.Next;
                }
                //小于
                else if (leftNode.Value < rightNode.Value)
                {
                    PolyNode temp = leftNode;
                    leftNode = rightNode;
                    rightNode = temp;

                    PolyNode tempNode = polySum.Append(leftNode.Value);
                    tempNode.Polynomial.Coefficient = leftNode.Polynomial.Coefficient;

                    leftNode = (PolyNode)leftNode.Next;
                }
            }



            return polySum;
        }
        public PolyList Multiply(PolyList right){
            PolyList polyMuti = new PolyList();
             PolyNode rightNode = (PolyNode)right.Header().Next;
            PolyNode leftNode = (PolyNode)this.Header().Next;

            while (leftNode != null)
            {
                //临时多项式
                PolyList tempPoly = new PolyList();

                PolyNode tempRightNode = rightNode;
                while(tempRightNode != null){
                    //次数，相加
                    int value = leftNode.Value+tempRightNode.Value;
                    //系数，相乘
                    int coefficient = leftNode.Polynomial.Coefficient*tempRightNode.Polynomial.Coefficient;

                    //把单项式插入多项式中
                    PolyNode tempNode = tempPoly.Append(value);
                    tempNode.Polynomial.Coefficient = coefficient;

                    tempRightNode = (PolyNode)tempRightNode.Next;
                }
                //循环结束代表一次乘法完成了，把临时多项式加到结果多项式中
                polyMuti = polyMuti + tempPoly;

                leftNode =  (PolyNode)leftNode.Next;
            }

            return polyMuti;
        }
        public static PolyList operator +(PolyList left, PolyList right){
            return left.Add(right);
        }
        public static PolyList operator *(PolyList left, PolyList right){
            return left.Multiply(right);
        }
    }
}
