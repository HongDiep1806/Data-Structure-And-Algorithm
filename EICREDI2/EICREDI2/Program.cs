using System.Text;

namespace EICREDI2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfStudent = reader.NextInt();
            var print = new StringBuilder();
            while (numOfStudent != 0)
            {
                var name = reader.Next();
                var numOfScore = reader.NextInt();
                var scores = new List<int>();
                for (int i = 0; i < numOfScore; i++)
                {
                    var score = reader.NextInt();
                    if (score >= 50)
                    {
                        scores.Add(score);
                    }
                }
                var student = new Student(name, scores);
                var AVG = student.calculateAVG();
                print.Append($"{student.name} ");
                foreach ( var score in scores)
                {
                    print.Append($"{score} ");
                }
                print.Append($"{AVG}\n");
                numOfStudent--;
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
        public int calculateAVG()
        {
            int AVG = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                AVG += scores[i];
            }
            if(scores.Count() == 0)
            {
                return 0;
            }
            return AVG / scores.Count();
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
