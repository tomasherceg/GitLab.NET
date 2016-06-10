using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
    public class GitLabLicenseRepositoryTests
    {
        public GitLabLicenseRepositoryTests()
        {
            _requestFactory = Substitute.For<IRequestFactory>();
        }

        private readonly IRequestFactory _requestFactory;

        [Test]
        public async Task Get_SetsCorrectResourceAndMethod()
        {
            var sut = new GitLabLicenseRepository(_requestFactory);

            await sut.Get();

            _requestFactory.Received().Create("license", Method.Get);
        }
    }
}