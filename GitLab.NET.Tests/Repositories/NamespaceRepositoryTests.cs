using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class NamespaceRepositoryTests
    {
        public NamespaceRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new NamespaceRepository(_requestFactory);

            await sut.GetAll();

            _requestFactory.Received().Create("namespaces", Method.Get);
        }

        [Fact]
        public async Task Search_SearchIsNull_ThrowsArgumentNullException()
        {
            var sut = new NamespaceRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Search(null));
        }

        [Fact]
        public async Task Search_ValidParameters_AddsSearchParameter()
        {
            const string expected = "search";
            var sut = new NamespaceRepository(_requestFactory);

            await sut.Search(expected);

            _request.Received().AddParameter("search", expected);
        }

        [Fact]
        public async Task Search_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new NamespaceRepository(_requestFactory);

            await sut.Search("search");

            _requestFactory.Received().Create("namespaces", Method.Get);
        }
    }
}
