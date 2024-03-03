namespace Soldier_and_Bananas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();   
            var priceOfFirstBanana = reader.NextInt();
            var moneyHave = reader.NextInt();
            var numOfBanana = reader.NextInt();
            var moneyNeed = 0;
            for (int i = 1; i <= numOfBanana; i++)
            {
                moneyNeed += priceOfFirstBanana * i;
            }
            var moneyBorrow = 0;
            if(moneyNeed - moneyHave <= 0)
            {
                moneyBorrow = 0;
            }
            else
            {
                moneyBorrow = moneyNeed - moneyHave;
            }
            Console.WriteLine(moneyBorrow);
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
