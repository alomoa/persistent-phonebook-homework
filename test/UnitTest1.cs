using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;
using PhonebookHomework;
namespace test
{
    public class Tests
    {
        private readonly string path = Path.Combine(Environment.CurrentDirectory, "phonebook.txt");
        PhoneBook phoneBook = new PhoneBook();

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown() {
            phoneBook.ClearAll();
        }


        [Test]
        public void AddsEntryToPhoneBook()
        {
            //Arrange
            var name = "dave";
            var number = "07567642122";

            //Test
            phoneBook.Add(name, number);
            var testNumber = phoneBook.Get(name);

            //Assert
            Assert.That(testNumber, Is.EqualTo(number));
        }

        [Test]
        public void AddsEntryToFile()
        {
            //Arrange
            var name = "steve";
            var number = "07823647222";

            //Test
            phoneBook.Add(name, number);
            PhoneBookFileService phoneBookWriter = new PhoneBookFileService();
            Dictionary<string, string> entries = phoneBookWriter.GetEntries();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(entries.ContainsKey(name), Is.True);
                Assert.That(entries[name], Is.EqualTo(number));
                Assert.That(entries.Count(), Is.EqualTo(1));
            });
        }

        [Test]
        public void DoesNotAddNumberOfIncorrectLength()
        {
            //Arrange
            var name = "Alom";
            var incorrectLengthNumber = "0432423123";

            //Assert
            Assert.Throws<IncorrectLengthNumberException>(() => phoneBook.Add(name, incorrectLengthNumber));
        }

        [Test]
        public void DoesNotAddEntryIfOneAlreadyExists()
        {
            //Arrange
            var name = "Henry";
            var number = "07654532561";

            //Test
            phoneBook.Add(name, number);

            //Assert
            Assert.Throws<KeyAlreadyExistsException>(() => phoneBook.Add(name, number));
        }

        [Test]
        public void LoadsDataFromTextFile()
        {
            //Arrange
            var name1 = "Dom";
            var number1 = "07483212343";
            var name2 = "Penny";
            var number2 = "07438454353";

            phoneBook.Add(name1, number1);
            phoneBook.Add(name2, number2);

            //Test
            var phoneBook2 = new PhoneBook();
            var entries = phoneBook2.GetEntries();

            //Assert
            Assert.IsTrue(entries.ContainsKey(name1));
            Assert.IsTrue(entries.ContainsKey(name2));
            Assert.That(number1, Is.EqualTo(entries[name1]));
            Assert.That(number2, Is.EqualTo(entries[name2]));
        }

        [Test]
        public void DeletesEntryFromPhoneBookByName()
        {
            //Arrange
            var name = "Lenny";
            var number = "07856647222";

            //Test
            phoneBook.Add(name, number);
            phoneBook.RemoveByName(name);

            //Assert
            Assert.Throws<KeyNotFoundException>(() => phoneBook.Get(name));

        }

        [Test]
        public void DeletesEntryFromPhoneBookByNumber()
        {
            //Arrange
            var name = "Lenny";
            var number = "07856647222";

            //Test
            phoneBook.Add(name, number);
            phoneBook.RemoveByNumber(number);

            //Assert
            Assert.Throws<KeyNotFoundException>(() => phoneBook.Get(name));
        }

        [Test]
        public void DeletesEntryFromFile()
        {
            //Arrange
            var name = "Lenny";
            var number = "07856647222";

            //Test
            phoneBook.Add(name, number);
            phoneBook.RemoveByName(name);
            PhoneBookFileService fileService = new PhoneBookFileService();
            var entries = fileService.GetEntries();
            

            //Assert
            Assert.IsFalse(entries.ContainsKey(name));
        }

        [Test]
        public void GetsPhonebookEntry()
        {
            //Arrange
            var name = "Lenny";
            var number = "07856647222";

            //Test
            phoneBook.Add(name, number);
            
            //Assert
            Assert.That(phoneBook.Get(name), Is.EqualTo(number));
        }

        [Test]
        public void UpdatesPhonebookEntryWithNewNumber()
        {
            //Arrange
            var name = "Lenny";
            var number = "07856647222";
            var newNumber = "07634253642";

            //Test
            phoneBook.Add(name, number);
            phoneBook.Update(name, newNumber);

            //Assert
            Assert.That(phoneBook.Get(name), Is.EqualTo(newNumber));
        }


    }
}


// Look into serialisation