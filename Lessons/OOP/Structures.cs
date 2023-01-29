using System;

namespace OOP
{
    public class ClassPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"Class Point: x = {X}, y = {Y}");
        }
    }
    
    // class is reference type, struct is value type
    // struct can't be inherited from another class or struct, but can be inherited from interface
    
    // common rule - struct is better to use than class if you want to describe something with several, not many, primitive types.
    // small, logically connected, entity. why - because struct stores in stack - operative memory, and in some cases can overload it.
    // struct should be a little more complicated than primitive type
    // another reason - struct can't be inherited and can't inherit, so, can't be part of complicated business logic
    public struct StructPoint
    {
        // public int value = 1; // error - Non-static struct member cannot have initializer
        // so in structures we can't initialize fields immediately
        // !! BUT !!
        public StructPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        // struct can have constructor with parameters (and CAN'T without them) and init variables there
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"Struct Point: x = {X}, y = {Y}");
        }
    }
    
    public class Structures
    {
        void ClassFunc(ClassPoint classPoint)
        {
            classPoint.X++;
            classPoint.Y++;
        }

        void StructFunc(StructPoint structPoint)
        {
            structPoint.X++;
            structPoint.Y++;
        }

        public Structures()
        {
            ClassPoint classPoint; // null by default
            StructPoint structPoint; // X = 0, Y = 0 - already filled by default values by default

            classPoint = new ClassPoint();
            // we always can create struct without parameters despite on existence of constructor with params
            structPoint = new StructPoint();
            
            ClassFunc(classPoint); // class X and Y changed after ClassFunc, because data was thrown to func by reference
            StructFunc(structPoint); // struct X and Y did not change after StructFunc, because data was copied by value to func argument
            
            ClassPoint classPoint2 = new ClassPoint();
            StructPoint structPoint2 = new StructPoint();

            classPoint.Equals(classPoint2); // false - comparing by references
            structPoint.Equals(structPoint2); // true - comparing by values
        }
    }
}