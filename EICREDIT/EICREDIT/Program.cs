using System.Text;

namespace EICREDIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfTestCase = reader.NextInt();
            var print = new StringBuilder();
            while (numOfTestCase != 0)
            {
                var name = reader.Next();
                var numOfCourse = reader.NextInt();
                var scores = new List<int>();
                for (int i = 0; i < numOfCourse; i++)
                {
                    scores.Add(reader.NextInt());
                }
                var student = new Student()
                {
                    Name = name,
                    NumOfCourse = numOfCourse,
                    scores = scores,
                };
                var credit = student.GetCredit();
                print.Append($"{student.Name} {credit}\n");
                numOfTestCase--;
            }
            Console.WriteLine(print);
        }

    }
    public class Student
    {
        public string Name { get; set; }
        public int NumOfCourse { get; set; }
        public List<int> scores { get; set; }
        public int GetCredit()
        {
            var credit = 0;
            for (int i = 0; i < this.scores.Count; i++)
            {
                credit = scores.Count(x => x >= 50) * 4;
            }
            return credit;
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
