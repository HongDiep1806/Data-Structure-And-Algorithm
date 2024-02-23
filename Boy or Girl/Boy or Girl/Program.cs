namespace Boy_or_Girl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var userName = reader.Next();
            var check = checkGirl(userName);
            if (check == true)
            {
                Console.WriteLine("CHAT WITH HER!");
            }
            else
            {
                Console.WriteLine("IGNORE HIM!");
            }
        }
        public static Boolean checkGirl(String userName)
        {
            if ((userName.Distinct().Count() % 2) != 0)
            {
                return false;
            }
            return true;
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
