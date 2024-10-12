namespace Lab3.Tests
{
    public class Tests
    {
        private Main lab = null;

        [SetUp]
        public void Setup()
        {
            lab = new Main();
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
    }
}