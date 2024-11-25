using System.Reflection;
using System.Runtime.Serialization;

namespace Portal
{
    [DataContract(Name = "Employee", Namespace = "Practice")]
    public class Employee
    {
        [DataMember(Name = "Id")]
        public int Id;

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Prefix")]
        public char? Prefix { get; set; }

        [DataMember(Name = "Age")]
        public int Age { get; set; }

        [DataMember(Name = "MonthlySalary")]
        private decimal m_monthlySalary { get; set; }

        public decimal MonthlySalary
        {
            get { return m_monthlySalary; }
            set { m_monthlySalary = value; }
        }

        [DataMember(Name = "Department")]
        public Department Department { get; set; }

        public string JobTitle { get; set; }

        public Employee() { }

        public Employee(int id, string name, int age, decimal? monthlySalary, Department department, string jobTitle)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.MonthlySalary = monthlySalary ?? 0;
            this.Department = department;
            this.JobTitle = jobTitle;

            this.Prefix = this.Name?.Length > 0 ? this.Name?[0] : '\0';
            this.Prefix.ToString();
        }

        ~Employee()
        {
            Console.WriteLine("Destructor called");
        }

        public void GetEmployeeData()
        {
            try
            {
                Type type = this.GetType();

                PropertyInfo[] properties = type.GetProperties();

                foreach (var property in properties)
                {
                    string propertyName = property.Name;

                    object propertyValue = property.GetValue(this);

                    Console.WriteLine($"{propertyName} : {propertyValue}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private decimal? CalcAnnualSalary()
        {
            decimal? annualSalary = null;

            try
            {
                if (this.MonthlySalary == null)
                {
                    throw new NullReferenceException("Monthly Salary can\'t be null");
                }
                else
                {
                    if (this.MonthlySalary < 0)
                    {
                        Console.WriteLine("Monthly Salary can\'t be negative");
                    }
                    else
                    {
                        annualSalary = (decimal)this.MonthlySalary * 12;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return annualSalary ?? 0;
        }

        public void GetAnnualSalary()
        {
            try
            {
                decimal? annualSalary = this.CalcAnnualSalary();
                if (annualSalary.HasValue)
                {
                    Console.WriteLine("Annual salary is: {0} ", annualSalary);
                }
                else
                {
                    Console.WriteLine("Annual salary has no value");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
