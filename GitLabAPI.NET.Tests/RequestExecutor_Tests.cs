using System;
using Xunit;

namespace GitLabAPI.NET.Tests
{
    public class RequestExecutor_Tests
    {
        [Fact]
        public void Constructor_BaseUriNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RequestExecutor(null));
        }
    }
}
