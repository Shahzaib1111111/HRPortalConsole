namespace Portal.Collections
{
    public class Stack
    {
        public Stack<string> StackString = new Stack<string>();
        public void PerformOperations()
        {
            StackString.Push("item1");
            StackString.Push("item2");
            StackString.Push("item3");
            string poppedElement = StackString.Pop();
            Console.WriteLine(poppedElement);

        }
    }
}
