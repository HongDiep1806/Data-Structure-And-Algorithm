namespace Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var numOfQuestion = reader.NextInt();
            var count = 0;
            while (numOfQuestion > 0)
            {
                var solutions = new int[3];
                var countIn = 0;
                for (int i = 0; i < 3; i++)
                {
                    solutions[i] = reader.NextInt();
                    Boolean check = Check(solutions[i]);
                    if (check == true)
                    {
                        countIn++;
                    }
                }
                if(countIn >= 2)
                {
                    count++;
                }

                numOfQuestion--;
            }
            Console.WriteLine(count);
        }

        public static Boolean Check(int num)
        {
            Boolean check = true;
            if (num == 0)
            {
                return check = false;
            }
            return check;
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
