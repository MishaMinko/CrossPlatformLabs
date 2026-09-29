namespace MFursenko
{
    public class Lab2
    {
        public string[] getDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public bool checkNumber(int k)
        {
            return k < 0 || k > 100;
        }

        public long[] copySequence(long[] t)
        {
            long[] res = new long[t.Length];
            for (int i = 0; i < t.Length; i++)
                res[i] = t[i];
            return res;
        }

        public long[] generateSequence(int k)
        {
            long[] res = { 1, 1 };
            long[] seq = null!;
            int index;

            for (int i = 1; i <= k; i++)
            {
                seq = copySequence(res);
                res = new long[2 * seq.Length - 1];
                index = 1;
                res[0] = seq[0];

                for (int j = 0; j < seq.Length - 1; j++)
                {
                    res[index] = seq[j] + seq[j + 1];
                    index++;
                    res[index] = seq[j + 1];
                    index++;
                }
            }

            return res;
        }

        public long calculateSequence(long[] seq)
        {
            long res = 0;
            for (int i = 0; i < seq.Length; i++)
                res += seq[i];
            return res;
        }

        public void completeFunction(string inputPath, string outputPath)
        {
            int numberOfSteps = 0;

            try
            {
                string[] number = getDataFromFile(inputPath);
                numberOfSteps = Convert.ToInt32(number[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (checkNumber(numberOfSteps))
            {
                Console.WriteLine("The number of steps is less than 0 or higher thab 100.");
                return;
            }

            Console.WriteLine("Number of steps: " + numberOfSteps);

            long[] sequence = generateSequence(numberOfSteps);

            //Console.WriteLine("Sequence:");
            //for (int i = 0; i < sequence.Length; i++)
            //    Console.Write(sequence[i] + " ");
            //Console.WriteLine();

            long res = calculateSequence(sequence);

            File.WriteAllText(outputPath, res.ToString());

            Console.WriteLine("Result is " + res);
            Console.WriteLine($"Lab2 completed. Output saved here: {outputPath}");
        }

        public void Start()
        {
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            string inputPath = Path.Combine(rootDirectory, "input.txt");
            string outputPath = Path.Combine(rootDirectory, "output.txt");
            completeFunction(inputPath, outputPath);
        }

        public void Start(string inputPath, string outputPath)
        {
            completeFunction(inputPath, outputPath);
        }
    }
}
