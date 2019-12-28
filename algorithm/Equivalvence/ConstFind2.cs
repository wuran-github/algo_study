using System;
using System.Collections.Generic;

namespace Equivalence{

    /// <summary>
    /// 跟踪等价类大小的类
    /// </summary>
    public class ConstFind2 : IEquivalence
    {
        Dictionary<int, EClass> equivalClasses = new Dictionary<int, EClass>();
        public ConstFind2(params int[] elements){
            foreach (var el in elements)
            {
                equivalClasses.Add(el, new EClass(el.ToString()));
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
            return equivalClasses[element].Name;
        }

        public void Union(int a, int b)
        {
            EClass biggerClass =  null;
            EClass smallerClass = null;
            if(equivalClasses[a].Size > equivalClasses[b].Size){
                biggerClass = equivalClasses[a];
                smallerClass = equivalClasses[b];
                biggerClass.Size+=equivalClasses[b].Size;
            }
            else{
                biggerClass = equivalClasses[b];
                smallerClass = equivalClasses[a];
                biggerClass.Size+=equivalClasses[a].Size;
            }
            var keys = new List<int>(equivalClasses.Keys);
            foreach (var key in keys)
            {
                if(equivalClasses[key].Name == smallerClass.Name){
                    equivalClasses[key] = biggerClass;
                }
            }
        }

        private class EClass{
            public int Size {get;set;} 
            public string Name {get;set;}
            public EClass(string name){
                Size = 1;
                Name = name;
            }
        }
    }

}