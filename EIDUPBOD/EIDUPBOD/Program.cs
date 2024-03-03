using System.Text;

namespace EIDUPBOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var numOfStudent = reader.NextInt();
            Dictionary<string, Birthday> birthMap = new Dictionary<string, Birthday>();
            for (int i = 0; i < numOfStudent; i++)
            {
                var day = reader.NextInt();
                var month = reader.NextInt();
                var year = reader.NextInt();
                var sb = new StringBuilder();
                if (day < 10)
                {
                    sb.Append($"0");
                }
                sb.Append($"{day}/");
                if (month < 10)
                {
                    sb.Append($"0");
                }
                sb.Append($"{month}/{year}");
                Birthday birthday;
                if (!(birthMap.TryGetValue(sb.ToString(), out birthday)))
                {
                    birthday = new Birthday()
                    {
                        Day = day,
                        Month = month,
                        Year = year,
                        dateOfBirth = sb.ToString()
                    };
                    birthMap[sb.ToString()] = birthday;
                }
                birthday.Count++;
            }
            var birthdayList = new List<Birthday>(birthMap.Values);
            birthdayList = birthdayList
                            .OrderBy(x => x.Year)
                            .ThenBy(x => x.Month)
                            .ThenBy(x => x.Day)
                            .ToList();
            var result = new StringBuilder();
            foreach (var birthday in birthdayList)
            {
                result.Append($"{birthday.dateOfBirth} {birthday.Count} \n");

            }
            Console.WriteLine(result.ToString());
        }
    }

    class Birthday
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public string dateOfBirth { get; set; }
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
