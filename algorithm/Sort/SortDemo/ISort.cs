using System;

namespace Sort{

    public interface ISort<T> {
        T[] Sort(T[] array);
        int Count{get;}
    }

}