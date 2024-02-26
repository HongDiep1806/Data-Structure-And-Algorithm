namespace Domino_piling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var M = reader.NextInt();
            var N = reader.NextInt();
            var result = (M * N) / 2;
            Console.WriteLine(Math.Floor((Decimal)result));
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
