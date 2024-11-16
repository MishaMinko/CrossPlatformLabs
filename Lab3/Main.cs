namespace Lab3
{
    public class Tree
    {
        public Node main;
        public string startStr;
        public int index;
        public int minSteps;

        public Tree(string str, int index)
        {
            main = null!;
            startStr = str;
            this.index = index;
            minSteps = 11;
        }

        public void startGenerating()
        {
            if (main == null)
            {
                main = new Node(index, startStr);
                main.doOperation();
            }

            if(!main.checkIfFinished())
                foreach (Node child in main.children)
                    deepDive(child, 1);
        }

        public void deepDive(Node node, int currentDive)
        {
            if(currentDive < minSteps)
            {
                node.doOperation();

                if (!node.checkIfFinished())
                    foreach (Node child in node.children)
                        deepDive(child, currentDive + 1);
                else
                    minSteps = currentDive;
            }
        }
    }
    public class Node
    {
        public int index;
        public string stepDone;
        public string strNow;
        public Node[] children;

        public Node(int index, string strStart)
        {
            this.index = index;
            stepDone = "0";
            children = null!;
            strNow = strStart;
        }

        public void doOperation()
        {
            char ballToInsert = chooseBall();
            insertBall(ballToInsert.ToString());

            removeBalls(ballToInsert);

            stepDone = ballToInsert.ToString() + index.ToString();

            if(!checkIfFinished())
            {
                int required = 1;
                for (int i = 1; i < strNow.Length; i++)
                    if (!strNow.ElementAt(i).Equals(strNow.ElementAt(i - 1)))
                        required++;

                children = new Node[required];
                children[0] = new Node(0, strNow);
                required = 1;
                for (int i = 1; i < strNow.Length; i++)
                {
                    if (!strNow.ElementAt(i).Equals(strNow.ElementAt(i - 1)))
                    {
                        children[required] = new Node(i, strNow);
                        required++;
                    }
                }
            }
        }

        public void removeBalls(char insertedBall)
        {
            int startIndex = index;

            while (startIndex > 0 && strNow.ElementAt(startIndex - 1).Equals(insertedBall))
                startIndex--;
            int endIndex = index;
            while (endIndex < strNow.Length && strNow.ElementAt(endIndex).Equals(insertedBall))
                endIndex++;

            int countToDelete = endIndex - startIndex;

            if (countToDelete > 2)
            {
                strNow = strNow.Remove(startIndex, countToDelete);

                if (strNow.Length > 0 && endIndex < strNow.Length - 1 + countToDelete && startIndex > 0)
                {
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
            int required = 1;
            for (int i = 1; i < str.Length; i++)
                if (!str.ElementAt(i).Equals(str.ElementAt(i - 1)))
                    required++;

            Tree[] res = new Tree[required];
            res[0] = new Tree(str, 0);
            required = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (!str.ElementAt(i).Equals(str.ElementAt(i - 1)))
                {
                    res[required] = new Tree(str, i);
                    required++;
                }
            }

            foreach (Tree tree in res)
                tree.startGenerating();

            return res;
        }

        private List<string> collectSteps(Node node)
        {
            List<string> steps = new List<string>();

            if (node != null)
            {
                steps.Add(node.stepDone);

                if (node.children != null && node.children.Length > 0)
                {
                    List<string> bestChildSteps = null!;
                    int minSteps = 11;

                    foreach (Node child in node.children)
                    {
                        List<string> childSteps = collectSteps(child);

                        if (childSteps.Count < minSteps)
                        {
                            minSteps = childSteps.Count;
                            bestChildSteps = childSteps;
                        }
                    }

                    if (bestChildSteps != null)
                        steps.AddRange(bestChildSteps);
                }
            }

            return steps;
        }

        public string calculateBestSolution(Tree[] trees)
        {
            int minSteps = 11;
            List<string> bestSteps = null!;

            foreach (Tree tree in trees)
            {
                List<string> steps = collectSteps(tree.main);

                if (steps.Count < minSteps)
                {
                    minSteps = steps.Count;
                    bestSteps = steps;
                }
            }

            if (bestSteps == null)
                return "";

            string res = minSteps.ToString();
            foreach (string step in bestSteps)
                res += " " + step;

            return res;
        }

        public void completeFunction(string inputPath, string outputPath)
        {
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

            if (checkString(balls))
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

            Tree[] trees = generateSteps(balls);

            string res = calculateBestSolution(trees);

            File.WriteAllText(outputPath, res.ToString());

            Console.WriteLine("Result is " + res);
            Console.WriteLine($"Lab3 completed. Output saved here: {outputPath}");
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
