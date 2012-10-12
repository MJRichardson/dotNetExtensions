using Xunit;

namespace DotNetExtensions.Tests
{
    public class StringFormatTests
    {
        [Fact]
        public void CanFormatWithAnonymousObject()
        {
            const string subject = "You put your {chirality} {bodyPart} in; You put your {chirality} {bodyPart} out; You put your {chirality} {bodyPart} in and you shake it all about.";
            var result = subject.FormatWith(new {chirality = "left", bodyPart = "foot"});

            const string expected = "You put your left foot in; You put your left foot out; You put your left foot in and you shake it all about.";
            Assert.Equal(expected, result);
        }
    }
}