namespace Add_to_Array_Form_of_Integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            var array = new int[] { 1, 3, 0, 1 };
            var k = 34;
            var number = 0;
            number = getNumber(array);
            Console.WriteLine(number+k);
        }
        public static int getNumber(int[] array)
        {
            var numberResult = 0;

            for (int i = 0; i < array.Length; i++)
            {
                var number = 0;
                var times = array.Length - i - 1;
                if (times != 0)
                {
                    var temp = array[i];
                    while (times != 0)
                    {
                        temp = temp * 10;
                        number = temp;
                        times--;
                    }
                    numberResult += number;
                }
                else
                {
                    numberResult += array[i];
                }
            }

            return numberResult;
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
