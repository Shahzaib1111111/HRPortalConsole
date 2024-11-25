namespace Portal
{
    class PartTimeEmployee : Employee
    {
        public PartTimeEmployee() { }
        public int HourlyRate { get; set; }
        public int WeeklyWorkHours { get; set; }
        public PartTimeEmployee(int id, string name, int age, decimal monthlySalary, Department department, string jobTitle) : base(id, name, age, monthlySalary, department, jobTitle)
        {
        }
        public Department GetDepartment()
        {
            return Department;
        }
    }
}
