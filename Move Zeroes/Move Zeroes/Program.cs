using System.Collections;

namespace Move_Zeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var array = new int[] { 0, 1, 0, 3, 12, 0, 5, 6, 7 };
            var count = 0;
            var arrayList = new ArrayList();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    arrayList.Add(array[i]);
                }
                else
                {
                    count++;
                }
            }
            for (int i = 0; i < count; i++)
            {
                arrayList.Add(0);
            }
            var arrayResult = arrayList.ToArray();
            for (int i = 0; i < arrayResult.Length; i++)
            {
                Console.Write(arrayResult[i] + " ");
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
