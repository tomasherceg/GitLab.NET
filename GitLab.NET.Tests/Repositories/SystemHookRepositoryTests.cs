using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

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

		[Test]
		public void Create_UrlIsNull_ThrowsArgumentNullException()
		{
			var sut = new SystemHookRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(null));
		}

		[Test]
		public async Task Create_ValidParameters_AddsUrlParameter()
		{
			const string expected = "url";
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Create(expected);

			_request.Received().AddParameter("url", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Create("url");

			_requestFactory.Received().Create("hooks", Method.Post);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsHookIdParameter()
		{
			const uint expected = 0;
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Delete(expected);

			_request.Received().AddUrlSegment("hookId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Delete(0);

			_requestFactory.Received().Create("hooks/{hookId}", Method.Delete);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new SystemHookRepository(_requestFactory);

			await sut.GetAll();

			_requestFactory.Received().Create("hooks", Method.Get);
		}

		[Test]
		public async Task Test_ValidParameters_AddsHookIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Test(expected);

			_request.Received().AddUrlSegment("hookId", expected);
		}

		[Test]
		public async Task Test_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new SystemHookRepository(_requestFactory);

			await sut.Test(0);

			_requestFactory.Received().Create("hooks/{hookId}", Method.Get);
		}
	}
}