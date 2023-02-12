using System.Collections.Generic;

namespace Advance
{
    public class StackCollection
    {
        public StackCollection()
        {
            Stack<int> stack = new Stack<int>();
            
            stack.Push(3); // add elements to stack
            stack.Push(2);
            stack.Push(5);

            int last1 = stack.Peek(); // get last element of stack WITHOUT removing it
            int last2 = stack.Pop(); // get last element of stack AND remove it
        }
    }
}