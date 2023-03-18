namespace PhonebookHomework
{
    public class PhoneBookFileService
    {
        private readonly string path = Path.Combine(Environment.CurrentDirectory, "phonebook.txt");
        public PhoneBookFileService()
        {
            
        }

        public void Write(string name, String number)
        {
            var entry = $"{name} {number}";
            

            using (StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory, this.path)))
            {
                sw.WriteLine(entry);
            }

        }

        public Dictionary<string, string> GetEntries()
        {
            try
            {
                var entries = File.ReadAllLines(path);
                Dictionary<string, string> entriesDict = new Dictionary<string, string>();

                foreach (var entry in entries)
                {
                    var split = entry.Split(" ");
                    entriesDict.Add(split[0], split[1]);
                }

                return entriesDict;
            }
            catch {
                return new Dictionary<string, string>();
            }

        }

        public void Update(Dictionary<string, string> entries)
        {
            File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, this.path), entries.Select(entry => $"{entry.Key} {entry.Value}").ToArray());      
        }
    }
}


// Look into serialisation