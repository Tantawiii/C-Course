#pragma warning disable
enum Gender
{
    Male,
    Female,
    Unknown
}

struct HireDate
{
    public int Day;
    public int Month;
    public int Year;

    public HireDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    // Display method
    public string DisplayDate()
    {
        return $"{Day}/{Month}/{Year}";
    }
}

struct Employee
{
    public int id;
    public double salary;
    public HireDate hireDate;
    public Gender gender;
    public Employee(int id, double salary, HireDate hireDate, Gender gender)
    {
        this.id = id;
        this.salary = salary;
        this.hireDate = hireDate;
        this.gender = gender;
    }

    public void DisplayEmployee()
    {
        Console.WriteLine($"ID: {id}, Salary: {salary:C}, Hire Date: {hireDate.DisplayDate()}, Gender: {gender}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = new Employee[3];
        int count = 0;

        while (true)
        {
            Console.WriteLine("\n1- Add Employee\n2- Print Employees\n3- Exit");
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    if (count >= employees.Length)
                    {
                        Console.WriteLine("Employee array is full!");
                        break;
                    }

                    Console.Write("Enter Employee ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Employee Salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    Console.Write("Enter Hiring Day: ");
                    int day = int.Parse(Console.ReadLine());

                    Console.Write("Enter Hiring Month: ");
                    int month = int.Parse(Console.ReadLine());

                    Console.Write("Enter Hiring Year: ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("Enter Gender (Male/Female) or (M/F): ");
                    string genderInput = Console.ReadLine();
                    Gender gender = Gender.Unknown;
                    if (genderInput.Equals("Male", StringComparison.OrdinalIgnoreCase) || genderInput.Equals("M", StringComparison.OrdinalIgnoreCase))
                        gender = Gender.Male;
                    else if (genderInput.Equals("Female", StringComparison.OrdinalIgnoreCase) || genderInput.Equals("F", StringComparison.OrdinalIgnoreCase))
                        gender = Gender.Female;
                    else
                    {
                        Console.WriteLine("So you are genderless, alrighty then! Mister Gender Classifed Unknown");
                    }

                    employees[count] = new Employee(id, salary, new HireDate(day, month, year), gender);
                    count++;
                    Console.WriteLine("Employee added successfully!");
                    break;

                case 2:
                    if (count == 0)
                    {
                        Console.WriteLine("No employees to display.");
                    }
                    else
                    {
                        Console.WriteLine("\nEmployee Details:\n");
                        for (int i = 0; i < count; i++)
                        {
                            employees[i].DisplayEmployee();
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting.. ASTA LAVISTA BABY!!!");
                    return;

                default:
                    Console.WriteLine("Invalid choice! I mean come on, only 1,2, & 3 are applicable. THEY ARE 3 CHOICES!!!");
                    break;
            }
        }
    }
}