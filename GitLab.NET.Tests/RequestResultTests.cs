using System;
using System.Net;
using RestSharp;
using NUnit.Framework;

namespace GitLab.NET.Tests
{
	public class RequestResultTests
	{
		[Test]
		public void ConstructorWithoutType_ResponseIsNull_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new RequestResult<object>(null, new object()));
		}

		[Test]
		public void ConstructorWithoutType_SetsData()
		{
			var expected = new object();
			var response = new RestResponse<object>();

			var result = new RequestResult<object>(response, expected);

			Assert.AreEqual(expected, result.Data);
		}

		[Test]
		public void ConstructorWithoutType_SetsStatusCode()
		{
			const HttpStatusCode expected = HttpStatusCode.OK;
			var response = new RestResponse<object>
			{
				StatusCode = expected
			};

			var result = new RequestResult<object>(response, new object());

			Assert.AreEqual(expected, result.StatusCode);
		}

		[Test]
		public void ConstructorWithType_ResponseIsNull_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new RequestResult<object>(null));
		}

		[Test]
		public void ConstructorWithType_SetsData()
		{
			var expected = new object();
			var response = new RestResponse<object>
			{
				Data = expected
			};

			var result = new RequestResult<object>(response);

			Assert.AreEqual(expected, result.Data);
		}

		[Test]
		public void ConstructorWithType_SetsStatusCode()
		{
			const HttpStatusCode expected = HttpStatusCode.OK;
			var response = new RestResponse<object>
			{
				StatusCode = expected
			};

			var result = new RequestResult<object>(response);

			Assert.AreEqual(expected, result.StatusCode);
		}
	}
}