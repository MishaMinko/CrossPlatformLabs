namespace Lab3
{
    public class Main
    {
        public string[] getDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public void Start()
        {
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            string inputPath = Path.Combine(rootDirectory, "input.txt");
            string outputPath = Path.Combine(rootDirectory, "output.txt");

            //int numberOfSteps = 0;

            //try
            //{
            //    string[] number = getDataFromFile(inputPath);
            //    numberOfSteps = Convert.ToInt32(number[0]);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return;
            //}

            //if (checkNumber(numberOfSteps))
            //{
            //    Console.WriteLine("The number of steps is less than 0 or higher thab 100.");
            //    return;
            //}

            //Console.WriteLine("Number of steps: " + numberOfSteps);

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
