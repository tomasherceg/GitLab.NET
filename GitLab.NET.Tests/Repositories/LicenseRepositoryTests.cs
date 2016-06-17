using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class LicenseRepositoryTests
	{
		public LicenseRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Fact]
		public async Task Find_FullNameIsSet_AddsFullNameParameter()
		{
			const string expected = "fullName";
			var sut = new LicenseRepository(_requestFactory);

			await sut.Find("key", fullName: expected);

			_request.Received().AddParameterIfNotNull("fullname", expected);
		}

		[Fact]
		public async Task Find_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new LicenseRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(null));
		}

		[Fact]
		public async Task Find_ProjectIsSet_AddsProjectParameter()
		{
			const string expected = "project";
			var sut = new LicenseRepository(_requestFactory);

			await sut.Find("key", expected);

			_request.Received().AddParameterIfNotNull("project", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsKeyUrlSegment()
		{
			const string expected = "key";
			var sut = new LicenseRepository(_requestFactory);

			await sut.Find(expected);

			_request.Received().AddUrlSegment("key", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_SetsCorrectResourceAndmethod()
		{
			var sut = new LicenseRepository(_requestFactory);

			await sut.Find("key");

			_requestFactory.Received().Create("licenses/{key}", Method.Get);
		}

		[Fact]
		public async Task GetAll_PopularIsSet_AddsPopularParameter()
		{
			const bool expected = true;
			var sut = new LicenseRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddParameterIfNotNull("popular", expected);
		}

		[Fact]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new LicenseRepository(_requestFactory);

			await sut.GetAll();

			_requestFactory.Received().Create("licenses", Method.Get);
		}
	}
}