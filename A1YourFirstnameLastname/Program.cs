// See https://aka.ms/new-console-template for more information
using A1YourFirstnameLastname;

bool continueRunning = true;

List<Employee> employees = new List<Employee>();

do
{
    // Display Main Menu and handle user choice
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
        "6 - Exit");

    return Convert.ToInt32(Console.ReadLine());
}

void SearchEmployee()
{
    throw new NotImplementedException();
}

void ViewEmployees()
{
    throw new NotImplementedException();
}

void DeleteEmployee()
{
    throw new NotImplementedException();
}

void EditEmployee()
{
    throw new NotImplementedException();
}

void AddEmployee()
{
    do
    {
        // Display Main Menu and handle user choice
        switch (DisplayAddEmployeeMenu())
        {
            case 1: AddHourlyEmployee(); break;
            case 2: AddCommissionEmployee(); break;
            case 3: AddSalariedEmployee(); break;
            case 4: AddSalaryPlusCommissionEmployee(); break;
            case 5: continueRunning = false; break;           
        }
    } while (continueRunning);
    
}

void AddSalaryPlusCommissionEmployee()
{
    throw new NotImplementedException();
}

void AddSalariedEmployee()
{
    throw new NotImplementedException();
}

void AddCommissionEmployee()
{
    throw new NotImplementedException();
}

void AddHourlyEmployee()
{
    throw new NotImplementedException();
}

int DisplayAddEmployeeMenu()
{
    Console.WriteLine("** Select option** \n" +
        "1 - Add Hourly Employee\n" +
        "2 - Add Commission Employee\n" +
        "3 - Add Salaried Employee\n" +
        "4 - Add Salary Plus Commission Employee\n" +
        "5 - Back to Main Menu\r\n");
    return Convert.ToInt32(Console.ReadLine());
}
void PopulateSampleData()
{
    
    employees.Add(new HourlyEmployee { EmployeeId = 1, EmployeeName = "Derrick", EmployeeType = EmployeeType.HourlyEmployee, HourlyWage = 100,  HoursWorked = 4});
    employees.Add(new SalariedEmployee { EmployeeId = 1, EmployeeName = "Murugi", EmployeeType = EmployeeType.HourlyEmployee, WeeklySalary = 200 });
   
}

