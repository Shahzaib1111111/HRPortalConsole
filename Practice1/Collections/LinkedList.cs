namespace Portal.Collections
{
    public class LinkedList
    {
        public LinkedList<string> StringLinkedList = new LinkedList<string>();
        public void PerformOperations()
        {
            StringLinkedList.AddLast("item1");
            StringLinkedList.AddLast("item2");
            StringLinkedList.AddLast("item3");
        }
    }
}
