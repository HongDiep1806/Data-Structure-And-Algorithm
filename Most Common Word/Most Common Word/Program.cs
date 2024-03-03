using System.Text.RegularExpressions;

namespace Most_Common_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            HashSet<string> bannedWord = new HashSet<string>(banned);
            paragraph = Regex.Replace(paragraph, @"[^a-zA-Z]+", " ").ToLower();
            // replace all char that's not a-z or A-Z to "space"

            var wordCount = new Dictionary<string, int>();//similar to hashmap
            foreach (string word in paragraph.Split())
            {
                if (bannedWord.Contains(word))
                {
                    continue;
                }
                else
                {
                    if(!wordCount.ContainsKey(word))
                    {
                        wordCount.Add(word, 0);
                    }
                    else
                    {
                        wordCount[word]++;
                    }
                }
            }
            var print = "";
            foreach (var word in wordCount) {
                if(print.Equals("") || word.Value > wordCount[print])//compare times of appear
                {
                    print = word.Key;
                }
            }
            Console.WriteLine(print);
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
