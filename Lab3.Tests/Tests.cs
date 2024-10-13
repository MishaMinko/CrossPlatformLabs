namespace Lab3.Tests
{
    public class Tests
    {
        private Main lab = null;
        private Node node = null;

        [SetUp]
        public void Setup()
        {
            lab = new Main();
            node = new Node(1, "DFG");
        }

        //checkString method
        [Test]
        public void checkStringEmpty()
        {
            Assert.IsTrue(lab.checkString(String.Empty));
        }

        [Test]
        public void checkStringLess()
        {
            Assert.IsTrue(lab.checkString(""));
        }

        [Test]
        public void checkStringMore()
        {
            string str = "123456789012345";
            Assert.IsTrue(lab.checkString(str));
        }

        [Test]
        public void checkStringCorrect()
        {
            Assert.IsFalse(lab.checkString("ABCDE"));
        }

        //checkUppercase method
        [Test]
        public void checkUppercaseCorrect()
        {
            Assert.IsFalse(lab.checkUppercase("ABCDE"));
        }

        [Test]
        public void checkUppercaseLowcase()
        {
            Assert.IsTrue(lab.checkUppercase("AbcDE"));
        }

        [Test]
        public void checkUppercaseNumbers()
        {
            Assert.IsTrue(lab.checkUppercase("S22D5254"));
        }

        [Test]
        public void checkUppercaseOtherSymbols()
        {
            Assert.IsTrue(lab.checkUppercase("HDU&VBD*H"));
        }

        //generateSteps method
        [Test]
        public void generateStepsCount()
        {
            Assert.That(lab.generateSteps("AABBCDF").Count() == 5);
        }

        //checkIfFinished method
        [Test]
        public void checkIfFinishedEmpty()
        {
            node.strNow = "";
            Assert.IsTrue(node.checkIfFinished());
        }

        public void checkIfFinishedNotEmpty()
        {
            node.strNow = "ABC";
            Assert.IsFalse(node.checkIfFinished());
        }

        //insertBall method
        [Test]
        public void insertBallTest()
        {
            node.strNow = "AABBCC";
            node.index = 2;
            node.insertBall("W");
            Assert.That(node.strNow.Equals("AAWBBCC"));
        }
    }
}