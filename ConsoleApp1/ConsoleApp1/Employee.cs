using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   
    public class Employee
    {
        public int empId { get; set; }
        public int exp { get; set; }
        public int salary { get; set; }
        public string Name { get; set; }
        public Employee()
        {

        }
        public Employee(int id,int _exp,int sal,string name)
        {
            empId = id;
            exp = _exp;
            salary = sal;
            Name = name;
        }

       private static  List<Employee> emp = new List<Employee>();
        //public static List<Employee> PromoteEmployee(List<Employee> employees, PromoteDel del)
        public static List<Employee> PromoteEmployee(List<Employee> employees, Predicate<Employee> del)
        {
            
            foreach (Employee e in employees)
            {
                if (del(e))
                {
                    emp.Add(e);
                }
            }
            return emp;

        }
    }
}
