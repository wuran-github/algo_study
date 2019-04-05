using System;
namespace csharpDemo.ADT
{
    public interface INode<TVal>
    {
        INode<TVal> Next { get; set; }
        //value其实有点像Key，是用来唯一确定该节点的值，可以自己增加一个属性来保存更详细的信息
        TVal Value { get; set; }
    }
}
