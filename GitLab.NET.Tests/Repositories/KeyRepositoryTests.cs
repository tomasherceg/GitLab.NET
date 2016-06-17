using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class KeyRepositoryTests
	{
		public KeyRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Fact]
		public async Task Create_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new KeyRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create("title", null));
		}

		[Fact]
		public async Task Create_TitleIsNull_ThrowsArgumentNullException()
		{
			var sut = new KeyRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(null, "key"));
		}

		[Fact]
		public async Task Create_UserIdIsNotSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.Create("title", "key");

			_requestFactory.Received().Create("user/keys", Method.Post);
		}

		[Fact]
		public async Task Create_UserIdIsSet_AddsUserIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.Create("title", "key", expected);

			_request.Received().AddUrlSegmentIfNotNull("userId", expected);
		}

		[Fact]
		public async Task Create_UserIdIsSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.Create("title", "key", 0);

			_requestFactory.Received().Create("users/{userId}/keys", Method.Post);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsKeyParameter()
		{
			const string expected = "key";
			var sut = new KeyRepository(_requestFactory);

			await sut.Create("title", expected);

			_request.Received().AddParameter("key", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new KeyRepository(_requestFactory);

			await sut.Create(expected, "key");

			_request.Received().AddParameter("title", expected);
		}

		[Fact]
		public async Task Delete_UserIdIsNotSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.Delete(0);

			_requestFactory.Received().Create("user/keys/{id}", Method.Delete);
		}

		[Fact]
		public async Task Delete_UserIdIsSet_AddsUserIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegmentIfNotNull("userId", expected);
		}

		[Fact]
		public async Task Delete_UserIdIsSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.Delete(0, 0);

			_requestFactory.Received().Create("users/{userId}/keys/{id}", Method.Delete);
		}

		[Fact]
		public async Task Delete_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.Delete(expected);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.Find(expected);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.Find(0);

			_requestFactory.Received().Create("user/keys/{id}", Method.Get);
		}

		[Fact]
		public async Task FindWithUser_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.FindWithUser(expected);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task FindWithUser_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.FindWithUser(0);

			_requestFactory.Received().Create("keys/{id}", Method.Get);
		}

		[Fact]
		public async Task GetAll_UserIdIsNotSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.GetAll();

			_requestFactory.Received().Create("user/keys", Method.Get);
		}

		[Fact]
		public async Task GetAll_UserIdIsSet_AddsUserIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new KeyRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegmentIfNotNull("userId", expected);
		}

		[Fact]
		public async Task GetAll_UserIdIsSet_SetsCorrectResourceAndMethod()
		{
			var sut = new KeyRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("users/{userId}/keys", Method.Get);
		}
	}
}