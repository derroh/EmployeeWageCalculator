﻿using ConsoleTables;
using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

bool continueRunning = true;

List<Employee> employees = new List<Employee>();

do
{
    // Display Main Menu and handle user choice

    PopulateSampleData();

    switch (DisplayMainMenu())
    {
        case 1: AddEmployee(); break;
        case 2: EditEmployee(); break;
        case 3: DeleteEmployee(); break;
        case 4: ViewEmployees(); break;
        case 5: SearchEmployee(); break;
        case 6: continueRunning = false; break;
    }
} while (continueRunning);

int DisplayMainMenu()
{
    Console.WriteLine("************** Welcome to Employee Wage Calculator ******************\n" +
        "Please select an option below\n\n" +
        "1 - Add Employee\n" +
        "2 - Edit Employee\n" +
        "3 - Delete Employee\n" +
        "4 - View Employees\n" +
        "5 - Search Employee\n" +
        "6 - Exit" +
        "\n" +
        "\n");


    while (true)
    {
        string choice = Console.ReadLine();

        if (!int.TryParse(choice, out int _choice))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-6");
            continue;
        }
        return _choice;
    } 
}

void SearchEmployee()
{
    Console.WriteLine("Please enter an employee name to search");
    string name = Console.ReadLine();


    var results = employees.Where(x => x.EmployeeName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

    DisplayInTable(results);
}

void ViewEmployees()
{
    DisplayInTable(employees.OrderByDescending(x =>x.EmployeeType).ToList());
}

//Delete
void DeleteEmployee()
{
    bool runDeleteEmployee = true;
    do
    {
        // Display Main Menu and handle user choice
        switch (DisplayDeleteEmployeeMenu())
        {
            case 1: DeleteHourlyEmployee(); break;
            case 2: DeleteCommissionEmployee(); break;
            case 3: DeleteSalariedEmployee(); break;
            case 4: DeleteSalaryPlusCommissionEmployee(); break;
            case 5: runDeleteEmployee = false; break;
        }
    } while (runDeleteEmployee);
}
int DisplayDeleteEmployeeMenu()
{
    Console.WriteLine("\n" +
        "** Select option** \n" +
        "1 - Delete Hourly Employee\n" +
        "2 - Delete Commission Employee\n" +
        "3 - Delete Salaried Employee\n" +
        "4 - Delete Salary Plus Commission Employee\n" +
        "5 - Back to Main Menu\r\n" +
        "******************************" +
        "\n");

    while (true)
    {
        string choice = Console.ReadLine();

        if (!int.TryParse(choice, out int _choice))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-5");
            continue;
        }
        return _choice;
    }
}

void deleteEmployee(EmployeeType employeeType)
{
    //first display a list of all employees from the selected category
    var SalaryPlusCommissionEmployees = employees.Where(x => x.EmployeeType == employeeType).ToList();
    DisplayInTable(SalaryPlusCommissionEmployees);
    //ask the user for the Employee ID of the employee that user wants to delete and fetch that employee from the collection.

    Console.WriteLine("Enter an employee Id to delete: ");

    while (true)
    {
        string employeeId = Console.ReadLine();

        if (!int.TryParse(employeeId, out int empId))
        {
            Console.WriteLine("Invalid input. Please input an integer value");
            continue;
        }

        var employee = employees.FirstOrDefault(x => x.EmployeeId == empId);

        if (employee != null)
        {
            employees.Remove(employee);

            Console.WriteLine("Deletion Success!\n");
            DisplayInTable(employees.Where(x => x.EmployeeType == employeeType).ToList());
            break;
        }
        else
        {
            Console.WriteLine($"Deletion Failed! Employee with id {employeeId} was not found.\n");
        }
    }
}
void DeleteSalaryPlusCommissionEmployee()
{
    deleteEmployee(EmployeeType.SalaryPlusCommissionEmployee);
}

void DeleteSalariedEmployee()
{
    deleteEmployee(EmployeeType.SalariedEmployee);
}

void DeleteCommissionEmployee()
{
    deleteEmployee(EmployeeType.CommissionEmployee);
}

void DeleteHourlyEmployee()
{
    deleteEmployee(EmployeeType.HourlyEmployee);
}

//Edit
void EditEmployee()
{
    bool runEditEmployee = true;
    do
    {
        // Display Main Menu and handle user choice
        switch (DisplayEditEmployeeMenu())
        {
            case 1: EditHourlyEmployee(); break;
            case 2: EditCommissionEmployee(); break;
            case 3: EditSalariedEmployee(); break;
            case 4: EditSalaryPlusCommissionEmployee(); break;
            case 5: runEditEmployee = false; break;
        }
    } while (runEditEmployee);
}
int DisplayEditEmployeeMenu()
{
    Console.WriteLine("\n" +
        "** Select option** \n" +
        "1 - Edit Hourly Employee\n" +
        "2 - Edit Commission Employee\n" +
        "3 - Edit Salaried Employee\n" +
        "4 - Edit Salary Plus Commission Employee\n" +
        "5 - Back to Main Menu\r\n" +
        "******************************" +
        "\n");

    while (true)
    {
        string choice = Console.ReadLine();

        if (!int.TryParse(choice, out int _choice))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-5");
            continue;
        }
        return _choice;
    }
}
void EditSalaryPlusCommissionEmployee()
{
    DisplayInTable(employees);

    Console.WriteLine("Enter an employee Id to edit: ");

    while (true)
    {
        string employeeId = Console.ReadLine();

        if (!int.TryParse(employeeId, out int empId))
        {
            Console.WriteLine("Invalid input. Please input an integer value");
            continue;
        }

        Console.WriteLine("Enter the employee name: ");
        string name = Console.ReadLine();

        var employee = employees.Find(x => x.EmployeeId == empId) as SalaryPlusCommissionEmployee;        

        if (employee != null)
        {
            //update

            Console.WriteLine("Enter the commision rate: ");
            string commisionRate = Console.ReadLine();

            if (!int.TryParse(commisionRate, out int _commisionRate))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }


            Console.WriteLine("Enter the gross sales amount: ");
            string grossSales = Console.ReadLine();

            if (!decimal.TryParse(grossSales, out decimal _grossSales))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }

            Console.WriteLine("Enter the weekly salary amount: ");
            string weeklySalary = Console.ReadLine();

            if (!decimal.TryParse(weeklySalary, out decimal _weeklySalary))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }

            employee.EmployeeName = name;
            employee.EmployeeType = EmployeeType.SalaryPlusCommissionEmployee;
            employee.CommissionRate = _commisionRate;
            employee.GrossSales = _grossSales;
            employee.WeeklySalary = _weeklySalary;

            DisplayInTable(employees);

            break;
        }
        else
        {
            Console.WriteLine($"Update Failed! Employee with id {employeeId} was not found.\n");
        }
    } 
}

void EditSalariedEmployee()
{
    DisplayInTable(employees);

    Console.WriteLine("Enter an employee Id to edit: ");

    while (true)
    {
        string employeeId = Console.ReadLine();

        if (!int.TryParse(employeeId, out int empId))
        {
            Console.WriteLine("Invalid input. Please input an integer value");
            continue;
        }

        Console.WriteLine("Enter the employee name: ");
        string name = Console.ReadLine();

        var employee = employees.Find(x => x.EmployeeId == empId) as SalariedEmployee;

        if (employee != null)
        {
            Console.WriteLine("Enter the weekly salary: ");
            string weeklySalary = Console.ReadLine();

            if (!decimal.TryParse(weeklySalary, out decimal _weeklySalary))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }

            employee.EmployeeName = name;
            employee.EmployeeType = EmployeeType.SalariedEmployee;
           
            employee.WeeklySalary = _weeklySalary;

            DisplayInTable(employees);

            break;
        }
        else
        {
            Console.WriteLine($"Update Failed! Employee with id {employeeId} was not found.\n");
        }
    }
}

void EditCommissionEmployee()
{
    DisplayInTable(employees);

    Console.WriteLine("Enter an employee Id to edit: ");

    while (true)
    {
        string employeeId = Console.ReadLine();

        if (!int.TryParse(employeeId, out int empId))
        {
            Console.WriteLine("Invalid input. Please input an integer value");
            continue;
        }

        Console.WriteLine("Enter the employee name: ");
        string name = Console.ReadLine();

        var employee = employees.Find(x => x.EmployeeId == empId) as CommissionEmployee;

        if (employee != null)
        {
            //update

            Console.WriteLine("Enter the commision rate: ");
            string commisionRate = Console.ReadLine();

            if (!int.TryParse(commisionRate, out int num1))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }


            Console.WriteLine("Enter the gross sales: ");
            string grossSales = Console.ReadLine();

            if (!decimal.TryParse(grossSales, out decimal num2))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }
                        

            employee.EmployeeName = name;
            employee.EmployeeType = EmployeeType.CommissionEmployee;
            employee.CommissionRate = num1;
            employee.GrossSales = num2;

            DisplayInTable(employees);

            break;
        }
        else
        {
            Console.WriteLine($"Update Failed! Employee with id {employeeId} was not found.\n");
        }
    }
}

void EditHourlyEmployee()
{
    DisplayInTable(employees);

    Console.WriteLine("Please enter an employee Id to edit: ");

    while (true)
    {
        string employeeId = Console.ReadLine();

        if (!int.TryParse(employeeId, out int empId))
        {
            Console.WriteLine("Invalid input. Please input an integer value");
            continue;
        }

        Console.WriteLine("Please Provide employee name: ");
        string name = Console.ReadLine();

        var employee = employees.Find(x => x.EmployeeId == empId) as HourlyEmployee;

        if (employee != null)
        {
            //update

            Console.WriteLine("Please Provide hours worked: ");
            string commisionRate = Console.ReadLine();

            if (!int.TryParse(commisionRate, out int num1))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }


            Console.WriteLine("Please Provide hourly wage: ");
            string grossSales = Console.ReadLine();

            if (!decimal.TryParse(grossSales, out decimal num2))
            {
                Console.WriteLine("Invalid value. Try again.");
                continue;
            }


            employee.EmployeeName = name;
            employee.EmployeeType = EmployeeType.HourlyEmployee;
            employee.HoursWorked = num1;
            employee.HourlyWage = num2;

            DisplayInTable(employees);

            break;
        }
        else
        {
            Console.WriteLine($"Update Failed! Employee with id {employeeId} was not found.\n");
        }
    }
}
//Add
void AddEmployee()
{
    bool runAddEmployee = true;
    do
    {
        // Display Main Menu and handle user choice
        switch (DisplayAddEmployeeMenu())
        {
            case 1: AddHourlyEmployee(); break;
            case 2: AddCommissionEmployee(); break;
            case 3: AddSalariedEmployee(); break;
            case 4: AddSalaryPlusCommissionEmployee(); break;
            case 5: runAddEmployee = false; break;           
        }
    } while (runAddEmployee);
    
}
int DisplayAddEmployeeMenu()
{
    Console.WriteLine("\n" +
        "** Select option** \n" +
        "1 - Add Hourly Employee\n" +
        "2 - Add Commission Employee\n" +
        "3 - Add Salaried Employee\n" +
        "4 - Add Salary Plus Commission Employee\n" +
        "5 - Back to Main Menu\r\n" +
        "******************************" +
        "\n");

    while (true)
    {
        string choice = Console.ReadLine();

        if (!int.TryParse(choice, out int num1))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-5");
            continue;
        }
        return num1;
    }
}
void AddSalaryPlusCommissionEmployee()
{
    Console.WriteLine("Enter the employee name: ");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Enter the commision rate: ");
        string commisionRate = Console.ReadLine();

        if (!decimal.TryParse(commisionRate, out decimal _commisionRate))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }


        Console.WriteLine("Enter the gross sales amount: ");
        string grossSales = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal num2))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }

        Console.WriteLine("Enter the weekly salary amount: ");
        string weeklySalary = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal _weeklySalary))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }

        var hourlyEmployee = new SalaryPlusCommissionEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, CommissionRate = _commisionRate, GrossSales = num2,WeeklySalary = _weeklySalary };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}
void AddSalariedEmployee()
{
    Console.WriteLine("Enter the employee name: ");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Enter the weekly salary amount: ");
        string weeklySalary = Console.ReadLine();

        if (!int.TryParse(weeklySalary, out int _weeklySalary))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }


        var hourlyEmployee = new SalariedEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, WeeklySalary = _weeklySalary };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}
void AddCommissionEmployee()
{
    Console.WriteLine("Enter the employee name: ");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Enter the commision rate: ");
        string commisionRate = Console.ReadLine();

        if (!int.TryParse(commisionRate, out int _commisionRate))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }


        Console.WriteLine("Enter the gross sales amount: ");
        string grossSales = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal _grossSales))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }

        var hourlyEmployee = new CommissionEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, CommissionRate = _commisionRate, GrossSales = _grossSales };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}
void AddHourlyEmployee()
{
    Console.WriteLine("Enter the employee name: ");
    string name = Console.ReadLine();

    while (true) 
    {       

        Console.WriteLine("Enter the hourly wage amount: ");
        string HourlyWage = Console.ReadLine();

        if (!int.TryParse(HourlyWage, out int _HourlyWage))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }


        Console.WriteLine("Enter the hours worked: ");
        string HoursWorked = Console.ReadLine();

        if (!decimal.TryParse(HourlyWage, out decimal _hoursWorked))
        {
            Console.WriteLine("Invalid value. Try again.");
            continue;
        }

        var hourlyEmployee = new HourlyEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, HourlyWage = _HourlyWage, HoursWorked = _hoursWorked };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }   
}
void AddNewEmployee(Employee employee)
{
    var highestId = employees.Any() ? employees.Max(x => x.EmployeeId) : 1;
    employee.EmployeeId = highestId + 1;
    employees.Add(employee);
}



static void DisplayInTable(List<Employee> employees)
{
    var groups = employees.GroupBy(x => x.EmployeeType).Distinct();

    foreach (var group in groups)
    {
        if (group.Key == EmployeeType.HourlyEmployee)
        {
            var table = new ConsoleTable("Employee Id", "Employee Name", "Employee Type", "Hourly Wage", "Hours Worked");

            foreach (HourlyEmployee employee in group)
            {
                table.AddRow(employee.EmployeeId, employee.EmployeeName, employee.EmployeeType, $"${employee.HourlyWage}", employee.HoursWorked);
            }

            table.Write();
            Console.WriteLine();
        }
        else if (group.Key == EmployeeType.CommissionEmployee)
        {
            var table = new ConsoleTable("Employee Id", "Employee Name", "Employee Type", "Commission Rate", "Gross Sales");

            foreach (CommissionEmployee employee in group)
            {
                table.AddRow(employee.EmployeeId, employee.EmployeeName, employee.EmployeeType, $"{employee.CommissionRate}%", $"${employee.GrossSales}");
            }

            table.Write();
            Console.WriteLine();
        }
        else if (group.Key == EmployeeType.SalariedEmployee)
        {
            var table = new ConsoleTable("Employee Id", "Employee Name", "Employee Type", "Weekly Salary");

            foreach (SalariedEmployee employee in group)
            {
                table.AddRow(employee.EmployeeId, employee.EmployeeName, employee.EmployeeType, $"${employee.WeeklySalary}");
            }

            table.Write();
            Console.WriteLine();
        }
        else if (group.Key == EmployeeType.SalaryPlusCommissionEmployee)
        {
            var table = new ConsoleTable("Employee Id", "Employee Name", "Employee Type", "Weekly Salary", "Commission Rate", "Gross Sales");

            foreach (SalaryPlusCommissionEmployee employee in group)
            {
                table.AddRow(employee.EmployeeId, employee.EmployeeName, employee.EmployeeType, $"${employee.WeeklySalary}", $"{employee.CommissionRate}%", $"${employee.GrossSales}");
            }

            table.Write();
            Console.WriteLine();
        }

    }    
}


void PopulateSampleData()
{
    
    employees.Add(new HourlyEmployee { EmployeeId = 1, EmployeeName = "Derrick", EmployeeType = EmployeeType.HourlyEmployee, HourlyWage = 100,  HoursWorked = 4});
    employees.Add(new CommissionEmployee { EmployeeId = 2, EmployeeName = "Murugi", EmployeeType = EmployeeType.CommissionEmployee, CommissionRate = 5,GrossSales = 100000 });
    employees.Add(new SalariedEmployee { EmployeeId = 3, EmployeeName = "Witness", EmployeeType = EmployeeType.SalariedEmployee, WeeklySalary = 10000 });
    employees.Add(new SalaryPlusCommissionEmployee { EmployeeId = 4, EmployeeName = "Ekira", EmployeeType = EmployeeType.SalaryPlusCommissionEmployee, WeeklySalary = 200, CommissionRate = 5, GrossSales = 20000 });
}

public abstract class Employee
{
    public EmployeeType EmployeeType { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }

    public abstract decimal GrossEarnings { get; }

    public decimal Tax => GrossEarnings * 0.2m;

    public decimal NetEarnings => GrossEarnings - Tax;
}
public class CommissionEmployee : Employee
{
    public decimal GrossSales { get; set; }
    public decimal CommissionRate { get; set; }

    public override decimal GrossEarnings => GrossSales * CommissionRate;
}
public class HourlyEmployee : Employee
{
    public decimal HoursWorked { get; set; }
    public decimal HourlyWage { get; set; }

    public override decimal GrossEarnings
    {
        get
        {
            return HoursWorked <= 40 ? HourlyWage * HoursWorked :
                40 * HourlyWage + (HoursWorked - 40) * HourlyWage * 1.5m;
        }
    }
}
public class SalariedEmployee : Employee
{
    public decimal WeeklySalary { get; set; }

    public override decimal GrossEarnings => WeeklySalary;
}
public class SalaryPlusCommissionEmployee : CommissionEmployee
{
    public decimal WeeklySalary { get; set; }

    public override decimal GrossEarnings => WeeklySalary + base.GrossEarnings;
}
public enum EmployeeType
{
    HourlyEmployee = 1,
    CommissionEmployee = 2,
    SalariedEmployee = 3,
    SalaryPlusCommissionEmployee = 4
}
