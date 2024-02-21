using System.Text;

namespace Way_Too_Long_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            var numOfWord = reader.NextInt();
            StringBuilder result = new StringBuilder();
            while (numOfWord != 0)
            {
                var word = reader.Next();
                if (word.Length > 10)
                {
                    result.Append(AbbWord(word));
                }
                else
                {
                    result.Append(word);
                }

                result.Append("\n");
                numOfWord--;
            }
            Console.Write(result.ToString());
        }
        static StringBuilder AbbWord(string word)
        {
            StringBuilder result = new StringBuilder();
            //  result.Append("");
            char firstChar = word[0];
            char lastChar = word[word.Length - 1];
            int lengthBetween = word.Length - 2;
            result.Append($"{firstChar}{lengthBetween}{lastChar}");
            return result;
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
