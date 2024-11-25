﻿namespace Portal
{
    class FullTimeEmployee : Employee
    {
        public int MonthlyWorkHours { get; set; }

        public FullTimeEmployee()
        {

        }
        public FullTimeEmployee(int id, string name, int age, decimal monthlySalary, Department department, string jobTitle) : base(id, name, age, monthlySalary, department, jobTitle)
        {
        }
        public Department GetDepartment()
        {
            return Department;
        }
    }
}
