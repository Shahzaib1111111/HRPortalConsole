//value type
using Practice1;

int a = 10;
int b = a;
b = 20;
Console.WriteLine(a);

//ref type
Person person1 = new Person { Name = "Alice" };
Person person2 = person1;
person2.Name = "Bob";
Console.WriteLine(person1.Name);

//Employee1 employee1 = new Employee1("John", 2, 'J', 26);
//Console.WriteLine(employee1.id1);

//SubEmployee subEmployee = new SubEmployee("John Sub", 2, 'J', 26);
//Console.WriteLine(subEmployee.GetDepartment());