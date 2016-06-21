using System;
using System.Net;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests
{
	public class RequestResultTests
	{
        // testing

		[Fact]
		public void ConstructorWithoutType_ResponseIsNull_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new RequestResult<object>(null, new object()));
		}

		[Fact]
		public void ConstructorWithoutType_SetsData()
		{
			var expected = new object();
			var response = new RestResponse<object>();

			var result = new RequestResult<object>(response, expected);

			Assert.Equal(expected, result.Data);
		}

		[Fact]
		public void ConstructorWithoutType_SetsStatusCode()
		{
			const HttpStatusCode expected = HttpStatusCode.OK;
			var response = new RestResponse<object>
			{
				StatusCode = expected
			};

			var result = new RequestResult<object>(response, new object());

			Assert.Equal(expected, result.StatusCode);
		}

		[Fact]
		public void ConstructorWithType_ResponseIsNull_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new RequestResult<object>(null));
		}

		[Fact]
		public void ConstructorWithType_SetsData()
		{
			var expected = new object();
			var response = new RestResponse<object>
			{
				Data = expected
			};

			var result = new RequestResult<object>(response);

			Assert.Equal(expected, result.Data);
		}

		[Fact]
		public void ConstructorWithType_SetsStatusCode()
		{
			const HttpStatusCode expected = HttpStatusCode.OK;
			var response = new RestResponse<object>
			{
				StatusCode = expected
			};

			var result = new RequestResult<object>(response);

			Assert.Equal(expected, result.StatusCode);
		}
	}
}