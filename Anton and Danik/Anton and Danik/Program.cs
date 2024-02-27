namespace Anton_and_Danik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var numOfGames = reader.NextInt();
            var outCome = reader.Next();
            var countAnton = 0;
            var countDanik = 0;
            for (int i = 0; i < numOfGames; i++)
            {
                if (outCome[i] == 'A')
                {
                    countAnton++;
                }
                else
                {
                    countDanik++;
                }
            }
            if(countAnton > countDanik)
            {
                Console.WriteLine("Anton");
            }
            else
            {
                if(countAnton < countDanik)
                {
                    Console.WriteLine("Danik");
                }
                else
                {
                    Console.WriteLine("Friendship");
                }
            }
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
