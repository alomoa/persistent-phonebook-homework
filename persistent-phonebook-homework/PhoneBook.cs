namespace PhonebookHomework
{
    public class PhoneBook
    {
        //Fields should be lowecase instead

        private Dictionary<string, string> _entries;
        private readonly IPhoneBookFileService phoneBookService;

        public PhoneBook(IPhoneBookFileService service)
        {
            phoneBookService = service;
            _entries = phoneBookService.GetEntries();
        }

        public void Add(string name, string number)
        {
            if (number.Length == 11)
            {
                //entries.add instead
                _entries.Add(name, number);
                phoneBookService.Write(_entries);
            }
            else
            {
                //Can be an argument exception instead
                throw new ArgumentException("The length of the number provided is incorrect");
            }

        }

        public string Get(string name)
        {
            if (_entries.ContainsKey(name))
            {
                return _entries[name];
            }
            else
            {
                throw new ArgumentException($"{name} name does not exist");
            }
        }

        public void RemoveByName(string name)
        {
            if (_entries.ContainsKey(name))
            {
                _entries.Remove(name);
                phoneBookService.Write(_entries);
            }
            else
            {
                throw new ArgumentException($"{name} does not exist in the phonebook");
            }
        }

        public Dictionary<string, string> GetEntries()
        {
            return _entries;
        }

        public void RemoveByNumber(string number)
        {
            var keys = _entries.Keys;
            var deleteSuccess = false;
            foreach (var key in keys)
            {
                if (_entries[key] == number)
                {
                    _entries.Remove(key);
                    phoneBookService.Write(_entries);
                    deleteSuccess = true;
                    break;
                }
            }
            if (!deleteSuccess)
            {
                throw new ArgumentException($"{number} does not exist in phonebook");
            }
        }

        public void Update(string name, string newNumber)
        {
            if (_entries.ContainsKey(name))
            {
                _entries[name] = newNumber;
            }
        }

        public void Clear()
        {
            _entries = new Dictionary<string, string>();
            phoneBookService.Clear();
        }
    }
}


// Look into serialisation