namespace Stones_on_the_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var numOfStone = reader.NextInt();
            var colors = new string[numOfStone];
            //get input
            for (int i = 0; i < numOfStone; i++)
            {
                colors[i] = reader.Next();
            }
            //
            var count = 0;
            for (int i = 0; i < numOfStone; i++)
            {
                for (int j = i; j < numOfStone-1; j++)
                {
                    bool checkDuplicate = check(colors[i], colors[j]);
                    if(checkDuplicate == true)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }

        public static Boolean check(string s1, string s2)
        {
            bool check = false;
            if (s1.Equals(s2))
            {
                check = true;
                return check;
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
