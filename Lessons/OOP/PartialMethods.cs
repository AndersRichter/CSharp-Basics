using System;

namespace OOP
{
    // second part of partial class. Here we use field "a" from file Partial.cs
    partial class Partial
    {
        public void PrintA()
        {
            Console.WriteLine($"Partial class works: a = {a}");
        }
    }
}