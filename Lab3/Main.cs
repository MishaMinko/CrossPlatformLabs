using System;

namespace Lab3
{
    public class Tree
    {
        public Node main;
        public string startStr;

        public Tree(string str, int index)
        {
            main = null!;
            startStr = str;
            startGenerating(index);
        }

        public void startGenerating(int index)
        {
            if (main == null)
            {
                main = new Node(index);
                main.doOperation(startStr);
            }

            if(main.checkIfFinished())
            {
                deepDive(main.left, 1, main.strNow);
                deepDive(main.right, 1, main.strNow);
            }
        }

        public void deepDive(Node node, int currentDive, string currentStr)
        {

        }
    }
    public class Node
    {
        public int index;
        public string stepDone;
        public string strNow;
        public Node left;
        public Node right;

        public Node(int index)
        {
            this.index = index;
            stepDone = "0";
            strNow = "0";
            left = null!;
            right = null!;
        }

        public void doOperation(string str)
        {
            strNow = str;

            //insertBall(ball);
        }

        public void insertBall(string ball)
        {
            strNow.Insert(index, ball);
        }

        public bool checkIfFinished()
        {
            return strNow.Equals("");
        }
    }

    public class Main
    {
        public string[] getDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public bool checkString(string data)
        {
            return data.Equals(String.Empty) || data.Length > 14 || data.Length < 1;
        }

        public bool checkUppercase(string data)
        {
            foreach (char i in data)
                if (i < 'A' || i > 'Z')
                    return true;
            return false;
        }

        public Tree[] generateSteps(string str)
        {
            Tree[] res = new Tree[str.Length + 1];

            for (int i = 0; i < str.Length + 1; i++)
                res[i] = new Tree(str, i);

            return res;
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

            if(checkString(balls))
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
            Console.WriteLine(balls.Insert(balls.Length, "W"));

            //Tree[] results = generateSteps(balls);

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
