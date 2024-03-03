namespace Petya_and_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();   
            var string_1 = reader.Next();
            var string_2 = reader.Next();
            var result = String.Compare(string_1, string_2, StringComparison.OrdinalIgnoreCase);
            if (result < 0)
                Console.WriteLine("-1");
            else if (result > 0)
                Console.WriteLine("1");
            else
                Console.WriteLine("0");
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

