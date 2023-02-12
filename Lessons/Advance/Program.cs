using System;
using System.Diagnostics;

namespace Advance
{
    // ********** Sealed **********
    // the sealed modifier prevents other classes from inheriting from it
    public sealed class SealedClass {}
    
    internal class Program
    {
        // ********** Delegates **********
        // delegate - type which can store reference to methods, in another words - type for functions.
        // delegates are mostly used as types for callback functions
        public delegate void NoParameters();
        private delegate float WithParameters(int x, bool y);
        protected delegate int WithRefParameters(ref int x, bool y);

        private static void ShowMessage()
        {
            Console.WriteLine("Message");
        }
        
        // short method declaration, ONLY if it has 1 string/command
        private static void ShowText() => Console.WriteLine("Text");

        // method get func callback as delegate
        private static void ArgDelegate(NoParameters noPrm)
        {
            noPrm();
        }

        private static void PrintString(string str) => Console.WriteLine(str);

        // Action, Action<T>, Action<T1, T2 ...> - default delegate for void functions with or without arguments,
        // we can use it if we don't want to create our own ones
        private static void ActionCallback(Action<string> result)
        {
            result("Action works!");
        }
        
        
        // ********** Events **********
        // events - wrapper around delegates
        // name of delegate should always come after "event" word
        public static event NoParameters MyEvent;

        public static void Main(string[] args)
        {
            // ********** Time of code executing **********
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write($"{i / 100}");
            }
            
            sw.Stop();
            
            // Time spent: 00:00:00.1362826, 136, 1362826
            Console.WriteLine($"\nTime spent: {sw.Elapsed}, {sw.ElapsedMilliseconds}, {sw.ElapsedTicks}");
            
            sw.Restart();
            
            System.Threading.Thread.Sleep(500);
            
            sw.Stop();
            
            // Time spent: 00:00:00.5057836, 505, 5057836
            Console.WriteLine($"Time spent: {sw.Elapsed}, {sw.ElapsedMilliseconds}, {sw.ElapsedTicks}\n");
            
            
            // ********** Delegates **********
            // singlecast delegate - stores reference for 1 method
            NoParameters noParams = ShowMessage; // or new NoParameters(ShowMessage) - longer declaration, or new(ShowMessage) - new syntax, C# 9.0
            noParams(); // Message - Delegates
            
            // multicast delegates - stores reference for several methods
            NoParameters noParamsMulti = ShowMessage;
            noParamsMulti += ShowText; // also we can delete methods from delegate
            noParamsMulti(); // Message - Delegates / Text - Delegates - both methods were called!
            
            // delegate can store reference to anonymous method
            NoParameters noParametersAnonym = delegate()
            {
                Console.WriteLine("I am anonym!");
            };
            noParametersAnonym();
            // anonymous methods can be useful when we want to create method, call it once and never call it again, to not store it anywhere

            // throw delegate as func param
            ArgDelegate(noParams);

            // Action - default delegate
            ActionCallback(PrintString);

            // ********** Events **********
            // events - wrapper around delegates
            // events are ALMOST the same thing as delegates, but there are some difference:
            // 1. The meaning of delegates - delegate logic to another code, events - notify another code
            // 2. Delegate may have returned value or not, but event always should not have returned value
            // 3. Delegates can be called outside of the class, but events can't
            // 4. Delegates can't be used inside interfaces, byt events can
            // 5. Delegates can be used as type for func arguments, but events can't
            
            // we can imagine events like real world event, which has subscribers. And when event happens, it calls all subscribers to notify them
            MyEvent += ShowMessage;
            MyEvent += ShowText;
            MyEvent(); // Message / Text
            
            // TODO array Select - like map in js
            // TODO anonymous types
            
            // TODO Type, GetType()
            // TODO GetProperty, GetField
            
            // TODO lambda expressions
            // TODO reflection
            // TODO tuples
        }
        
        // ********** Naming **********
        // all methods -> capital first letter
        // private fields - start with "_" -> _name
        // public fields - capital first letter
    }
}