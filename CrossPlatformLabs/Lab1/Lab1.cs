using System;
using System.IO;
using System.Linq;

namespace CrossPlatformLabs.LabOne
{
    public class Lab1
    {
        string[] getNames(string path)
        {
            return File.ReadAllLines(path);
        }

        string cutName(string name, int untilIndex)
        {
            string res = "";
            for (int i = 0; i < untilIndex; i++)
                res += name.ElementAt(i);
            return res;
        }

        string combineNames(string name1, string name2)
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

        bool checkArr(string[] arr)
        {
            if (arr == null || arr.Length != 2)
                return true;
            return false;
        }

        bool checkName(string name)
        {
            if (name.Length < 2 || name.Length > 999)
                return true;
            return false;
        }

        public void Start()
        {
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));
            string inputPath = Path.Combine(rootDirectory, "Lab1\\input.txt");
            string outputPath = Path.Combine(rootDirectory, "Lab1\\output.txt");

            string[] names = getNames(inputPath);

            if (checkArr(names))
                return;
            if (checkName(names[0]) || checkName(names[1]))
                return;

            string res1 = combineNames(names[0], names[1]);
            string res2 = combineNames(names[1], names[0]);

            string res = res1.Length < res2.Length ? res1 : res2;

            File.WriteAllText(outputPath, res);

            Console.WriteLine("Program succesfully finished");
            Console.ReadKey();
        }
    }
}
