using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP
{
    public class Generics
    {
        public Generics()
        {
            int a = 1, b = 5;
            double c = 1.1, d = 5.5;
            string e = "test1", f = "test2";

            Swap(ref a, ref b);
            Swap(ref c, ref d);
            Swap(ref e, ref f);

            // in this case we should explicitly define generic type, because it can't be computed from arguments 
            int result = Foo<int>(); // 0
            
            // generics in some default structures
            List<int> list = new List<int>(); // array of int
            ArrayList array = new ArrayList(); // array of objects, we can put any data type here
            // but it is very hard to use it, because of many boxing/unboxing and type casting, so, ArrayList almost never should be used

            MyList<int> myList = new MyList<int>();
        }

        void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        T Foo<T>()
        {
            return default(T); // default - get default value for type (for example, int - 0, string - null)
        }
    }

    // example of generic class
    public class MyList<T>
    {
        private T[] array = Array.Empty<T>(); // equals to new T[0], but is more clear for reading
    }
}