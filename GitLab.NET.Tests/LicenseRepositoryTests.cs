using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GitLab.NET.Tests
{
    public class LicenseRepositoryTests
    {
        [Fact]
        public void Get_KeyIsNull_ThrowArgumentNullException()
        {
            var sut = new LicenseRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Get(null));
        }

        [Fact]
        public async Task GetAsync_KeyIsNull_ThrowArgumentNullException()
        {
            var sut = new LicenseRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(null));
        }
    }
}
