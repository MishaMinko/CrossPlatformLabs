using System;
using System.IO;
using System.Linq;

namespace CrossPlatformLabs.Labs
{
    public class Lab1
    {
        public string[] getNames(string path)
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

        public void Start()
        {
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));
            string inputPath = Path.Combine(rootDirectory, "Labs\\Lab1\\input.txt");
            string outputPath = Path.Combine(rootDirectory, "Labs\\Lab1\\output.txt");

            string[] names = getNames(inputPath);

            if (checkArr(names))
                return;
            if (checkName(names[0]) || checkName(names[1]))
                return;

            Console.WriteLine("Names: " + names[0] + " and " + names[1]);

            string res1 = combineNames(names[0], names[1]);
            string res2 = combineNames(names[1], names[0]);

            string res = chooseAppropriateResult(res1, res2);

            File.WriteAllText(outputPath, res);

            Console.WriteLine("Program succesfully finished");
            Console.WriteLine("Result is " + res);
        }
    }
}
