using System;
using System.Threading.Tasks;
using NSubstitute;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;

namespace GitLab.NET.Tests
{
    public class TestException : Exception { }

    public class RequestExecutorTests
    {
        public RequestExecutorTests()
        {
            _authenticator = Substitute.For<IPrivateTokenAuthenticator>();
            _restClientFactory = Substitute.For<IRestClientFactory>();
        }

        private static readonly Uri ValidBaseUri = new Uri("https://host.com");
        private readonly IRestClientFactory _restClientFactory;
        private readonly IPrivateTokenAuthenticator _authenticator;

        [Fact]
        public void Constructor_AuthenticatorIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RequestExecutor(_restClientFactory, ValidBaseUri, null));
        }

        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RequestExecutor(_restClientFactory, null, _authenticator));
        }

        [Fact]
        public void Constructor_RestClientFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RequestExecutor(null, ValidBaseUri, _authenticator));
        }

        [Fact]
        public void Execute_AuthenticateIsFalse_DoesNotAuthenticate()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            sut.Execute<object>(Substitute.For<IRequestModel>(), false);

            _restClientFactory.Received().Create(Arg.Any<Uri>());
        }

        [Fact]
        public void Execute_AuthenticateIsTrue_DoesAuthenticate()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            sut.Execute<object>(Substitute.For<IRequestModel>());

            _restClientFactory.Received().Create(Arg.Any<Uri>(), Arg.Any<IAuthenticator>());
        }

        [Fact]
        public void Execute_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            Assert.Throws<ArgumentNullException>(() => sut.Execute<object>(null));
        }

        [Fact]
        public void Execute_RestResponseErrorExceptionIsSet_ThrowsErrorException()
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.Execute<object>(null).ReturnsForAnyArgs(new RestResponse<object>
            {
                ErrorException = new Exception()
            });
            _restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            Assert.Throws<Exception>(() => sut.Execute<object>(Substitute.For<IRequestModel>()));
        }

        [Fact]
        public async Task ExecuteAsync_AuthenticateIsFalse_DoesNotAuthenticate()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            await sut.ExecuteAsync<object>(Substitute.For<IRequestModel>(), false);

            _restClientFactory.Received().Create(Arg.Any<Uri>());
        }

        [Fact]
        public async Task ExecuteAsync_AuthenticateIsTrue_DoesAuthenticate()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            await sut.ExecuteAsync<object>(Substitute.For<IRequestModel>());

            _restClientFactory.Received().Create(Arg.Any<Uri>(), Arg.Any<IAuthenticator>());
        }

        [Fact]
        public async Task ExecuteAsync_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ExecuteAsync<object>(null));
        }

        [Fact]
        public async Task ExecuteAsync_RestResponseErrorExceptionIsSet_ThrowsErrorException()
        {
            var restClient = Substitute.For<IRestClient>();
            restClient.ExecuteTaskAsync<object>(null).ReturnsForAnyArgs(new RestResponse<object>
            {
                ErrorException = new TestException()
            });
            _restClientFactory.Create(null).ReturnsForAnyArgs(restClient);
            var sut = new RequestExecutor(_restClientFactory, ValidBaseUri, _authenticator);

            await Assert.ThrowsAsync<TestException>(() => sut.ExecuteAsync<object>(Substitute.For<IRequestModel>()));
        }
    }
}