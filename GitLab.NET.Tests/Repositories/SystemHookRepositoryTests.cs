using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class SystemHookRepositoryTests
    {
        public SystemHookRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Create_UrlIsNull_ThrowsArgumentNullException()
        {
            var sut = new SystemHookRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsUrlParameter()
        {
            const string expected = "url";
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Create(expected);

            _request.Received().AddParameter("url", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Create("url");

            _requestFactory.Received().Create("hooks", Method.Post);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsHookIdParameter()
        {
            const uint expected = 0;
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Delete(expected);

            _request.Received().AddUrlSegment("hookId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Delete(0);

            _requestFactory.Received().Create("hooks/{hookId}", Method.Delete);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new SystemHookRepository(_requestFactory);

            await sut.GetAll();

            _requestFactory.Received().Create("hooks", Method.Get);
        }

        [Fact]
        public async Task Test_ValidParameters_AddsHookIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Test(expected);

            _request.Received().AddUrlSegment("hookId", expected);
        }

        [Fact]
        public async Task Test_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new SystemHookRepository(_requestFactory);

            await sut.Test(0);

            _requestFactory.Received().Create("hooks/{hookId}", Method.Get);
        }
    }
}
