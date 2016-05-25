using System;
using System.Net;
using System.Threading.Tasks;
using GitLab.NET.Exceptions;
using NSubstitute;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;
using Xunit.Sdk;

namespace GitLab.NET.Tests
{
    public class TestException : Exception { }

    public class RestExecutorTests
    {
        private static readonly Uri ValidBaseUri = new Uri("https://host.com");
        private readonly IRestClientFactory restClientFactory;
        private readonly IAuthenticator authenticator;

        public RestExecutorTests()
        {
            authenticator = Substitute.For<IAuthenticator>();
            restClientFactory = Substitute.For<IRestClientFactory>();
        }

        [Fact]
        public void Constructor_AuthenticatorIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestExecutor(null, ValidBaseUri, authenticator));
        }

        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestExecutor(restClientFactory, null, authenticator));
        }

        [Fact]
        public void Constructor_RestClientFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestExecutor(restClientFactory, ValidBaseUri, null));
        }

        [Fact]
        public void Execute_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            Assert.Throws<ArgumentNullException>(() => sut.Execute<object>(null));
        }

        [Fact]
        public async Task ExecuteAsync_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ExecuteAsync<object>(null));
        }

        [Fact]
        public void Execute_RestResponseErrorExceptionIsSet_ThrowsErrorException()
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.Execute<object>(null).ReturnsForAnyArgs(new RestResponse<object>()
            {
                ErrorException = new Exception()
            });
            restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            Assert.Throws<Exception>(() => sut.Execute<object>(Substitute.For<IRequestModel>()));
        }

        [Fact]
        public async Task ExecuteAsync_RestResponseErrorExceptionIsSet_ThrowsErrorException()
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.ExecuteTaskAsync<object>(null).ReturnsForAnyArgs(new RestResponse<object>()
            {
                ErrorException = new TestException()
            });
            restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            await Assert.ThrowsAsync<TestException>(() => sut.ExecuteAsync<object>(Substitute.For<IRequestModel>()));
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(BadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(UnauthorizedException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(ForbiddenException))]
        [InlineData(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(MethodNotAllowedException))]
        [InlineData(HttpStatusCode.Conflict, typeof(ConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(ServerErrorException))]
        [InlineData((HttpStatusCode)422, typeof(UnprocessableException))]
        [InlineData((HttpStatusCode)int.MaxValue, typeof(UnhandledErrorException))]
        public void Execute_RestResponseStatusNotAcceptable_ThrowsCorrectException(HttpStatusCode statusCode, Type expectedException)
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.Execute<object>(null).ReturnsForAnyArgs(new RestResponse<object>()
            {
                Content = "{\"message\":\"Error Message\"}",
                StatusCode = statusCode
            });
            restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            Assert.Throws(expectedException, () => sut.Execute<object>(Substitute.For<IRequestModel>()));
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(BadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(UnauthorizedException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(ForbiddenException))]
        [InlineData(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(MethodNotAllowedException))]
        [InlineData(HttpStatusCode.Conflict, typeof(ConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(ServerErrorException))]
        [InlineData((HttpStatusCode)422, typeof(UnprocessableException))]
        [InlineData((HttpStatusCode)int.MaxValue, typeof(UnhandledErrorException))]
        public async Task ExecuteAsync_RestResponseStatusNotAcceptable_ThrowsCorrectException(HttpStatusCode statusCode, Type expectedException)
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.ExecuteTaskAsync<object>(null).ReturnsForAnyArgs(new RestResponse<object>()
            {
                Content = "{\"message\":\"Error Message\"}",
                StatusCode = statusCode
            });
            restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RestExecutor(restClientFactory, ValidBaseUri, authenticator);

            await Assert.ThrowsAsync(expectedException, () => sut.ExecuteAsync<object>(Substitute.For<IRequestModel>()));
        }
    }
}