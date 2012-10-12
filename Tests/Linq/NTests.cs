using System.Linq;
using DotNetExtensions.Linq;
using Xunit;

namespace DotNetExtensions.Tests.Linq
{
    public class NTests
    {
        [Fact] 
        public void NIncludingZeroReturnsAllIntegersBetween0AndNInclusive()
        {
            var result = 3.N(true).ToArray();

            Assert.Equal(4, result.Length);
            Assert.Equal(0,result[0]);
            Assert.Equal(1,result[1]);
            Assert.Equal(2,result[2]);
            Assert.Equal(3,result[3]);
        }

        [Fact]
        public void NExcludingZeroReturnsAllIntegersBetween1AndNInclusive()
        {
            var result = 3.N(false).ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal(1,result[0]);
            Assert.Equal(2,result[1]);
            Assert.Equal(3,result[2]);
        }
    }
}