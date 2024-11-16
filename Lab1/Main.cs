namespace Lab1
{
    public class Main
    {
        public string[] getDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public string cutName(string name, int untilIndex)
        {
            string res = "";
            for (int i = 0; i < untilIndex; i++)
                res += name.ElementAt(i);
            return res;
        }

        public bool checkArr(string[] arr)
        {
            return arr == null || arr.Length != 2;
        }

        public bool checkName(string name)
        {
            return name.Length < 2 || name.Length > 999;
        }

        public string combineNames(string name1, string name2)
        {
            char[] charName1 = name1.ToLower().ToCharArray();
            char[] charName2 = name2.ToLower().ToCharArray();
            int startIndex = 0;
            int currentIndex = 0;

            for (int i = 0; i < charName1.Length; i++)
            {
                if (charName1[i].Equals(charName2[currentIndex]))
                    currentIndex++;
                else
                {
                    startIndex = i + 1;
                    currentIndex = 0;
                }

            }

            if (currentIndex == 0)
                return name1 + name2;
            else
                return cutName(name1, startIndex) + name2;
        }

        public string chooseAppropriateResult(string res1, string res2)
        {
            return res1.Length < res2.Length ? res1 : res2;
        }

        public void completeFunction(string inputPath, string outputPath)
        {
            string[] names = null!;

            try
            {
                names = getDataFromFile(inputPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (checkArr(names))
            {
                Console.WriteLine("There are no names in file 'input.txt'. Enter two names, please.");
                return;
            }
            if (checkName(names[0]) || checkName(names[1]))
            {
                Console.WriteLine("Length of names must be more than 1 and less than 1000");
                return;
            }

            Console.WriteLine("Names: " + names[0] + " and " + names[1]);

            string res1 = combineNames(names[0], names[1]);
            string res2 = combineNames(names[1], names[0]);

            string res = chooseAppropriateResult(res1, res2);

            File.WriteAllText(outputPath, res);

            Console.WriteLine("Result is " + res);
            Console.WriteLine($"Lab1 completed. Output saved here: {outputPath}");
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
