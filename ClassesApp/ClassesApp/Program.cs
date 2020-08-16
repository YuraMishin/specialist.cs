using System;

namespace ClassesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.FirstName = "Yura";
            person.LastName = "Mishin";
            Console.WriteLine($"Hello, {person.FirstName} {person.LastName}!");
        }
    }

    class Person
    {
        string firstName;
        string lastName;

        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
    }
}