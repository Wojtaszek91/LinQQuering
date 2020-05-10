using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee("Mateusz", "Konieczny", Position.Administrator, 7500, new DateTime(2015,05,05)),
            new Employee("Łukasz", "Kowalski", Position.Developer, 9500, new DateTime(2000,04,12)),
            new Employee("Damian", "Baczyński", Position.Administrator, 11320, new DateTime(2003,09,1)),
            new Employee("Dominik", "Nieznany", Position.ApplicationSpecialist, 6589, new DateTime(2007,02,20)),
            new Employee("Jan", "Szczęsny", Position.ApplicationSpecialist, 8240, new DateTime(2011,08,28)),
            new Employee("Dawid", "Nieszczęsny", Position.Developer, 10000, new DateTime(1999,08,30)),
            new Employee("Tobiasz", "Topola", Position.Developer, 5000, new DateTime(2016,01,15)),
            new Employee("Anita", "Pałecka", Position.ApplicationSpecialist, 8500, new DateTime(2010,05,14)),
        };

            foreach (var employee in employees)
            {
                Console.WriteLine(String.Join(" ", new string[] {
                employee.LastName,
                employee.FirstName,
                employee.Reward.ToString()
            }));
            }

            foreach (var employee in employees)
            {
                if (employee.Position == Position.Administrator)
                {
                    Console.WriteLine(String.Join(" ", new string[] {
                employee.LastName,
                employee.FirstName,
                employee.Reward.ToString()
                }));
                }
            }

            foreach(var emp in employees)
            {
                if(emp.Reward > 6000 && emp.Reward < 9100)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Reward);
                }
            }

            IEnumerable<String> employeesName =
    from employee in employees
    where employee.Position == Position.Administrator
    select employee.LastName + " " + employee.FirstName;

            IEnumerable<string> emps =
                from employee in employees
                where employee.Reward > 2000 && employee.Reward < 7000
                select employee.FirstName + " " + employee.LastName;
            Console.WriteLine("===========");
            foreach(var emp in emps)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("--------------");
            var empLastNamesWithRewardMoreThan5000 = employees.Where(emp => emp.Reward > 5000).Select(emp => emp.LastName);
            foreach (var emp in empLastNamesWithRewardMoreThan5000) Console.WriteLine(emp);

            Console.WriteLine("===-===-=-=-=-=-=");
            var threeEmpsWithHigestReward = employees.OrderByDescending(emp => emp.Reward).Take(3);
            foreach (var emp in threeEmpsWithHigestReward) Console.WriteLine(emp.LastName + " with reward of " + emp.Reward);
        }
    }

    public enum Position
    {
        Administrator, ApplicationSpecialist, Developer
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public double Reward { get; set; }
        public DateTime EmploymentDate { get; set; }

        public Employee(string firstName, string lastName, Position position, double reward, DateTime employmentDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Reward = reward;
            EmploymentDate = employmentDate;
        }
    }
    }