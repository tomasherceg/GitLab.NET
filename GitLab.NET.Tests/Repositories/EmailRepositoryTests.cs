using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class EmailRepositoryTests
    {
        public EmailRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Create_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new EmailRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public async Task Create_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.Create("email");

            _requestFactory.Received().Create("user/emails", Method.Post);
        }

        [Fact]
        public async Task Create_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.Create("email", expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task Create_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.Create("email", expected);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Post);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsEmailParameter()
        {
            const string expected = "email";
            var sut = new EmailRepository(_requestFactory);

            await sut.Create(expected);

            _request.Received().AddParameter("email", expected);
        }

        [Fact]
        public async Task Delete_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.Delete(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Delete);
        }

        [Fact]
        public async Task Delete_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.Delete(0, expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task Delete_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.Delete(0, 0);

            _requestFactory.Received().Create("users/{userId}/emails/{id}", Method.Delete);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.Delete(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.Find(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.Find(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Get);
        }

        [Fact]
        public async Task GetForUser_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUser();

            _requestFactory.Received().Create("user/emails", Method.Get);
        }

        [Fact]
        public async Task GetForUser_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUser(expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task GetForUser_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUser(0);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Get);
        }
    }
}