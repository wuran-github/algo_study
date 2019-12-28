using System;
using System.Collections.Generic;

namespace Equivalence{

    /// <summary>
    /// 常数时间的find
    /// </summary>
    public class ConstFind : IEquivalence
    {
        Dictionary<int, string> equivalClass = new Dictionary<int, string>(); 
        public ConstFind(params int[] elements){
            foreach (var el in elements)
            {
                equivalClass.Add(el, el.ToString());
            }
        }
        public void Add(int a, int b)
        {
            if(Find(a) == Find(b)){
                return;
            }
            Union(a,b);
        }

        public string Find(int element)
        {
            return equivalClass[element];
        }
        
        public void Union(int a, int b)
        {
            var aName = Find(a);
            var bName = Find(b);
            var keys = new List<int>(equivalClass.Keys);
            foreach (var key in keys)
            {
                if(equivalClass[key] == aName){
                    equivalClass[key] = bName;
                }
            }
        }
    }

}