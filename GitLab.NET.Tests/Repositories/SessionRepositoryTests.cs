using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class SessionRepositoryTests
    {
        public SessionRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task RequestSession_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new SessionRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.RequestSession("username", null));
        }

        [Fact]
        public async Task RequestSession_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new SessionRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.RequestSession(null, "password"));
        }

        [Fact]
        public async Task RequestSession_ValidParameters_AddsLoginParameter()
        {
            const string expected = "username";
            var sut = new SessionRepository(_requestFactory);

            await sut.RequestSession(expected, "password");

            _request.Received().AddParameter("login", expected);
        }

        [Fact]
        public async Task RequestSession_ValidParameters_AddsPasswordParameter()
        {
            const string expected = "password";
            var sut = new SessionRepository(_requestFactory);

            await sut.RequestSession("username", expected);

            _request.Received().AddParameter("password", expected);
        }

        [Fact]
        public async Task RequestSession_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new SessionRepository(_requestFactory);

            await sut.RequestSession("username", "password");

            _requestFactory.Received().Create("session", Method.Post, false);
        }
    }
}