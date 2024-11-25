namespace Practice1
{
    public class Employee1
    {
        public int id1 { get; set; }
        public string name { get; set; }

        internal char prefix { get; set; }

        private int age { get; set; }

        public Employee1(string name, int id, char prefix, int age)
        {
            this.name = name;
            this.id1 = id;
            this.prefix = prefix;
            this.age = age;
        }

        public int GetAge()
        {
            return this.age;
        }
    }
}
