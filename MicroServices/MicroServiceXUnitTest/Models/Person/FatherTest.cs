using Xunit;
using MicroServices.Models;

namespace MicroServiceXUnitTest.Models.Person
{
    public class FatherTest
    {
        IPerson _father;
        public FatherTest()
        {
            _father = new Father("Richard", "Mike");
        }

        [Fact]
        public void FatherTest_NotNull()
        {
            Assert.NotNull(_father);
        }

        [Fact]
        public void FatherTest_Null()
        {
            Father father = null;
            Assert.Null(father);
        }

        [Fact]
        public void NameTest_Equal()
        {
            Assert.Equal("Richard", _father.GetName());
        }

        [Fact]
        public void NameTest_NotEqual()
        {
            Assert.NotEqual("Mike", _father.GetName());
        }
    }
}
