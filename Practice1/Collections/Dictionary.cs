namespace Portal.Collections
{
    public class Dictionary
    {
        public Dictionary<int, string> KeyValuePairs = new Dictionary<int, string>();

        public void PerformOperations()
        {
            KeyValuePairs.Add(1, "John");
            KeyValuePairs.Add(2, "Alice");
            KeyValuePairs.Add(3, "Bob");
            KeyValuePairs.Remove(2);
            KeyValuePairs[3] = "Kevin";
            foreach (var item in KeyValuePairs)
            {
                Console.WriteLine("key {0} : value {1}", item.Key, item.Value);
            }
        }

    }
}
