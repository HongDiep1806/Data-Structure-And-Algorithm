namespace Next_Round
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var numOfContestant = reader.NextInt();
            var k = reader.NextInt();
            var scores = new int[numOfContestant];
            //get input
            for (int i = 0; i < numOfContestant; i++)
            {
                scores[i] = reader.NextInt();
            }

            var result = count(scores, k);
            Console.WriteLine(result);

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
        public static int count(int[] scores, int k)
        {
            var count = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > 0 && scores[i] >= scores[k - 1])
                {
                    count++;
                }
            }

            return count;
        }
    }
    
}
