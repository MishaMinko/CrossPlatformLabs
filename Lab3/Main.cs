namespace Lab3
{
    public class Main
    {
        public string[] getDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public bool checkUppercase(string data)
        {
            foreach (char i in data)
            {
                if (i < 'A' || i > 'Z')
                {
                    return true;
                }
            }
            return false;
        }


        public void Start()
        {
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            string inputPath = Path.Combine(rootDirectory, "input.txt");
            string outputPath = Path.Combine(rootDirectory, "output.txt");

            string balls = String.Empty;

            try
            {
                string[] data = getDataFromFile(inputPath);
                balls = data[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if(balls.Equals(String.Empty) || balls.Length > 14 || balls.Length < 1)
            {
                Console.WriteLine("You need to enter at least 1 uppercase symbol, maximum of symbols is 14.");
                return;
            }
            if (checkUppercase(balls))
            {
                Console.WriteLine("There only must be uppercase symbols A-Z.");
                return;
            }

            Console.WriteLine("Entered balls: " + balls);

            //long[] sequence = generateSequence(numberOfSteps);

            //Console.WriteLine("Sequence:");
            //for (int i = 0; i < sequence.Length; i++)
            //    Console.Write(sequence[i] + " ");
            //Console.WriteLine();

            //long res = calculateSequence(sequence);

            //File.WriteAllText(outputPath, res.ToString());

            //Console.WriteLine("Result is " + res);
        }
    }
}
