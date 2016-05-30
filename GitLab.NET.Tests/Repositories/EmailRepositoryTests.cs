using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class EmailRepositoryTests
    {
        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        public EmailRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        #region Create
        [Fact]
        public void Create_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new EmailRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public void Create_ValidParameters_AddsEmailParameter()
        {
            const string expected = "email";
            var sut = new EmailRepository(_requestFactory);

            sut.Create(expected);

            _request.Received().AddParameter("email", expected);
        }

        [Fact]
        public void Create_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.Create("email", expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public void Create_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.Create("email", expected);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Post);
        }

        [Fact]
        public void Create_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.Create("email");

            _requestFactory.Received().Create("user/emails", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new EmailRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(null));
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsEmailParameter()
        {
            const string expected = "email";
            var sut = new EmailRepository(_requestFactory);

            await sut.CreateAsync(expected);

            _request.Received().AddParameter("email", expected);
        }

        [Fact]
        public async Task CreateAsync_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.CreateAsync("email", expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task CreateAsync_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.CreateAsync("email", expected);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.CreateAsync("email");

            _requestFactory.Received().Create("user/emails", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.Delete(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public void Delete_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.Delete(0, expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public void Delete_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.Delete(0, 0);

            _requestFactory.Received().Create("users/{userId}/emails/{id}", Method.Delete);
        }

        [Fact]
        public void Delete_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.Delete(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.DeleteAsync(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task DeleteAsync_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.DeleteAsync(0, expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task DeleteAsync_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.DeleteAsync(0, 0);

            _requestFactory.Received().Create("users/{userId}/emails/{id}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.DeleteAsync(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.Find(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.Find(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.FindAsync(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.FindAsync(0);

            _requestFactory.Received().Create("user/emails/{id}", Method.Get);
        }
        #endregion

        #region GetForUser
        [Fact]
        public void GetForUser_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            sut.GetForUser(expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public void GetForUser_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.GetForUser(0);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Get);
        }

        [Fact]
        public void GetForUser_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            sut.GetForUser();

            _requestFactory.Received().Create("user/emails", Method.Get);
        }

        [Fact]
        public async Task GetForUserAsync_UserIdIsSet_AddsUserIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUserAsync(expected);

            _request.Received().AddUrlSegmentIfNotNull("userId", expected);
        }

        [Fact]
        public async Task GetForUserAsync_UserIdIsSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUserAsync(0);

            _requestFactory.Received().Create("users/{userId}/emails", Method.Get);
        }

        [Fact]
        public async Task GetForUserAsync_UserIdIsNotSet_SetsCorrectResourceAndMethod()
        {
            var sut = new EmailRepository(_requestFactory);

            await sut.GetForUserAsync();

            _requestFactory.Received().Create("user/emails", Method.Get);
        }
        #endregion
    }
}
