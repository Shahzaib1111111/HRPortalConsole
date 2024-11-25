namespace Portal.Collections
{
    public class HashSet
    {
        public HashSet<int> Set = new HashSet<int>();

        public void PerformOperations()
        {
            Set.Add(0);
            Set.Add(1);
            Set.Add(2);
            foreach (var item in Set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
