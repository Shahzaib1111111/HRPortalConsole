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
                            "5- Show Annual Salary\n " +
                            "6- Promote Employee\n " +
                            "7- Get Employees of each Department:\n " +
                            "8- Exit");

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
                    Console.WriteLine("Enter Employee id:");

                    int id = Helper.TakeInput(1004);

                    Employee _employee = new FullTimeEmployee();

                    if (_employee is FullTimeEmployee fullTimeEmployee)
                    {
                        fullTimeEmployee.MonthlyWorkHours = 160;

                        Console.WriteLine("No of Working Hours: {0}", fullTimeEmployee.MonthlyWorkHours);
                    }
                    break;
                case 3:
                    hr.SortEmployeesByName();
                    goto case 2;
                case 4:
                    this.SelectedEmployee.GetAnnualSalary();
                    break;
                case 5:
                    Employee updatedEmployee = this.ProcessPromotion();
                    break;
                case 6:
                    hr.GroupEmployeesByDepartment();
                    break;
                case 7:
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
