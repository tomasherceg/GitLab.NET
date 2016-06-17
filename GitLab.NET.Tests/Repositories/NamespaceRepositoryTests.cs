using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
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
		public async Task GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(uint.MinValue));
		}

		[Fact]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new NamespaceRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddParameter("page", expected);
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MaxValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MinValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new NamespaceRepository(_requestFactory);

			await sut.GetAll(resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Fact]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await sut.GetAll();

			_requestFactory.Received().Create("namespaces", Method.Get);
		}

		[Fact]
		public async Task Search_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.Search("search", uint.MinValue));
		}

		[Fact]
		public async Task Search_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new NamespaceRepository(_requestFactory);

			await sut.Search("search", expected);

			_request.Received().AddParameter("page", expected);
		}

		[Fact]
		public async Task Search_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.Search("search", resultsPerPage: uint.MaxValue));
		}

		[Fact]
		public async Task Search_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new NamespaceRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.Search("search", resultsPerPage: uint.MinValue));
		}

		[Fact]
		public async Task Search_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new NamespaceRepository(_requestFactory);

			await sut.Search("search", resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
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