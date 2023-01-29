namespace OOP
{
    // boxing - when value type is moved from stack to heap
    // unboxing - when value type is moved from heap to stack
    // these operations always take some extra time for executing, and it may cause performance issues, so we should avoid them
    public class BoxingUnboxing
    {
        public BoxingUnboxing()
        {
            // Example 1
            int a = 1;
            object b = a; // boxing - value type int moved to reference type object
            int c = (int)b; // unboxing - reference type object moved to value type int
            // decimal d = (decimal)b; // error - InvalidCastException - we can unbox boxed value only to its initial type
            
            // Example 2
            void CommonPrint(IInterface print)
            {
                print.Print();
            }

            MyStruct printable = new MyStruct();
            CommonPrint(printable); // boxing - because interface is reference entity, but struct - value type.
            // so here we convert struct MyStruct to interface IInterface - value to reference - boxing
            
            // Example 3
            a.GetType(); // boxing - because int type has not method GetType(), so it was called from base parent type - object
        }
    }

    interface IInterface
    {
        void Print();
    }

    struct MyStruct : IInterface
    {
        public void Print() {}
    }
}