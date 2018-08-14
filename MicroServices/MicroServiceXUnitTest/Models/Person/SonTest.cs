using MicroServices.Models;
using Xunit;

namespace MicroServiceXUnitTest.Models.Person
{
    public class SonTest
    {
        IPerson _son;
        public SonTest()
        {
            _son = new Son("Mike", "Joan");
        }

        [Fact]
        public void Son_NotNull()
        {
            Assert.NotNull(_son);
        }

        [Fact]
        public void Son_Null()
        {
            Son son = null;
            Assert.Null(son);
        }

        [Fact]
        public void NameTest_Equal()
        {
            Assert.Equal("Mike", _son.GetName());
        }

        [Fact]
        public void NameTest_NotEqual()
        {
            Assert.NotEqual("Joan", _son.GetName());
        }

        [Fact]
        public void NameTest_Empty()
        {
            IPerson son = new Son();
            Assert.Empty(son.GetName());
        }

        [Fact]
        public void SonsNameTest_Equal()
        {
            Assert.Equal("Joan", _son.GetSonsName());
        }

        [Fact]
        public void SonsNameTest_NotEqual()
        {
            Assert.NotEqual("Mike", _son.GetSonsName());
        }

        [Fact]
        public void SonsNameTest_Empty()
        {
            IPerson son = new Son();
            Assert.Empty(son.GetSonsName());
        }

        [Fact]
        public void SonGreetingMessage_Equal()
        {
            Assert.Equal("Hello my name is " + _son.GetName(), _son.GreetingMessage());
        }

        [Fact]
        public void SonsGreetingMessage_NotEqual()
        {
            Assert.NotEqual("Hi", _son.GreetingMessage());
        }

        [Fact]
        public void SonsGreetingMessage_Empty()
        {
            IPerson son = new Son();
            Assert.Empty(son.GreetingMessage());
        }
    }
}
