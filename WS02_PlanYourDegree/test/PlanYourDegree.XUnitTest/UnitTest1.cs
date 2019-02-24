using System;
using Xunit;
using PlanYourDegree.Models;

namespace PlanYourDegree.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("true", "true");

        }

        [Fact]
        public void TestModel_AddTwoNumbersTest()

        {
            var a = new TestModel();
            int expected = 5;
            int actual = a.AddTwoInt(3, 2);
            Assert.Equal(expected, actual);
        }
    }

    
}
