using HW_9.Classes;
using HW_9.Services;

internal class Program
{
    private static MyList<Person> company = new MyList<Person>(); 
    public static void Main(string[] args)
    {
        InteractionInterface();
    }

    public static void InteractionInterface()
    {
        int optionCounter = 5;
        Console.WriteLine("Here is our staff");
        if(company.Length == 0)
        {
            Console.WriteLine("We have nobody right now!");
        }
        else
        {
            ShowCompany();
        }
        Console.WriteLine("Hello, dear HR. Let's make some staff changes!");
        Console.WriteLine(" Hi, let's create a Company");
        Console.WriteLine("\n");
        Console.WriteLine(" Please choose what are going to do with them.");
        Console.WriteLine(" You can choose from: ");
        Console.WriteLine("\n");
        Console.WriteLine("1 - Hire a new employee;");
        Console.WriteLine("\n");
        Console.WriteLine("2 - Add multiple employees;");
        Console.WriteLine("\n");
        Console.WriteLine("3 - Fire an employee;");
        Console.WriteLine("\n");
        Console.WriteLine("4 - Fire multiple employees (by the number)");
        Console.WriteLine("\n");
        Console.WriteLine("5 - Sort by name");
        Console.WriteLine("\n");
        Console.WriteLine("6 - Exit");
        Console.WriteLine("\n");
        string? companyNumInput = Console.ReadLine();
        int n;
        bool isNumeric = int.TryParse(companyNumInput, out n);
        if (!isNumeric || n == 0 || n > optionCounter || n < 0)
        {
            WrongInput();
            InteractionInterface();
        }
        else
        {
            EmployeeIncreaser(n);
        }
        return;
    } 

    public static void EmployeeIncreaser(int choice)
    {
        if(choice == 0)
        {
            return;
        }

        if(choice == 1)
        {
            Person employee = CreateAnEmployee();

            company.AddAnElement(employee);

            InteractionInterface();
        }

        if (choice == 2)
        {
            Person[] division = new Person[0];

            while(true)
            {
                Person employee = CreateAnEmployee();

                ArrayPush(ref division, employee);

                Console.WriteLine("Would you like to Continue? If no, type 'stop'");
                string? shouldStop = Console.ReadLine();

                if(shouldStop == "stop")
                {
                    break;
                }
            }

            foreach(var pers in division)
            {
                company.AddAnElement(pers);
            }

            InteractionInterface();
        }

        if(choice == 3)
        {
            int length = company.Length;
            if (length <= 1)
            {
                Console.WriteLine("The company is empty! Hire some people!");
                InteractionInterface();
            }
            else
            {
                company.RemoveAnElement();
            }
            InteractionInterface();
        }

        if (choice == 4)
        {
            Console.WriteLine("Please enter a position from which the person will be removed");
            string? position = Console.ReadLine();

            int n;
            bool isNumeric = int.TryParse(position, out n);

            if (!isNumeric || n <= 0 || n > company.Length)
            {
                WrongInput();
                InteractionInterface();
            }
            else
            {
                int length = company.Length;
                if (length <= 1)
                {
                    Console.WriteLine("The company is empty! Hire some people!");
                    InteractionInterface();
                }
                else
                {
                    company.RemoveAnElemenFromThePosition(n);
                }
            }

            InteractionInterface();
        }

        if(choice == 5)
        {
            company.SortByAge();
        }

        if(choice == 6)
        {
            return;
        } 
        else
        {
            WrongInput();
            InteractionInterface();
        }
    }

    public static Person CreateAnEmployee()
    {
        Console.WriteLine("Please enter a name of an employee: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Please enter an age of an employee: ");
        string? ageStr = Console.ReadLine();
        int age;
        bool isNumeric = int.TryParse(ageStr, out age);

        if(!isNumeric || age <= 0 || name == null || ageStr == null || name.Length < 3)
        {
            WrongInput();
            CreateAnEmployee();
        }
        Console.WriteLine("Employee Added!");
        return new Person(name, age);
    }

    public static void ShowCompany()
    {
        for (int i = 0; i < company.Length; i++)
        {
            int j = i;
            Console.WriteLine($"{j + 1} - {company.getArray[i].Name} - {company.getArray[i].Age}");
        }
    }

    public static void WrongInput()
    {
        Console.WriteLine("You've made a wrong input, please try again");
    }

    private static void ArrayPush<T>(ref T[] table, object value)
    {
        Array.Resize(ref table, table.Length + 1); // Resizing the array for the cloned length (+-) (+1)
        table.SetValue(value, table.Length - 1); // Setting the value for the new element
    }
}