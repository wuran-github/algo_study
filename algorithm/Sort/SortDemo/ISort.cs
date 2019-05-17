using System;

namespace Sort{

    public interface ISort<T> {
        void Sort(T[] array);
        int Count{get;}
    }

}