using System;
using System.Collections.Generic;

namespace LessonsPartTwo
{
    internal class Program
    {
        // ********** Functions **********
        private static int SumNumbers(int a, int b)
        {
            int result = a + b;

            return result;
        }
        
        // Overloaded function int SumNumbers
        private static double SumNumbers(double a, double b)
        {
            double result = a + b;

            return result;
        }

        // Documentation for function or class - ///, shows in IDE tooltips
        /// <summary>
        /// Print sum of 2 numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        private static void PrintSum(int a, int b)
        {
            Console.WriteLine($"Print sum: {a + b}");
        }
        
        public static void Main(string[] args)
        {
            int result = SumNumbers(3, 5);
            Console.WriteLine("Sum 3 + 5 = {0}", result);
            PrintSum(3, 5);

            double resultDouble = SumNumbers(3.6, 5.6);
            Console.WriteLine("Sum 3.5 + 5.5 = {0} - overloaded double method", resultDouble);
            
            
            // ********** Value type VS Reference type **********
            // Value type - struct, enum (int, bool etc) - throws by value, stores on the stack
            // Reference type - class (class, object, array, string etc) - throws by reference, stores on the heap
        
        
            // ********** NULL **********
            // null - default value for reference type (like an empty ref)
            
            
            // ********** Null-coalescing operators **********
            string flagVariableNull = null;
            string flagVariableValue = "\nNull-coalescing WORKS!";
            Console.WriteLine(flagVariableNull ?? flagVariableValue); // "Null-coalescing WORKS!"
            
            // string.Empty == ""

            string nullStringButNotNullAfter = null;
            nullStringButNotNullAfter ??= "Default value";
            Console.WriteLine($"Null-coalescing assignment operator works: {nullStringButNotNullAfter}");

            string nullString = null;
            string nullArray = null;
            Console.WriteLine($"Null-conditional operator works without error: {nullString?.Length}, {nullArray?[0]}");
            
            
            // ********** Ref **********
            int regularVar1 = 2;
            int regularVar2 = 2;

            static void Foo1(int a)
            {
                a = 5;
            }
            
            static void Foo2(ref int a)
            {
                a = 5;
            }
            
            Foo1(regularVar1);
            Foo2(ref regularVar2);
            
            // With ref we throw value type variable to function like a reference type var and can change its value inside.
            // We can use ref when throwing big struct to func for performance reasons,
            // because we will avoid creating new struct and copying all fields
            Console.WriteLine($"\nValue type variable without ref: {regularVar1}, and with ref: {regularVar2}"); // 2 - old value, 5 - new value
            
            // With reference type we can modify fields inside func by default = modify data, but not the reference itself.
            // But with ref we also are able to change the reference
            int[] regularArray1 = { 1, 2, 3 };
            int[] regularArray2 = { 1, 2, 3 };
            
            static void Bar1(int[] a)
            {
                a[1] = 10;
            }
            
            static void Bar2(int[] a)
            {
                a = null;
            }
            
            static void Bar3(ref int[] a)
            {
                a = null;
            }
            
            Bar1(regularArray1);
            Console.WriteLine($"Reference type variable WITHOUT ref: change field WORKS: {regularArray1[1]}"); // 10
            
            Bar2(regularArray1);
            Console.WriteLine($"Reference type variable WITHOUT ref: remove reference does NOT work: {regularArray1[1]}"); // 10
            
            Bar3(ref regularArray2);
            Console.WriteLine($"Reference type variable WITH ref: remove reference WORKS: {regularArray2?.Length ?? 0}"); // 0
            
            // Ref also works with local variables
            int[] arrayForChanging = { 1, 2, 3 };
            int element1 = arrayForChanging[1];
            element1 = 10;
            Console.WriteLine($"Reference type variable WITHOUT ref: local var change does NOT work: {arrayForChanging[1]}"); // 2
            
            ref int element2 = ref arrayForChanging[1];
            element2 = 10;
            Console.WriteLine($"Reference type variable WITH ref: local var change WORKS: {arrayForChanging[1]}"); // 10
            
            // And ref also works with returned values
            int[] arrayForChanging2 = { 1, 2, 3 };

            static ref int Func(int[] array)
            {
                return ref array[1];
            }
            
            ref int element3 = ref Func(arrayForChanging2);
            element3 = 11;
            Console.WriteLine($"Reference type variable WITH ref: returned value change WORKS: {arrayForChanging2[1]}\n"); // 11
            
            
            // ********** Generics **********
            static void PrintFirstElementGeneric<T>(T[] array)
            {
                Console.WriteLine($"Generic print: type - {typeof(T).Name}, element - {array[0]}");
            }

            int[] intArray = { 1 };
            double[] doubleArray = { 1.1 };
            string[] stringArray = { "one" };
            
            PrintFirstElementGeneric(intArray);
            PrintFirstElementGeneric(doubleArray);
            PrintFirstElementGeneric(stringArray);
            
            
            // ********** Out **********
            // "out" works exactly the same as "ref", BUT: when we use "out" we must change variable value, and with "ref" we can but don't have to
            
            int refVar = 10;
            // int refVar; with ref we can't leave variable without init value -> compile error

            static void RefFunction(ref int value)
            {
                Console.WriteLine($"\nWhile we use ref we can not to change variable value - {value}");
            }
            
            RefFunction(ref refVar);
            
            int outVar = 10;
            // int outVar; with out we can leave variable without init value

            static void OutFunction(out int value)
            {
                value = 5;
                Console.WriteLine($"While we use out we can't not to change variable value - {value}");
            }
            
            OutFunction(out outVar);
            OutFunction(out int outVarNew); // with out we can create variable inside func call
            
            
            // ********** In **********
            // "in" makes argument readonly, passing it by reference. It can optimise code for structures, because
            // they will not copy all their fields to new variable
            
            static void InFunction(in int value)
            {
                // value = 5; <- error
                Console.WriteLine($"\nWhile we use in we can't change variable value, only read it - {value}");
            }

            int inVar = 5;
            InFunction(in inVar); // or we can just use InFunction(inVar) - without in word
            
            
            // ********** Params **********
            static int SumWithParams(params int[] parameters) // params collects array of all arguments
            {
                int result = 0;

                foreach (int param in parameters)
                {
                    result += param;
                }

                return result;
            }
            
            Console.WriteLine($"\nParams - 0 arguments - {SumWithParams()}");
            Console.WriteLine($"Params - 1 arguments - {SumWithParams(1)}");
            Console.WriteLine($"Params - 2 arguments - {SumWithParams(1, 2)}");
            Console.WriteLine($"Params - 3 arguments - {SumWithParams(1, 2, 3)}");
            Console.WriteLine($"Params - 4 arguments - {SumWithParams(1, 2, 3, 4)}");
            Console.WriteLine($"Params - 5 arguments - {SumWithParams(1, 2, 3, 4, 5)}");
            
            static int SumWithParamsAndMessage(string message, params int[] parameters) // params collects array of arguments
            {
                int result = 0;
                Console.Write(message);

                foreach (int param in parameters)
                {
                    result += param;
                }

                return result;
            }
            
            Console.WriteLine($" - Params - 5 arguments AND message - {SumWithParamsAndMessage("Hello message",1, 2, 3, 4, 5)}\n");
            
            
            // ********** Params + object **********
            // object - parent type for all other types
            static void ObjectParams(params object[] parameters)
            {
                foreach (var param in parameters)
                {
                    Console.WriteLine("Type: {0}, value: {1}", param.GetType(), param);
                }
            }
            
            ObjectParams("test", 5, 'f', true, 5.5f);
            
            
            // ********** Optional func arguments **********
            // to make arg optional we need to set its default value
            static int FuncWithArgs(int a, int b, bool logging = false, int c = 0)
            {
                int result = a + b + c;

                if (logging)
                {
                    Console.WriteLine($"Result = {result}");
                }

                return result;
            }
            
            
            // ********** Pass arguments by name **********
            int value1 = 1;
            int value2 = 2;
            FuncWithArgs(b: value2, a: value1);
            FuncWithArgs(b: 3, a: 4);
            FuncWithArgs(3, b: 4);
            
            
            // ********** Recursion **********
            Console.WriteLine();
            RecursionFunc();
            
            
            // ********** Type casting **********
            Console.WriteLine();
            static void FloatFunc(float value)
            {
                Console.WriteLine($"Float func works - {value}");
            }

            byte byteVar = 5;
            int intVar = 5;
            float floatVar = 5.5f;
            double doubleVar = 5.5;
            FloatFunc(byteVar); // works - implicit (неявное) type casting happens
            FloatFunc(intVar); // works - implicit (неявное) type casting happens
            FloatFunc(floatVar); // works
            // FloatFunc(doubleVar); // error - can't convert types
            FloatFunc((float)doubleVar); // works - explicit (явное) type casting happens
            
            // we can lose some data with explicit type casting if our variable stores data outside of min/max range of converted type
            int outsideVar = 260;
            byte smallVar = (byte)outsideVar; // type byte has 255 as max value => overflow
            Console.WriteLine($"We lose data with explicit type casting int 260 to byte - byte data = {smallVar}"); // 4
            
            // Converting to boolean
            int varToConvert1 = 5;
            int varToConvert2 = 0;
            // bool result = (bool)varToConvertTrue; // error - can't convert types
            bool bool1 = Convert.ToBoolean(varToConvert1); // true
            bool bool2 = Convert.ToBoolean(varToConvert2); // false
            
            Console.WriteLine($"Converting to boolean - numbers: {varToConvert1} - {bool1}, {varToConvert2} - {bool2}");
            
            // converting of any other string or char will cause error
            string stringToConvert1 = "true";
            string stringToConvert2 = "false";
            bool bool3 = Convert.ToBoolean(stringToConvert1); // true
            bool bool4 = Convert.ToBoolean(stringToConvert2); // false
            
            Console.WriteLine($"Converting to boolean - strings: {stringToConvert1} - {bool3}, {stringToConvert2} - {bool4}");

            int firstValue = 5;
            float secondValue = 2.5f;
            float sumResult1 = firstValue + secondValue; // 7.5 - firstValue implicitly converts to float
            int sumResult2 = firstValue + (int)secondValue; // 7 - we need to explicitly convert secondValue to int and drop numbers after dot
            int sumResult3 = (int)(firstValue + secondValue); // 7 - or we can convert whole result of expression
            
            
            // ********** Type value overflow **********
            // when value crosses its max/min value it goes to opposite - min/max value and goes further, like loop
            byte aggression = 1;
            byte modifier = 2;
            aggression = (byte)(aggression - modifier); // 255 - because byte has 0 as min value and can not be equal to -1
            
            // overflow through the top
            int topOverflow = int.MaxValue;
            topOverflow += 1; // topOverflow becomes int.MinValue
            
            // overflow through the bottom
            int bottomOverflow = int.MinValue;
            bottomOverflow -= 1; // bottomOverflow becomes int.MaxValue
            
            Console.WriteLine($"\nOverflow through the top: {topOverflow}, through the bottom: {bottomOverflow} ");
            
            // !! We can safe ourselves from overflow behavior:
            // Right click on project -> Properties -> Debug | Any CPU -> Check for arithmetic overflow
            // With this rule program will throw error if overflow will be detected
            
            // But it will turn on overflow detect for WHOLE project
            // we can turn on it only for some operations

            try
            {
                checked
                {
                    aggression = (byte)(aggression + modifier); // 255 + 2 - top overflow
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Overflow error {0}, value: {1}", error.Message, aggression);
            }
            
            // if we turn on overflow check for whole project but we want to turn it off for specific expression
            unchecked
            {
                aggression = (byte)(aggression + modifier); // 255 + 2 - top overflow
            }
            
            // Overflow works only for integer types of numbers. For numbers with floating point there are some special values
            double tryToOverflow1 = 1.0 / 0.0; // Infinity
            double tryToOverflow2 = 0.0 / 0.0; // NaN
            double tryToOverflow3 = double.MaxValue + double.MaxValue; // Infinity
            Console.WriteLine($"Try to overflow double: {double.IsInfinity(tryToOverflow1)}, {double.IsNaN(tryToOverflow2)}, {double.IsInfinity(tryToOverflow3)}\n");
            
            // for type float overflow works in exactly the same way as for double
            // !! BUT !! for type decimal overflow ALWAYS throw exception even while using flag unchecked
            
            
            // ********** Nullable for value types **********
            // int variable = null; // error - can not convert null to int because it is a non-nullable value tape
            int? nullableVariable = null; // ? - make variable nullable
            Console.WriteLine($"Nullable variable: value when null - {nullableVariable}"); // null
            Console.WriteLine($"Nullable variable: == null - {nullableVariable == null}"); // true
            Console.WriteLine($"Nullable variable: .HasValue - {nullableVariable.HasValue}"); // false
            Console.WriteLine($"Nullable variable: ?? 10 - {nullableVariable ?? 10}"); // 10
            Console.WriteLine($"Nullable variable: .GetValueOrDefault() - {nullableVariable.GetValueOrDefault()}"); // 0
            Console.WriteLine($"Nullable variable: .GetValueOrDefault(3) - {nullableVariable.GetValueOrDefault(3)}"); // 3
            // Console.WriteLine($"Nullable variable: .Value - {nullableVariable.Value}"); // System.InvalidOperationException

            nullableVariable = 5;
            Console.WriteLine($"Nullable variable: value when not null - {nullableVariable}"); // 5
            Console.WriteLine($"Nullable variable: == null - {nullableVariable == null}"); // false
            Console.WriteLine($"Nullable variable: .HasValue - {nullableVariable.HasValue}"); // true
            Console.WriteLine($"Nullable variable: ?? 10 - {nullableVariable ?? 10}"); // 5
            Console.WriteLine($"Nullable variable: .GetValueOrDefault() - {nullableVariable.GetValueOrDefault()}"); // 5
            Console.WriteLine($"Nullable variable: .GetValueOrDefault(3) - {nullableVariable.GetValueOrDefault(3)}"); // 5
            Console.WriteLine($"Nullable variable: .Value - {nullableVariable.Value}"); // 5

            int? nullableVar2 = null;
            Console.WriteLine($"Nullable variable: null + 5 - {nullableVar2 + nullableVariable}"); // null
            Console.WriteLine($"Nullable variable: null == 5 - {nullableVar2 == nullableVariable}"); // false
            Console.WriteLine($"Nullable variable: null > 5 - {nullableVar2 > nullableVariable}"); // false
            Console.WriteLine($"Nullable variable: null < 5 - {nullableVar2 < nullableVariable}"); // false
            
            
            // ********** Var **********
            // define data type dynamically, based on initialization data
            var futureInt = 5; // int
            var futureFloat = 5f; // float
            var futureString = "test"; // string
            var futureIntArray = new [] { 1, 2, 3 }; // int[]
            
            // type defines at first initialization and can't be changed in the future
            // futureInt = "test"; // error
            
            // var is very useful when initialization code is very long and obvious as type
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            var dict2 = new Dictionary<int, string>(); // much shorter way
            var anonym1 = new { Name = "test", Age = 25 }; // anonymous type
            
            
            // ********** Enum **********
            Status status = Status.Error; // 1
            Color color = Color.blue; // 11
            
            // enums can be only integer types: Type byte, sbyte, short, ushort, int, uint, long, or ulong expected
            Console.WriteLine($"\nEnum - get underlying type: Color - {Enum.GetUnderlyingType(typeof(Color))}, ColorByte - {Enum.GetUnderlyingType(typeof(ColorByte))}");

            int intStatus = (int)status; // 1 - enum value to int
            Status statusInt = (Status)1; // Status.Error - int to enum value
            
            // as enums is equivalent of numbers we can perform arithmetic operations on it
            Status nextStatus = statusInt + 1; // Status.Pending
            
            // check if enum contains int value
            Enum.IsDefined(typeof(Status), 55); // false
            Enum.IsDefined(typeof(Status), 1); // true
            
            // get all enum values
            var enumValues = Enum.GetValues(typeof(Status)); // array of values
            
            // parse string and cast it to enum type
            Status parsedStatus = (Status)Enum.Parse(typeof(Status), "Error"); // Status.Error
            Status parsedStatusIgnoreCase = (Status)Enum.Parse(typeof(Status), "error", ignoreCase: true); // Status.Error
        }
        
        enum Status
        {
            Success, // 0
            Error, // 1
            Pending, // 2
        }
        
        enum Color
        {
            red = 10,
            blue = 11,
            black = 100,
        }
        
        enum ColorByte: byte
        {
            red = 10,
            blue = 11,
            black = 100,
        }

        private static int counter = 0;

        static void RecursionFunc()
        {
            if (counter == 5)
            {
                return;
            }
            Console.WriteLine($"Recursion - {counter++} iteration");
            RecursionFunc();
        }
    }
}