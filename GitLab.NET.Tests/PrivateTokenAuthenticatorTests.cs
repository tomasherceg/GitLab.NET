using System;
using NSubstitute;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests
{
    public class PrivateTokenAuthenticatorTests
    {
        private const string ValidToken = "validToken";

        [Fact]
        public void Authenticate_ClientIsNull_ThrowsArgumentNullException()
        {
            var sut = new PrivateTokenAuthenticator
            {
                PrivateToken = ValidToken
            };
            var request = Substitute.For<IRestRequest>();

            Assert.Throws<ArgumentNullException>(() => sut.Authenticate(null, request));
        }

        [Fact]
        public void Authenticate_PrivateTokenNull_ThrowsNullReferenceException()
        {
            var sut = new PrivateTokenAuthenticator();
            var client = Substitute.For<IRestClient>();
            var request = Substitute.For<IRestRequest>();

            Assert.Throws<NullReferenceException>(() => sut.Authenticate(client, request));
        }

        [Fact]
        public void Authenticate_RequestIsNull_ThrowsArgumentNullException()
        {
            var sut = new PrivateTokenAuthenticator
            {
                PrivateToken = ValidToken
            };
            var client = Substitute.For<IRestClient>();

            Assert.Throws<ArgumentNullException>(() => sut.Authenticate(client, null));
        }

        [Fact]
        public void Authenticate_ValidParameters_AddsPrivateToken()
        {
            var sut = new PrivateTokenAuthenticator
            {
                PrivateToken = ValidToken
            };
            var client = Substitute.For<IRestClient>();
            var request = Substitute.For<IRestRequest>();

            sut.Authenticate(client, request);

            request.Received().AddParameter("PRIVATE-TOKEN", Arg.Any<string>(), ParameterType.HttpHeader);
        }
    }
}