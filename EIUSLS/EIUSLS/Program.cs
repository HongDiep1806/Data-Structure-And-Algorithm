using System.Text;

namespace EIUSLS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfStudent = reader.NextInt();
            List<Student> studentList = new List<Student>();
            while (numOfStudent != 0)
            {
                var name = reader.Next();
                var numOfSubject = reader.NextInt();
                var scores = new List<int>();
                for (int i = 0; i < numOfSubject; i++)
                {
                    scores.Add(reader.NextInt());
                }
                var student = new Student(name, scores);
                studentList.Add(student);
                numOfStudent--;
            }
            var orderdList = studentList
                .OrderByDescending(x => x.calculateGPA())
                .ToList();
            var count = 2;
            var print = new StringBuilder();
            foreach ( var student in orderdList)
            {
                if(count == 0)
                {
                    break;
                }
                print.Append($"{student.name}\n");
                count--;
            }
            Console.WriteLine(print);
        }
    }

    class Student
    {
        public string name { get; set; }
        public List<int> scores { get; set; }
        public Student(string name, List<int> scores)
        {
            this.name = name;
            this.scores = scores;
        }
        public double calculateGPA()
        {
            double GPA = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                GPA += scores[i];
            }
            if (scores.Count == 0)
            {
                return 0;
            }
            return GPA / scores.Count;
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
