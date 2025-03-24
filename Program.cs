namespace day_1;

class EventHelper
{
    public static event Action<string, int> UserCreated = default!;

    public static void OnUserCreated(string name, int age)
    {
        UserCreated?.Invoke(name, age);
    }
}

class Operation
{
    public static void Start()
    {
        EventHelper.UserCreated += createUser;
    }
    
    public static void createUser(string name, int age)
    {
        Console.WriteLine($"Привет, {name}");
        
        if (age >= 18)
        {
            File.AppendAllText(@"C:\vs code\task_1\userlist", name + " " + age + "\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Operation.Start();

        Console.WriteLine("Введите имя");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine("Введите возраст");
        int age = Convert.ToInt32(Console.ReadLine());

        Func<string, bool> nameCheck = nameSepar;

        if (nameCheck(name))
        {
            Console.WriteLine("User is reg");
            EventHelper.OnUserCreated(name, age);
        }
    }

    public static bool nameSepar(string name) {return name != null;}
}
