using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LINQ
{
    internal class Program
    {
        // DIEP
        static void Main(string[] args)
        {
            var reader = new Reader();
            // var categoryReport = reader.Next();
            // int priceStart = reader.NextInt();
            //int priceEnd = reader.NextInt();
            var product1 = new Product()
            {
                ID = "001",
                Name = "cactus Pot",
                Price = 20,
                Category = "PlantVase",
                Quantity = 10,
            };
            var product2 = new Product()
            {
                ID = "002",
                Name = "rose pot",
                Price = 25,
                Category = "PlantVase",
                Quantity = 5,
            };
            var product3 = new Product()
            {
                ID = "003",
                Name = "lamp",
                Price = 20,
                Category = "DomesticThing",
                Quantity = 5,

            };
            var product4 = new Product()
            {
                ID = "004",
                Name = "daisy pot",
                Price = 25,
                Category = "PlantVase",
                Quantity = 10,
            };
            var product5 = new Product()
            {
                ID = "005",
                Name = "fan",
                Price = 40,
                Category = "DomesticThing",
                Quantity = 5,
            };
            List<Product> productList = new List<Product>();
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            var print = new StringBuilder();
            var reportList = ReportedQuantity(productList);
            foreach (var report in reportList)
            {
                print.Append($"{report.Category} - {report.RemainQuantity}\n");
            }
            Console.WriteLine(print);

        }

        public static List<Report> ReportedQuantity(List<Product> productList)
        {
            var result = productList
             .GroupBy(x => x.Category)
             .Select(x => new Report()
             {
                 Category = x.Key,
                 RemainQuantity = x.Sum(x => x.Quantity)
             })
             .ToList();
            return result;
        }

        public static List<Product> searchByPriceAndName(int priceStart, int priceEnd, List<Product> productList, string name)
        {
            var resultList = productList
                .Where(x => x.Price >= priceStart && x.Price <= priceEnd)
                .Where(x => (x.Name.ToLower()).Contains(name.ToLower()))
                .Select(x => x)
                .ToList();
            return resultList;

        }

        public static List<Product> searchByPriceRange(int priceStart, int priceEnd, List<Product> productList)
        {
            var resultList = productList
                .Where(x => x.Price >= priceStart && x.Price <= priceEnd)
                .Select(x => x)
                .ToList();
            return resultList;
        }
        public static void GroupedByAgeAndAddress()
        {
            var person1 = new Person()
            {
                Name = "An",
                Age = 1,
                Money = 1,
                Adrress = "An Giang"
            };
            var person2 = new Person()
            {
                Name = "Tan",
                Age = 33,
                Money = 2,
                Adrress = "Soc Trang"
            };
            var person3 = new Person()
            {
                Name = "Binh",
                Age = 33,
                Money = 3,
                Adrress = "Binh Duong"
            };
            var person4 = new Person()
            {
                Name = "Ngoc",
                Age = 33,
                Money = 3,
                Adrress = "Binh Duong"
            };
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var groupedPeopleByAgeAndAddress = people
                .GroupBy(person => new { person.Age, person.Adrress })
                .ToList();
            foreach (var group in groupedPeopleByAgeAndAddress)
            {
                Console.WriteLine($"Group Age: {group.Key.Age} And Address: {group.Key.Adrress}");
                foreach (var person in group)
                {
                    Console.WriteLine($"{person.Name} {person.Age} {person.Adrress}");
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

        public static Boolean IsExistedAge(int age, List<Person> people) // bool vs Boolean
        {
            return people
                .Exists(person => person.Age == age);// Any
        }

        public static List<Person> OrderByDescendingAgeThenName(List<Person> people)
        {
            return people
                .OrderByDescending(person => person.Age)
                .OrderBy(person => person.Name)
                .OrderBy(person => person.Money)
                .ToList();
        }

        public class Report
        {
            public string Category { get; set; }
            public int RemainQuantity { get; set; }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Money { get; set; }
            public DateTime DOB { get; set; }
            public string Adrress { get; set; }
        }
        public class Product
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }
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
