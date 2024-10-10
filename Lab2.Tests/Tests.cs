namespace Lab2.Tests
{
    public class Tests
    {
        private Main lab = null!;

        [SetUp]
        public void Setup()
        {
            lab = new Main();
        }

        //checkNumber method
        [Test]
        public void checkNumberCorrect()
        {
            int num = 50;
            Assert.IsFalse(lab.checkNumber(num));
        }

        [Test]
        public void checkNumberBig()
        {
            int num = 101;
            Assert.IsTrue(lab.checkNumber(num));
        }

        [Test]
        public void checkNumberSmall()
        {
            int num = -1;
            Assert.IsTrue(lab.checkNumber(num));
        }

        //calculateSequence method
        [Test]
        public void calculateSequenceTest()
        {
            long[] seq = { 2, 5, 3, 2 };
            Assert.That(lab.calculateSequence(seq), Is.EqualTo(12));
        }

        //copySequence method
        [Test]
        public void copySequenceTest()
        {
            long[] seq = { 2, 5, 3, 2 };
            var copy = lab.copySequence(seq);
            Assert.That(copy, Is.EqualTo(seq));
        }

        //generateSequence method
        [Test]
        public void generateSequenceStepZero()
        {
            Assert.That(lab.generateSequence(0), Is.EqualTo(new long[] { 1, 1 }));
        }

        [Test]
        public void generateSequenceStepOne()
        {
            Assert.That(lab.generateSequence(1), Is.EqualTo(new long[] { 1, 2, 1 }));
        }

        [Test]
        public void generateSequenceStepTwo()
        {
            Assert.That(lab.generateSequence(2), Is.EqualTo(new long[] { 1, 3, 2, 3, 1 }));
        }

        [Test]
        public void generateSequenceStepThree()
        {
            Assert.That(lab.generateSequence(3), Is.EqualTo(new long[] { 1, 4, 3, 5, 2, 5, 3, 4, 1 }));
        }
    }
}