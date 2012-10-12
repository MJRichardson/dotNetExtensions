using System.Collections.Generic;
using DotNetExtensions.Linq;
using Xunit;

namespace DotNetExtensions.Tests.Linq
{
    public class WithMaxTests
    {
        [Fact]
        public void ReturnsMaxForLambdaFunction()
        {
            var subject = new List<int> {33, 4, 2, 5, 7};
            var result = subject.WithMax((x) => -x);

            Assert.Equal(2, result);
        }
    }
}