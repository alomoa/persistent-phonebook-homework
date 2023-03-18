using PhonebookHomework;

class Program
{
    public static void Main(string[] args)
    {
        PhoneBook phonebook = new PhoneBook();

        while (true)
        {
            Console.WriteLine("Please enter a command");

            string[] arguments = Console.ReadLine().Trim().Split(" ");
            try
            {


                switch (arguments[0])
                {
                    case "STORE":
                        phonebook.Add(arguments[1], arguments[2]);
                        Console.WriteLine("OK");
                        break;
                    case "GET":
                        Console.WriteLine($"OK {phonebook.Get(arguments[1])}"); 
                        break;
                    case "UPDATE":
                        var previousNumber = phonebook.Get(arguments[1]);
                        phonebook.Update(arguments[1], arguments[2]);
                        Console.WriteLine($"OK last no was - {previousNumber}");
                        break;
                    case "DEL":
                        if (long.TryParse(arguments[1], out var number))
                        {
                            phonebook.RemoveByNumber(arguments[1]);
                        }
                        else
                        {
                            phonebook.RemoveByName(arguments[1]);
                        }
                        Console.WriteLine($"OK");
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
}