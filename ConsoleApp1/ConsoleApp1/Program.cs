using System;
using System.Collections.Generic;
using Student;
using SingleTon;
namespace ConsoleApp1
{
    public delegate bool PromoteDel(Employee emp);
    //above declaration is not needed if we use func or action or predicate
    class Program
    {
        static void Main(string[] args)
        {
            //IStudent S1 = new IStudent(111, "John", 490);
            //IStudent S2 = new IStudent(105, "Max", 492);
            //IStudent S3 = new IStudent(101, "Levi", 480);
            //List<IStudent> Students = new List<IStudent>() { S1, S2, S3 };
            //Students.Sort();
            //foreach(IStudent s in Students)
            //{
            //    Console.WriteLine(" " + s.Name);
            //}


            //Singleton pattern example
            TableServers host1 = TableServers.GetTableserver();
            TableServers host2 = TableServers.GetTableserver();
            for(int i =0; i <= 4; i++)
            {
                Console.WriteLine("/n"+host1.GetNextServer());
                Console.WriteLine("/n" +host2.GetNextServer());
            }
            List<Employee> employees = new List<Employee>()
            {
                new Employee(100,3,3000,"Vino"),
                new Employee(101,4,4000,"Max"),
                new Employee(102,3,2500,"Bob"),
                new Employee(103,5,6000,"Viiki"),
                new Employee(104,6,7000,"Mary"),
                new Employee(105,2,3000,"Pavi"),
                new Employee(106,5,4500,"Joe"),
            };
            List<Employee> promotedEmployees= Employee.PromoteEmployee(employees, (Employee e) =>
             {
                 if (e.salary > 3000) { return true; }
                 else
                 {
                     return false;
                 }
             }
             
             );
            Console.WriteLine("Promoted Employees are ");
            foreach(Employee e in promotedEmployees)
            {
                Console.WriteLine(e.Name);

            }
            Console.ReadLine();
        }
    }
}
