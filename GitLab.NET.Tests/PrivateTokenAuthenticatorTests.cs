using GitLab.NET.Tests.TestHelpers;
using NSubstitute;
using System;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests
{
    public class PrivateTokenAuthenticatorTests
    {
        private const string ValidToken = "validToken";

        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_PrivateTokenIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidToken)
        {
            Assert.Throws<ArgumentException>(() => new PrivateTokenAuthenticator(invalidToken));
        }

        [Fact]
        public void Constructor_PrivateTokenIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PrivateTokenAuthenticator(null));
        }

        [Fact]
        public void Authenticate_ClientIsNull_ThrowsArgumentNullException()
        {
            var sut = new PrivateTokenAuthenticator(ValidToken);
            var request = Substitute.For<IRestRequest>();

            Assert.Throws<ArgumentNullException>(() => sut.Authenticate(null, request));
        }

        [Fact]
        public void Authenticate_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new PrivateTokenAuthenticator(ValidToken);
            var client = Substitute.For<IRestClient>();

            Assert.Throws<ArgumentNullException>(() => sut.Authenticate(client, null));
        }
        
        [Fact]
        public void Authenticate_ValidParameters_AddsPrivateToken()
        {
            var sut = new PrivateTokenAuthenticator(ValidToken);
            var client = Substitute.For<IRestClient>();
            var request = Substitute.For<IRestRequest>();

            sut.Authenticate(client, request);

            request.Received().AddParameter("PRIVATE-TOKEN", Arg.Any<string>(), ParameterType.HttpHeader);
        }
    }
}
