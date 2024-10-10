
namespace NewDay.DiamondGenerator.Tests
{
    public class Tests
    { 
        [Test]
        public async Task Test_DiamondForInvalidCharacter()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var exception = Assert.ThrowsAsync<ArgumentException>(() => designGenerator.Create('5'));            
        }

        [Test]
        public async Task Test_DiamondForEmptyCharacter()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var exception = Assert.ThrowsAsync<ArgumentException>(() => designGenerator.Create(' '));
        }

        [Test]
        public async Task Test_DiamondForLowerCharacter()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var exception = Assert.ThrowsAsync<ArgumentException>(() => designGenerator.Create('a'));
        }

        [Test]
        public async Task Test_DiamondForCharacterA()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var expected = "A";
            var result = await designGenerator.Create('A');
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task Test_DiamondForCharacterB()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var expected =    " A" +
                              "B B" +                                                            
                              " A";

            var result = await designGenerator.Create('B');
            Assert.AreEqual(expected, result);
        }
        [Test]
        public async Task Test_DiamondForCharacterC()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var expected =    "  A" +
                              " B B" +
                              "C   C" +
                              " B B" +
                              "  A";

            var result = await designGenerator.Create('C');
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task Test_DiamondForCharacterE()
        {
            IDesignGenerator designGenerator = new CreateDiamond();
            var expected     ="    A" +
                              "   B B" +
                              "  C   C" +
                              " D     D" +
                              "E       E" +
                              " D     D" +
                              "  C   C" +
                              "   B B" +
                              "    A";

            var result = await designGenerator.Create('E');
            Assert.AreEqual(expected, result);
        }        
    }
}