using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class BuildVariableRepositoryTests
	{
		public BuildVariableRepositoryTests()
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
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "value"));
		}

		[Test]
		public async Task Create_ValidParameters_AddsKeyParameter()
		{
			const string expected = "key";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Create(0, expected, "value");

			_request.Received().AddParameter("key", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Create(expected, "key", "value");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsValueParameter()
		{
			const string expected = "value";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Create(0, "key", expected);

			_request.Received().AddParameter("value", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Create(0, "key", "value");

			_requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
		}

		[Test]
		public void Create_ValueIsNull_ThrowsArgumentNullException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "key", null));
		}

		[Test]
		public void Delete_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
		}

		[Test]
		public async Task Delete_ValidParameters_AddsKeyUrlSegment()
		{
			const string expected = "key";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegment("key", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Delete(expected, "key");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Delete(0, "key");

			_requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
		}

		[Test]
		public void Find_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
		}

		[Test]
		public async Task Find_ValidParameters_AddsKeyUrlSegment()
		{
			const string expected = "key";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("key", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Find(expected, "key");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Find(0, "key");

			_requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
		}

		[Test]
		public void GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, uint.MinValue));
		}

		[Test]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.GetAll(0, expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public void GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MaxValue));
		}

		[Test]
		public void GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MinValue));
		}

		[Test]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.GetAll(0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
		}

		[Test]
		public void Update_KeyIsNull_ThrowsArgumentNullException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, null, "value"));
		}

		[Test]
		public async Task Update_ValidParameters_AddsKeyUrlSegment()
		{
			const string expected = "key";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Update(0, expected, "value");

			_request.Received().AddUrlSegment("key", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Update(expected, "key", "value");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsValueParameter()
		{
			const string expected = "value";
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Update(0, "key", expected);

			_request.Received().AddParameter("value", expected);
		}

		[Test]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			await sut.Update(0, "key", "value");

			_requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
		}

		[Test]
		public void Update_ValueIsNull_ThrowsArgumentNullException()
		{
			var sut = new BuildVariableRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, "key", null));
		}
	}
}