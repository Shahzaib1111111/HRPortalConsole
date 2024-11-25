namespace Portal.Collections
{
    public class Queue
    {
        public Queue<String> StringQueue = new Queue<String>();

        public void PerformOperations()
        {
            StringQueue.Enqueue("1");
            StringQueue.Enqueue("2");
            StringQueue.Enqueue("3");
            string dequeuedElement = StringQueue.Dequeue();
            Console.WriteLine(dequeuedElement);
        }
    }
}
