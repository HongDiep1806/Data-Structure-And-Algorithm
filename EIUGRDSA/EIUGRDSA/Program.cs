using System.Text;

namespace EIUGRDSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfStudent = reader.NextInt();
            var numOfProblem = reader.NextInt();
            var numOfSubmission = reader.NextInt();
            List<int> problemIDs = new List<int>();
            Dictionary<int, Student> studentMap = new Dictionary<int, Student>();
            while (numOfStudent != 0)
            {
                var studentID = reader.NextInt();
                var student = new Student()
                {
                    ID = studentID
                };
                studentMap.Add(studentID, student);
                numOfStudent--;
            }
            for (int i = 0; i < numOfProblem; i++)
            {
                problemIDs.Add(reader.NextInt());
            }

            while (numOfSubmission != 0)
            {
                var studentID = reader.NextInt();
                var submission = new Submission()
                {
                    Code = reader.NextInt(),
                    Score = reader.NextInt()
                };
                var currentStudent = studentMap[studentID];
                currentStudent.Submissions.Add(submission);
                numOfSubmission--;
            }
            List<Student> students = new List<Student>(studentMap.Values);
            students = students.OrderBy(s => s.ID).ToList();
            var print = new StringBuilder();
            foreach (var student in students)
            {
                print.Append($"{student.ID} {student.GetAVG(numOfProblem, problemIDs)}\n");
            }
            Console.WriteLine(print.ToString());

        }
        class Student
        {
            public int ID { get; set; }
            public List<Submission> Submissions { get; set; } = new List<Submission>();
            public int GetAVG(int numOfProblem, List<int> problemIDs)
            {
                int AVG = 0;
                if (numOfProblem == 0)
                {
                    return 0;
                }
                else
                {
                    foreach (var problemID in problemIDs)
                    {
                        var groupSubmit = Submissions
                            .Where(submit => submit.Code == problemID)
                            .Select(x => x)
                            .OrderByDescending(x => x.Score)
                            .ToList();
                        if (groupSubmit.Any())
                        {
                            var highestScore = groupSubmit.First().Score;
                            AVG += highestScore;
                        }

                    }
                    return AVG / numOfProblem;

                }
            }
        }

        class Submission
        {
            public int Code { get; set; }
            public int Score { get; set; }
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

