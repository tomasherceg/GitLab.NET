using System;
using System.Threading.Tasks;
using GitLab.NET.ResponseModels;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests
{
    public class SessionRepositoryTests
    {
        [Fact]
        public void RequestSession_UsernameIsNull_ThrowsArugmentNullException()
        {
            var sut = new SessionRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.RequestSession(null, "password"));
        }

        [Fact]
        public async Task RequestSessionAsync_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new SessionRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.RequestSessionAsync(null, "password"));
        }

        [Fact]
        public void RequestSession_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new SessionRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.RequestSession("username", null));
        }

        [Fact]
        public async Task RequestSessionAsync_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new SessionRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.RequestSessionAsync("username", null));
        }

        [Fact]
        public void RequestSession_ValidParameters_SetsAuthenticateFalse()
        {
            var requestExecutor = Substitute.For<IRequestExecutor>();
            var sut = new SessionRepository(requestExecutor);

            sut.RequestSession("username", "password");

            requestExecutor.Received().Execute<User>(Arg.Any<IRequestModel>(), false);
        }

        [Fact]
        public async Task RequestSessionAsync_ValidParameters_SetsAuthenticateFalse()
        {
            var requestExecutor = Substitute.For<IRequestExecutor>();
            var sut = new SessionRepository(requestExecutor);

            await sut.RequestSessionAsync("username", "password");

            await requestExecutor.Received().ExecuteAsync<User>(Arg.Any<IRequestModel>(), false);
        }
    }
}
