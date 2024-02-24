namespace Stones_on_the_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            int n = int.Parse(reader.Next());
            string s = reader.Next();

            int count = 0;

            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    count++;
                }
            }

            Console.WriteLine(count);

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
