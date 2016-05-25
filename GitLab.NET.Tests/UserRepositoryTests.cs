using System;
using GitLab.NET;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Constructor_RestExecutorIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UserRepository(null));
        }
    }
}