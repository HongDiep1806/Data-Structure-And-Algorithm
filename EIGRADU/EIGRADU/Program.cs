using System.Text;

namespace EIGRADU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfStudent = reader.NextInt();
            var creditPass = reader.NextInt();
            var studentList = new List<Student>();
            while (numOfStudent != 0)
            {
                var ID = reader.NextInt();
                var name = reader.Next();
                var numOfSubject = reader.NextInt();
                var scores = new List<int>();
                var credit = 0;
                for (int i = 0; i < numOfSubject; i++)
                {
                    var score = reader.NextInt();
                    if (score >= 50)
                    {
                        credit += 4;
                    }
                    scores.Add(score);
                }
                var GPA = calculateGPA(credit, scores);
                var student = new Student(ID, name, scores, credit, GPA);
                studentList.Add(student);
                numOfStudent--;
            }
            var orderedList = studentList.OrderByDescending(x => Math.Floor(x.GPA)).ThenBy(x => x.ID).ToList();
            var print = new StringBuilder();
            foreach (var student in orderedList)
            {
                if (student.credits >= creditPass)
                {
                    print.Append($"{student.ID} {student.name} {Math.Floor(student.GPA)}\n");
                }
            }
            Console.WriteLine(print);
        }
        public static double calculateGPA(int credits, List<int> scores)
        {
            var GPA = scores.Where(x => x >= 50).Sum(x => x * 4);
            if (credits == 0)
            {
                return 0;
            }
            return (GPA / credits);
        }
    }

    class Student
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<int> scores { get; set; }
        public int credits { get; set; }
        public double GPA { get; set; }
        public Student(int ID, string name, List<int> scores, int credits, double GPA)
        {
            this.ID = ID;
            this.name = name;
            this.scores = scores;
            this.credits = credits;
            this.GPA = GPA;
        }
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
