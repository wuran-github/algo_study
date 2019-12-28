using System;

namespace Equivalence{

    /// <summary>
    /// 用int作为元素测试
    /// </summary>
    public interface IEquivalence {
        string Find(int element);
        void Add(int a, int b);
        void Union(int a, int b);
    }

}