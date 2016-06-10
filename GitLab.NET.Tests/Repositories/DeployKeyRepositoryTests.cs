using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class DeployKeyRepositoryTests
	{
		public DeployKeyRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Test]
		public void Create_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "title", null));
		}

		[Test]
		public void Create_TitleIsNull_ThrowsArgumentNullException()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "key"));
		}

		[Test]
		public async Task Create_ValidParameters_AddsKeyParameter()
		{
			const string expected = "key";
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Create(0, "title", expected);

			_request.Received().AddParameter("key", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Create(expected, "title", "key");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Create(0, expected, "key");

			_request.Received().AddParameter("title", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Create(0, "title", "key");

			_requestFactory.Received().Create("projects/{projectId}/keys", Method.Post);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsKeyIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegment("keyId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Delete(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Delete(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Delete);
		}

		[Test]
		public async Task Find_ValidParameters_AddsKeyIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("keyId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Find(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Get);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new DeployKeyRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/keys", Method.Get);
		}
	}
}