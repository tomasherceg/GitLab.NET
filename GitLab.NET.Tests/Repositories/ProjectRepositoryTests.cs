using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;
using System.Linq;

namespace GitLab.NET.Tests.Repositories {
    public class ProjectRepositoryTests {

        public ProjectRepositoryTests() {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Find_IdOverload_ValidParameters_AddsIdUrlSegment() {
            const uint expected = 0;
            var sut = new ProjectRepository(_requestFactory);

            await sut.Find(expected);

            _request.Received().AddUrlSegment("id", expected);
        }
    }


}
