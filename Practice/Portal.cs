namespace Portal
{
    public class Portal
    {
        private Employee SelectedEmployee { get; set; }

        public Func<Employee, Employee> PromotionDelegate;

        public void ShowDashboard()
        {
            try
            {
                int input;

                HR hr = new HR();

                SubscribeEvents(hr);

                if (Config.CurrentEnv.Equals(Env.Dev))
                {
                    for (input = 1; input < 10; input++)
                    {
                        Console.WriteLine($"------ case: {input} start -------");
                        ProcessOption(hr, input);
                        Console.WriteLine($"------ case: {input} end -------");

                    }
                }
                else
                {
                    do
                    {
                        Console.WriteLine(" 1- Onboarding \n " +
                            "2- Show All Employees\n " +
                            "3- Find Employee by id\n " +
                            "4- Sort Employees By Name\n " +
                            "5- Serialization & Deserialization\n " +
                            "6- Show Annual Salary\n " +
                            "7- Promote Employee\n " +
                            "8- Get Employees of each Department:\n " +
                            "9- Calculate Total Payroll\n" +
                            "10- Exit");

                        input = Helper.TakeInput(1);

                        ProcessOption(hr, input);
                    }
                    while (input != 10 && !Config.CurrentEnv.Equals(Env.Dev));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter number from 1 to 9");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SubscribeEvents(HR hr)
        {
            this.PromotionDelegate += hr.IncreaseSalary;
            this.PromotionDelegate += hr.UpdateJobTitle;
        }

        private void ProcessOption(HR hr, int input)
        {
            switch (input)
            {
                case 1:
                    hr.OnboardEmployees(MessageHandler.PrintResponse);
                    break;
                case 2:
                    hr.ShowAllEmployees();
                    break;
                case 3:
                    Console.WriteLine("Enter Employee id:");

                    int id = Helper.TakeInput(1004);

                    this.SelectedEmployee = hr.FindEmployee(id);

                    this.SelectedEmployee.GetEmployeeData();

                    Employee _employee = new FullTimeEmployee();

                    if (_employee is FullTimeEmployee fullTimeEmployee)
                    {
                        fullTimeEmployee.MonthlyWorkHours = 160;

                        Console.WriteLine("No of Working Hours: {0}", fullTimeEmployee.MonthlyWorkHours);
                    }
                    break;
                case 4:
                    hr.SortEmployeesByName();
                    goto case 2;
                case 5:
                    Serializer<Employee> serialization = new Serializer<Employee>();

                    string serializedXml = serialization.SerializeXml<Employee>(this.SelectedEmployee);

                    Console.WriteLine(serializedXml);

                    Employee deserializedEmpData = serialization.DeserializeXml(serializedXml);

                    goto case 3;
                case 6:
                    this.SelectedEmployee.GetAnnualSalary();
                    break;
                case 7:
                    Employee updatedEmployee = this.ProcessPromotion();
                    break;
                case 8:
                    hr.GroupEmployeesByDepartment();
                    break;
                case 9:
                    hr.CalculateTotalPayroll();
                    break;
                case 10:
                    Console.WriteLine("Program Exited");
                    break;
                default:
                    Console.WriteLine("Please select the correct option");
                    break;
            }
        }

        public Employee ProcessPromotion()
        {
            PromotionDelegate(this.SelectedEmployee);
            return this.SelectedEmployee;
        }
    }
}
