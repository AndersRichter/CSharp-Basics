using System.Collections.Generic;

namespace Advance
{
    public class QueueCollection
    {
        public QueueCollection()
        {
            Queue<string> queue = new Queue<string>();
            
            queue.Enqueue("test"); // add element to queue
            queue.Enqueue("ball");
            queue.Enqueue("home");

            string first = queue.Dequeue(); // "test" - return first element from queue AND remove it from queue
            string first2 = queue.Peek(); // "ball" - return first element from queue WITHOUT removing it from queue
        }
    }
}