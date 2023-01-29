using System;
using System.Runtime.CompilerServices;

namespace OOP
{
    // two interfaces with equal methods
    interface IFirst
    {
        void Action();
    }
    
    interface ISecond
    {
        void Action();
    }

    class FirstClass : IFirst, ISecond
    {
        // with this syntax we can define, which interface method belongs if they have equal names
        void IFirst.Action()
        {
            Console.WriteLine("IFirst Action");
        }

        // both methods are private, because otherwise will be conflict if we will call method from class exemplar
        // public void ISecond.Action() - error - The modifier 'public' is not valid for explicit interface implementation.
        void ISecond.Action()
        {
            Console.WriteLine("ISecond Action");
        }
    }
    
    class SecondClass : IFirst, ISecond
    {
        // it also works, but in this case we have only one implementation of method from different interfaces
        public void Action()
        {
            Console.WriteLine("Shared Action");
        }
    }

    class OnlyFirstClass : IFirst
    {
        public void Action()
        {
            Console.WriteLine("Only first Action");
        }
    }

    public class ExplicitInterfaceImplementation
    {
        // method works only with IFirst interface
        private void Foo(IFirst first)
        {
            first.Action();
        }
    
        // method works only with ISecond interface
        private void Bar(ISecond second)
        {
            second.Action();
        }
        
        private FirstClass firstClass = new FirstClass();
        private SecondClass secondClass = new SecondClass();
        private OnlyFirstClass onlyFirst = new OnlyFirstClass();

        public ExplicitInterfaceImplementation()
        {
            Foo(firstClass); // IFirst Action
            Bar(firstClass); // ISecond Action
            
            Foo(secondClass); // Shared Action
            Bar(secondClass); // Shared Action

            // firstClass.Action(); // error - Cannot access private method 'Action' here
            ((IFirst)firstClass).Action(); // but after type casting it works, because we explicitly define which method should be used
            ((ISecond)firstClass).Action();
            (firstClass as IFirst).Action(); // as and is also work
            secondClass.Action(); // works

            Foo(onlyFirst); // Only first Action
            // Bar(onlyFirst); // error - Argument type 'OOP.OnlyFirstClass' is not assignable to parameter type 'OOP.ISecond'
        }
    }
}