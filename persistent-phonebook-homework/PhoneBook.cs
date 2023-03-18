namespace PhonebookHomework
{
    public class PhoneBook
    {
        private Dictionary<String, String> Entries;
        private PhoneBookFileService phoneBookService;

        public PhoneBook()
        {
            phoneBookService = new PhoneBookFileService();
            Entries = phoneBookService.GetEntries();
        }

        public void Add(String name, String number)
        {
            if (Entries.ContainsKey(name))
            {
                throw new KeyAlreadyExistsException($"{name} already exists in the phonebook");
            }
            if(number.Length == 11)
            {
                Entries[name] = number;
                phoneBookService.Write(name, number);
            }
            else
            {
                throw new IncorrectLengthNumberException("The length of the number provided is incorrect ");
            }
            
        }

        public string Get(string name)
        {
            if (Entries.ContainsKey(name))
            {
                return Entries[name];
            }
            else
            {
                throw new KeyNotFoundException($"{name} name does not exist");
            }
        }

        public void RemoveByName(string name)
        {
            if (Entries.ContainsKey(name))
            {
                Entries.Remove(name);
                phoneBookService.Update(Entries);
            }
            else { 
                throw new KeyNotFoundException($"{name} does not exist in the phonebook");
            }
        }

        public Dictionary<string, string>  GetEntries()
        {
            return Entries;
        }

        public void RemoveByNumber(string number)
        {
            var keys = Entries.Keys;
            
            foreach(var key in keys)
            {
                if (Entries[key] == number)
                {
                    Entries.Remove(key);
                    phoneBookService.Update(Entries);
                    return;
                }
            }

            throw new KeyNotFoundException($"{number} does not exist in phonebook");
        }

        public void Update(string name, string newNumber)
        {
            if (Entries.ContainsKey(name))
            {
                Entries[name] = newNumber;
            }
        }

        public void ClearAll()
        {
            Entries = new Dictionary<string, string>();
            phoneBookService.Update(Entries);
        }
    }
}


// Look into serialisation