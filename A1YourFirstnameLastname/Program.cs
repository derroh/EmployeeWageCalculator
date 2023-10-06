// See https://aka.ms/new-console-template for more information
using A1YourFirstnameLastname;
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

        if (!int.TryParse(choice, out int num1))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-6");
            continue;
        }
        return num1;
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

        if (!int.TryParse(choice, out int num1))
        {
            Console.WriteLine("Invalid selection. Please select a number between 0-5");
            continue;
        }
        return num1;
    }
}
void deleteEmployee(EmployeeType employeeType)
{
    //first display a list of all employees from the selected category
    var SalaryPlusCommissionEmployees = employees.Where(x => x.EmployeeType == employeeType).ToList();
    DisplayInTable(SalaryPlusCommissionEmployees);
    //ask the user for the Employee ID of the employee that user wants to delete and fetch that employee from the collection.

    Console.WriteLine("Please enter an employee Id to delete");

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
        switch (DisplayDeleteEmployeeMenu())
        {
            case 1: EditHourlyEmployee(); break;
            case 2: EditCommissionEmployee(); break;
            case 3: EditSalariedEmployee(); break;
            case 4: EditSalaryPlusCommissionEmployee(); break;
            case 5: runEditEmployee = false; break;
        }
    } while (runEditEmployee);
}

void EditSalaryPlusCommissionEmployee()
{
    Console.WriteLine("Please enter an employee Id to delete");

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
            //update

            Console.WriteLine("Please Provide commision rate");
            string commisionRate = Console.ReadLine();

            if (!int.TryParse(commisionRate, out int num1))
            {
                Console.WriteLine("Invalid number. Try again.");
                continue;
            }


            Console.WriteLine("Please Provide your gross sales");
            string grossSales = Console.ReadLine();

            if (!decimal.TryParse(grossSales, out decimal num2))
            {
                Console.WriteLine("Invalid number. Try again.");
                continue;
            }

            Console.WriteLine("Please Provide your weekly salary");
            string weeklySalary = Console.ReadLine();

            if (!decimal.TryParse(grossSales, out decimal num3))
            {
                Console.WriteLine("Invalid number. Try again.");
                continue;
            }

            employee.EmployeeName = name;
            employee.EmployeeType = EmployeeType.HourlyEmployee;
            employee.CommissionRate = num1;
            employee.GrossSales = num2;
            employee.WeeklySalary = num3;

            break;
        }
        else
        {
            Console.WriteLine($"Deletion Failed! Employee with id {employeeId} was not found.\n");
        }
    } 
}

void EditSalariedEmployee()
{
   
}

void EditCommissionEmployee()
{
   
}

void EditHourlyEmployee()
{
   
}

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
    Console.WriteLine("Please Provide employee name");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Please Provide commision rate");
        string commisionRate = Console.ReadLine();

        if (!int.TryParse(commisionRate, out int num1))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }


        Console.WriteLine("Please Provide your gross sales");
        string grossSales = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal num2))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }

        Console.WriteLine("Please Provide your weekly salary");
        string weeklySalary = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal num3))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }

        var hourlyEmployee = new SalaryPlusCommissionEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, CommissionRate = num1, GrossSales = num2,WeeklySalary = num3 };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}

void AddSalariedEmployee()
{
    Console.WriteLine("Please Provide employee name");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Please Provide weekly salary");
        string commisionRate = Console.ReadLine();

        if (!int.TryParse(commisionRate, out int num1))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }


        var hourlyEmployee = new SalariedEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, WeeklySalary =  num1};
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}

void AddCommissionEmployee()
{
    Console.WriteLine("Please Provide employee name");
    string name = Console.ReadLine();

    while (true)
    {

        Console.WriteLine("Please Provide commision rate");
        string commisionRate = Console.ReadLine();

        if (!int.TryParse(commisionRate, out int num1))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }


        Console.WriteLine("Please Provide your gross sales");
        string grossSales = Console.ReadLine();

        if (!decimal.TryParse(grossSales, out decimal num2))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }

        var hourlyEmployee = new CommissionEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, CommissionRate = num1,GrossSales = num2 };
        AddNewEmployee(hourlyEmployee);
        DisplayInTable(employees);
        break;
    }
}

void AddHourlyEmployee()
{
    Console.WriteLine("Please Provide employee name");
    string name = Console.ReadLine();

    while (true) 
    {       

        Console.WriteLine("Please Provide your Hourly Wage");
        string HourlyWage = Console.ReadLine();

        if (!int.TryParse(HourlyWage, out int num1))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }


        Console.WriteLine("Please Provide your Hours Worked");
        string HoursWorked = Console.ReadLine();

        if (!decimal.TryParse(HourlyWage, out decimal num2))
        {
            Console.WriteLine("Invalid number. Try again.");
            continue;
        }

        var hourlyEmployee = new HourlyEmployee { EmployeeName = name, EmployeeType = EmployeeType.HourlyEmployee, HourlyWage = num1, HoursWorked = num2 };
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
    // Set table headers
    string header = String.Format("{0,-15} {1,-30} {2,-40} {3,-20} {4,-20} {5,-20}", "Employee Id", "Employee Name", "Employee Type", "Gross Earnings", "Net Earnings", "Tax");
    Console.WriteLine(header);
    Console.WriteLine(new string('-', header.Length)); // draw line

    foreach (var employee in employees)
    {
        Console.WriteLine(String.Format("{0,-15} {1,-30} {2,-40} {3, -20} {4, -20} {5, -20}", employee.EmployeeId, employee.EmployeeName, employee.EmployeeType, employee.GrossEarnings, employee.NetEarnings, employee.Tax));
    }
    Console.WriteLine("\n");
}


void PopulateSampleData()
{
    
    employees.Add(new HourlyEmployee { EmployeeId = 1, EmployeeName = "Derrick", EmployeeType = EmployeeType.HourlyEmployee, HourlyWage = 100,  HoursWorked = 4});
    employees.Add(new CommissionEmployee { EmployeeId = 2, EmployeeName = "Murugi", EmployeeType = EmployeeType.CommissionEmployee, CommissionRate = 5,GrossSales = 100000 });
    employees.Add(new SalariedEmployee { EmployeeId = 3, EmployeeName = "Witness", EmployeeType = EmployeeType.SalariedEmployee, WeeklySalary = 10000 });
    employees.Add(new SalaryPlusCommissionEmployee { EmployeeId = 4, EmployeeName = "Ekira", EmployeeType = EmployeeType.SalaryPlusCommissionEmployee, WeeklySalary = 200, CommissionRate = 5, GrossSales = 20000 });
}

