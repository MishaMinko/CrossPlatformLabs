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

            if(!main.checkIfFinished())
                foreach (Node child in main.children)
                    deepDive(child, 1, main.strNow);
        }

        public void deepDive(Node node, int currentDive, string currentStr)
        {
            if(currentDive < 11)
            {
                node.doOperation(currentStr);

                if(!node.checkIfFinished())
                    foreach(Node child in node.children)
                        deepDive(child, currentDive + 1, currentStr);
            }
        }
    }
    public class Node
    {
        public int index;
        public string stepDone;
        public string strNow;
        public Node[] children;

        public Node(int index)
        {
            this.index = index;
            stepDone = "0";
            strNow = "0";
            children = null!;
        }

        public void doOperation(string str)
        {
            strNow = str;

            char ballToInsert = chooseBall();
            insertBall(ballToInsert.ToString());

            removeBalls(ballToInsert);

            stepDone = ballToInsert.ToString() + index.ToString();

            if(!checkIfFinished())
            {
                children = new Node[strNow.Length];
                for(int i = 0; i < children.Length; i++)
                    children[i] = new Node(i);
            }
        }

        public void removeBalls(char insertedBall)
        {
            int startIndex = index;

            while (startIndex > 0 && strNow.ElementAt(startIndex - 1).Equals(insertedBall))
                startIndex--;
            int endIndex = index;
            while (endIndex < strNow.Length - 1 && strNow.ElementAt(endIndex + 1).Equals(insertedBall))
                endIndex++;

            int countToDelete = endIndex - startIndex;
            if (startIndex != 0)
                countToDelete++;
            if (countToDelete > 2)
            {
                strNow = strNow.Remove(startIndex, countToDelete);

                if (strNow.Length > 0 && endIndex < strNow.Length - 1 + countToDelete)
                {
                    startIndex = strNow.Length - 1;

                    if (startIndex > 0)
                    {
                        if (strNow.ElementAt(startIndex).Equals(strNow.ElementAt(startIndex - 1)))
                        {
                            index = startIndex;
                            removeBalls(strNow.ElementAt(index));
                        }
                    }
                    else if (startIndex + 1 < strNow.Length)
                        if (strNow.ElementAt(startIndex).Equals(strNow.ElementAt(startIndex + 1)))
                        {
                            index = startIndex;
                            removeBalls(strNow.ElementAt(index));
                        }
                }
            }   
        }

        public char chooseBall()
        {
            if(index == 0)
                return strNow.ElementAt(0);
            else if (index == strNow.Length)
                return strNow.ElementAt(strNow.Length - 1);
            else
            {
                char left = strNow.ElementAt(index - 1);
                char right = strNow.ElementAt(index);

                if (!left.Equals(right))
                {
                    int currentIndex = index - 2;
                    int leftCount = 1;
                    int rightCount = 1;
                    while (currentIndex > 1 && strNow.ElementAt(currentIndex).Equals(left))
                    {
                        leftCount++;
                        currentIndex--;
                    }
                    currentIndex = index + 1;
                    if (currentIndex < strNow.Length && strNow.ElementAt(currentIndex).Equals(right))
                    {
                        rightCount++;
                        currentIndex++;
                    }

                    if (leftCount >= rightCount)
                        return left;
                    else
                        return right;
                }
                else
                    return left;
            }
        }

        public void insertBall(string ball)
        {
            strNow = strNow.Insert(index, ball);
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

            Console.WriteLine(balls.Insert(0, "W"));
            Console.WriteLine(balls.Insert(1, "W"));
            Console.WriteLine(balls.Insert(2, "W"));
            Console.WriteLine(balls.Insert(balls.Length, "W"));

            new Node(1).doOperation(balls);

            Tree[] res = generateSteps(balls);
            Console.WriteLine("RES DONE\t\t" + res.Length);


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
