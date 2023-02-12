using System.Collections.Generic;

namespace Advance
{
    public class ListCollection
    {
        public ListCollection()
        {
            List<int> numbers = new List<int>(); // empty List
            List<int> numbersWithSize = new List<int>(5); // List with size 5
            numbersWithSize[0] = 1;
            
            numbers.Add(10);
            int length = numbersWithSize.Count; // 5 - length of List
            
            numbers.AddRange(new int[] { 4, 7, 2, 8 }); // add several values at the same time
            
            numbers.RemoveAt(3); // remove element with index 3
            numbers.Remove(5); // remove FIRST element with value 5

            numbers.IndexOf(7); // return index of element
            
            numbers.Insert(1, 12); // insert item 12 on index 1
            
            numbersWithSize.Clear();
        }
    }
}