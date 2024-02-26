using System.Security.Cryptography.X509Certificates;

namespace LINQ
{
    internal class Program
    {
        // DIEP
        static void Main(string[] args)
        {
            var person1 = new Person()
            {
                Name = "An",
                Age = 1,
                Adrress = "VN"
            };
            var person2 = new Person()
            {
                Name = "Tan",
                Age = 33,
                Adrress = "VN"
            };
            var person3 = new Person()
            {
                Name = "Binh",
                Age = 33,
                Adrress = "VN"
            };
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var groupedPeopleByAge = GroupedPeopleByAge(people);
            foreach (var group in groupedPeopleByAge)
            {
                Console.WriteLine($"Group Age: {group[0].Age}");

                foreach (var person in group)
                {
                    Console.Write($"{person.Name} {person.Age}\n");
                }
            }
        }

        public static List<List<Person>> GroupedPeopleByAge(List<Person> people)
        {
            return people
                 .GroupBy(x => x.Age)
                 .Select(group => group.ToList())
                 .ToList();

        }

        public static Boolean IsExistedAge(int age, List<Person> people)
        {
            return people
                .Exists(person => person.Age == age);

        }
        public static List<Person> OrderByDescendingAgeThenName(List<Person> people)
        {
            return people
                .OrderByDescending(person => person.Age)
                .ThenBy(person => person.Name)
                .ToList();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime DOB { get; set; }
            public string Adrress { get; set; }
        }
        class Reader
        {
            private int index = 0;
            private string[] tokens;
            public string Next()
            {
                while (tokens == null || tokens.Length <= index)
                {
                    tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    index = 0;
                }
                return tokens[index++];
            }
            public int NextInt()
            {
                return int.Parse(Next());
            }

            public double NextDouble()
            {
                return double.Parse(Next());
            }
        }
    }
}
