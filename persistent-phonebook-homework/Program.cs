using PhonebookHomework;

class Program
{
    public static void Main(string[] args)
    {

        // Refactor cases with methods instead

        IPhoneBookFileService service = new PhoneBookFileService();
        PhoneBook phonebook = new PhoneBook(service);

        

        while (true)
        {
            Console.WriteLine("Please enter a command");

            string[] arguments = Console.ReadLine()
                                        .Trim()
                                        .Split(" ");
            try
            {
                switch (arguments[0])
                {
                    case "STORE":
                        Add(phonebook, arguments[1], arguments[2]);
                        break;
                    case "GET":
                        Console.WriteLine($"OK {phonebook.Get(arguments[1])}");
                        break;
                    case "UPDATE":
                        Update(phonebook, arguments[1], arguments[2]);
                        break;
                    case "DEL":
                        Delete(phonebook, arguments[1]);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }

    private static void Delete(PhoneBook phonebook, string toDelete)
    {
        try
        {

            if (long.TryParse(toDelete, out var _))
            {
                phonebook.RemoveByNumber(toDelete);
            }
            else
            {
                phonebook.RemoveByName(toDelete);
            }
            Console.WriteLine($"OK");
        }
        catch
        {
            throw;
        }
    }

    private static void Update(PhoneBook phonebook, string name, string number)
    {
        try
        {
            var previousNumber = phonebook.Get(name);
            phonebook.Update(name, name);
            Console.WriteLine($"OK last no was - {previousNumber}");
        }
        catch
        {
            throw;
        }
    }

    private static void Add(PhoneBook phonebook, string name, string number)
    {
        try
        {
            phonebook.Add(name, number);
            Console.WriteLine("OK");
        }
        catch
        {
            throw;
        }
    }
}