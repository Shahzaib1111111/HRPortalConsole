namespace Portal
{
    public class HR
    {
        public delegate void PrintResponseDelegate(string message);

        public List<Employee> Employees = new List<Employee>();

        public const decimal TenPercent = 0.1m;


        public void OnboardEmployees(Action<String> callback)
        {
            try
            {
                string filePath = Config.FileName;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int lineNo = 0;
                    string emp;
                    while ((emp = reader.ReadLine()) != null)
                    {
                        if (lineNo == 0)
                        {
                            lineNo++;
                            continue;
                        }
                        else
                        {
                            AddEmployee(emp);
                        }
                        lineNo++;
                    }
                    callback?.Invoke("Onboarding done");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("Please enter correct file path. file not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddEmployee(string emp)
        {
            try
            {
                string[] cols = emp.Split(',');

                if (cols.Length == 6)
                {
                    int id = int.Parse(cols[0]);
                    string name = cols[1];
                    int age = int.Parse(cols[2]);
                    decimal salary = decimal.Parse(cols[3]);
                    Department department = (Department)Enum.Parse(typeof(Department), cols[4]);
                    string jobTitle = cols[5];

                    this.Employees.Add(new Employee(id, name, age, salary, department, jobTitle));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Employee IncreaseSalary(Employee emp)
        {
            decimal incrementedSalary = emp.MonthlySalary * TenPercent;
            emp.MonthlySalary = emp.MonthlySalary + incrementedSalary;
            return emp;
        }

        public Employee UpdateJobTitle(Employee emp)
        {
            emp.JobTitle = "Senior Software Engineer";
            return emp;

        }

        public void SortEmployeesByName()
        {
            Employees = Employees.OrderBy(emp => emp.Name).ToList();
        }

        public void GroupEmployeesByDepartment()
        {
            IEnumerable<IGrouping<Department, Employee>> groupedEmployees = Employees.GroupBy(e => e.Department);
            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"department name: {group.Key}");

                foreach (Employee employee in group)
                {
                    Console.WriteLine($"employee name: {employee.Name}");
                }
            }
        }

    }
}
