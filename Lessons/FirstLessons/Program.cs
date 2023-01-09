using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLessons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // ********** Write to console **********
            Console.WriteLine("Hello World!");
            
            
            // ********** Write variables values to console **********
            int consoleValue1 = 10;
            string consoleValue2 = "Ta da!\n";
            Console.WriteLine("Values - {0}, {1}", consoleValue1, consoleValue2);
            

            // ********** Data types **********
            string template = "Type {0,8} | .NET {1,8} | Size {2, 6} | MIN {3,30} | MAX {4}";
            Console.WriteLine("\tInteger Numbers");
            Console.WriteLine(template, "byte", typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue);
            // Type     byte | .NET     Byte | Size      1 | MIN                              0 | MAX 255
            Console.WriteLine(template, "sbyte", typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            // Type    sbyte | .NET    SByte | Size      1 | MIN                           -128 | MAX 127
            Console.WriteLine(template, "short", typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue);
            // Type    short | .NET    Int16 | Size      2 | MIN                         -32768 | MAX 32767
            Console.WriteLine(template, "ushort", typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            // Type   ushort | .NET   UInt16 | Size      2 | MIN                              0 | MAX 65535
            Console.WriteLine(template, "int", typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue);
            // Type      int | .NET    Int32 | Size      4 | MIN                    -2147483648 | MAX 2147483647
            Console.WriteLine(template, "uint", typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue);
            // Type     uint | .NET   UInt32 | Size      4 | MIN                              0 | MAX 4294967295
            Console.WriteLine(template, "long", typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue);
            // Type     long | .NET    Int64 | Size      8 | MIN           -9223372036854775808 | MAX 9223372036854775807
            Console.WriteLine(template, "ulong", typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            // Type    ulong | .NET   UInt64 | Size      8 | MIN                              0 | MAX 18446744073709551615

            Console.WriteLine("\n\tFloating Point Numbers");
            Console.WriteLine(template, "float", typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue);
            // Type    float | .NET   Single | Size      4 | MIN                  -3.402823E+38 | MAX 3.402823E+38
            Console.WriteLine(template, "double", typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue);
            // Type   double | .NET   Double | Size      8 | MIN         -1.79769313486232E+308 | MAX 1.79769313486232E+308
            Console.WriteLine(template, "decimal", typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue);
            // Type  decimal | .NET  Decimal | Size     16 | MIN -79228162514264337593543950335 | MAX 79228162514264337593543950335
            
            Console.WriteLine("\n\tSymbols");
            Console.WriteLine(template, "char", typeof(char).Name, sizeof(char), char.MinValue, char.MaxValue);
            // Type     char | .NET     Char | Size      2 | MIN                                | MAX ￿
            Console.WriteLine(template, "string", typeof(string).Name, "N/A", "N/A", "N/A");
            // Type   string | .NET   String | Size    N/A | MIN                            N/A | MAX N/A

            Console.WriteLine("\n\tBoolean");
            Console.WriteLine(template, "bool", typeof(bool).Name, sizeof(bool), bool.FalseString, bool.TrueString);
            // Type     bool | .NET  Boolean | Size      1 | MIN                          False | MAX True

            Console.WriteLine("\n\tSpecial");
            Console.WriteLine(template, "object", typeof(object).Name, "N/A", "N/A", "N/A");
            // Type   object | .NET   Object | Size    N/A | MIN                            N/A | MAX N/A
            Console.WriteLine(template, "dynamic", "N/A", "N/A", "N/A", "N/A");
            // Type  dynamic | .NET      N/A | Size    N/A | MIN                            N/A | MAX N/A
            
            
            // ********** Variables **********
            int emptyIntVariable;
            int filledIntVariable = 5;
            char firstChar = 'a';
            string firstString = "aaa";
            
            
            // ********** Read data from console **********
            // string data = Console.ReadLine();
            
            
            // ********** String concatenation **********
            string secondPart = " Second Part";
            string fullString = "\nFirst Part" + secondPart;
            Console.WriteLine(fullString);

            string thirdPart = "Third Part";
            string fullFullString = $"{fullString} {thirdPart}\n";
            Console.WriteLine(fullFullString);
            
            
            // ********** Type converting **********
            string correctString = "5";
            int convertedNumber = Convert.ToInt32(correctString);
            int parsedNumber = int.Parse(correctString);
            Console.WriteLine("Correct converting {0}, correct parsing {1}", convertedNumber, parsedNumber);

            string incorrectNumberString = "5abc";
            try
            {
                int incorrectConvertedNumber = Convert.ToInt32(incorrectNumberString);
            }
            catch (Exception error)
            {
                Console.WriteLine("Converting Error {0}", error.Message);
            }
            
            try
            {
                int incorrectConvertedNumber = int.Parse(incorrectNumberString);
            }
            catch (Exception error)
            {
                Console.WriteLine("Parsing Error {0}", error.Message);
            }

            int correctTryParsedNumber;
            
            bool parsingResultCorrect = int.TryParse(correctString, out correctTryParsedNumber);
            if (parsingResultCorrect)
            {
                Console.WriteLine("Correct Try Parse {0}", correctTryParsedNumber);
            }
            
            // Inline declaration - out int
            bool parsingResultIncorrect = int.TryParse(incorrectNumberString, out int incorrectTryParsedNumber);
            if (!parsingResultIncorrect)
            {
                Console.WriteLine("Incorrect Try Parse {0}", incorrectTryParsedNumber);
            }
            
            // ********** Arithmetic Operators **********
            int mathResult = 5 + 6 - 7 + 3 * 2; // 10
            mathResult++; // 11
            mathResult--; // 10
            int divisionResult1 = 10 / 5; // 2
            divisionResult1 = 8 / 5; // 1
            double divisionResult2 = (double)8 / 5; // 1.6
            int modulusResult = 8 % 5; // 3 - Returns the division remainder
            
            
            // ********** Assignment Operators **********
            // = , += , -= , *= , /= , %=
            int assigneValue = 6;
            assigneValue *= mathResult; // mathResult = 10, assigneValue = 60
            

            // ********** Comparison and Logical Operators **********
            // == , != , > , < , >= , <=
            // && , || , ! , & , |
            //
            // Condition1 && Condition2 - if Condition1 = false, then && stops checking other conditions
            // Condition1 & Condition2 - if Condition1 = false, then & continues checking other conditions
            // The same is for || and |
            // In sum: && and || check only needed conditions, & and | always check all conditions
            

            // ********** IF ELSE **********
            if (5 <= 4)
            {
                Console.WriteLine("\nIF\n");
            }
            else
            {
                Console.WriteLine("\nELSE\n");
            }
            
            
            // ********** SWITCH CASE **********
            int switchEnter = 4;

            switch (switchEnter)
            {
                case 1:
                    Console.WriteLine("SWITCH CASE -> It's 1\n");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("SWITCH CASE -> It's 2 or 3\n");
                    break;
                case 4:
                    int changedValue = switchEnter + 100;
                    Console.WriteLine("SWITCH CASE -> It's changed value - {0}\n", changedValue);
                    break;
                default:
                    Console.WriteLine("SWITCH CASE -> It's something strange!\n");
                    break;
            }
            
            // ********** Read key **********
            // ConsoleKey consoleKey = Console.ReadKey().Key;
            
            
            // ********** Console Clear **********
            // Console.Clear();
            
            
            // ********** Cycle WHILE **********
            int value = 4;
            while (value >= 0)
            {
                if (value == 2)
                {
                    value--;
                    continue;
                }

                Console.WriteLine("WHILE cycle i = {0}", value);
                
                value--;
            }

            do
            {
                Console.WriteLine("\nDO WHILE action before condition\n");
            } while (false);
            
            
            // ********** Cycle FOR **********
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("FOR cycle j = {0}", j);
            }
            
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("FOR cycle with break j = {0}", j);
                if (j == 1)
                    break;
            }

            int k = 0;
            for (; k < 3; k++)
            {
                Console.WriteLine("FOR cycle with outside counter k = {0}", k);
                // k++
            }

            for (int j1 = 0, j2 = 5; j1 < 10 && j2 < 16; j1++, j2 += 2)
            {
                Console.WriteLine("FOR cycle with 2 varibales j1 = {0}, j2 = {1}", j1, j2);
            }
            

            // ********** Slow down program execution **********
            // System.Threading.Thread.Sleep(300);
            
            
            // ********** Set cursor position **********
            // Console.SetCursorPosition(2, 2); // (left, top)
            
            
            // ********** Ternary operator  **********
            int ternaryResult = 5 > 4 ? 5 : 4;
            
            
            // ********** Arrays **********
            int[] firstArray;
            firstArray = new int[5]; // array length
            firstArray[1] = 3;
            Console.WriteLine("\nArray length {0}", firstArray.Length);

            int[] initializedArray = new int[5] { 4, 3, 6, 7, 8 };
            initializedArray = new[] { 1, 5, 7, 8, 5, 1 }; // dynamic type and length, defining from init data
            int[] initializedArray2 = { 2, 6, 8, 9 }; // short form

            // create array with length 10 and fill with 5
            int[] initializedArray3 = Enumerable.Repeat(5, 10).ToArray();

            // create array with length 5, filled with 4, 5, 6, 7, 8
            int[] initializedArray4 = Enumerable.Range(4, 5).ToArray();

            int maxValue = initializedArray2.Max();
            int minValue = initializedArray2.Min();
            Console.WriteLine("Max array value: {0}, Min array value: {1}", maxValue, minValue);
            
            int sumValue = initializedArray2.Sum(); // 25
            Console.WriteLine("Sum value = {0}\n", sumValue);
            int[] partArray = initializedArray2.Where(element => element >= 5).ToArray(); // filter elements -> { 6, 8, 9 }
            int partArraySum = initializedArray2.Where(element => element >= 5).Sum(); // 23
            int[] onlyUniqArray = initializedArray.Distinct().ToArray(); // remove all duplicates from array -> { 1, 5, 7, 8 }
            int[] sortedArray = initializedArray.OrderBy(element => element).ToArray(); // sort array from min to max
            int[] sortedArray2 = initializedArray.OrderByDescending(element => element).ToArray(); // sort array from max to min
            
            Array.Sort(initializedArray2) ;
            Array.Reverse(initializedArray2);
            int searchResult = Array.Find(initializedArray, element => element % 2 == 1); // return element, not its position
            int searchResult2 = Array.FindLast(initializedArray, element => element % 2 == 1); // return element, not its position
            int[] searchResult3 = Array.FindAll(initializedArray, element => element % 2 == 1); // return new array of all elements
            int searchIndex = Array.FindIndex(initializedArray, element => element % 2 == 1); // return index or -1
            int searchIndex2 = Array.FindLastIndex(initializedArray, element => element % 2 == 1); // return index or -1

            int searchResult4 = initializedArray.Where(element => element >= 5).First(); // same as Array.Find()
            int searchResult5 = initializedArray.First(element => element >= 5); // same as Array.Find(), short version
            // FirstOrDefault() is the safe version of First(), because First() will crash program if it can't find element
            int searchResult6 = initializedArray.Where(element => element >= 5).FirstOrDefault();
            int searchResult7 = initializedArray.LastOrDefault(element => element >= 5); // same as Array.FindLast();
            
            
            // ********** Two dimensional array **********
            int[,] twoDimensionalArray;
            twoDimensionalArray = new int[3, 5];
            int[,] twoDimensionalArray2 = new int[3, 5]; // each element of array equals default value of its type, for int = 0
            Console.WriteLine($"Two dimensional array, element 1,2 before init: {twoDimensionalArray[1, 2]}"); // 0
            twoDimensionalArray[1, 2] = 99;
            Console.WriteLine($"Two dimensional array, element 1,2 after init: {twoDimensionalArray[1, 2]}"); // 99
            
            // Initialization
            int[,] twoDimensionalArray3 = new int[3, 5]
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
            };
            
            // Initialization - short version
            int[,] twoDimensionalArray4 = new int[,] // sizes define dynamically
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
            };
            
            // Initialization - the shortest version
            int[,] twoDimensionalArray5 =
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
            };
            
            Console.WriteLine($"How many dimensions array has: {twoDimensionalArray5.Rank}"); // 2
            Console.WriteLine($"How many elements array has, !!! NOT LINES !!!: {twoDimensionalArray5.Length}"); // 15
            Console.WriteLine($"How many lines array has (elements in first dimension): {twoDimensionalArray5.GetLength(0)}"); // 3
            Console.WriteLine($"How many columns array has (elements in second dimension): {twoDimensionalArray5.GetLength(1)}"); // 5
            
            // Work with two dimensional array
            for (int y = 0; y < twoDimensionalArray5.GetLength(0); y++)
            {
                for (int x = 0; x < twoDimensionalArray5.GetLength(1); x++)
                {
                    Console.Write(twoDimensionalArray5[y, x] + "\t");
                }
                Console.WriteLine();
            }
            
            
            // ********** Two dimensional array - Jagged (зубчатый) **********
            // jagged two dimensional array is actually one dimensional array of arrays
            int[][] jaggedArray = new int[3][]; // each element of array equals default value of its type, for array = null
            Console.WriteLine($"\nHow many dimensions jagged array has: {jaggedArray.Rank}"); // 1
            Console.WriteLine($"How many elements array has: {jaggedArray.Length}"); // 3 - lines of arrays

            jaggedArray[1] = new int[5];
            jaggedArray[1][1] = 99;
            Console.WriteLine($"Jagged array - element 1,1: {jaggedArray[1][1]}"); // 99
            
            
            // ********** N-dimensional array **********
            int[,,] threeDimensionalArray = new int[3, 5, 9];
            int[,,,] fourDimensionalArray = new int[3, 5, 9, 4];
            int[,,,,] fiveDimensionalArray = new int[3, 5, 9, 4, 7];
            fiveDimensionalArray[1, 0, 4, 2, 5] = 99;
            int[][][] jaggedThreeDimensionalArray = new int[3][][]; // one dimensional array contains 3 one dim arrays of one dim arrays
            
            // ********** Random **********
            Random newRandom = new Random();
            Console.WriteLine($"\nRandom values: {newRandom.Next()}, {newRandom.Next()}, {newRandom.Next()}");
            Console.WriteLine($"Random values with limits: {newRandom.Next(10)}, {newRandom.Next(1, 5)}, {newRandom.Next(50, 100)}\n");
        }
    }
}