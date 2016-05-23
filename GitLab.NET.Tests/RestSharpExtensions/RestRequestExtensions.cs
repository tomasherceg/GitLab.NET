using GitLab.NET.RestSharpExtensions;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RestSharpExtensions
{
    public class RestRequestExtensions
    {
        [Fact]
        public void AddParameterIfNotNull_WithNameValue_AddsParameterIfNotNull()
        {
            var sut = new RestRequest();
            var validName = "validName";
            var notNullObject = new object();

            sut.AddParameterIfNotNull(validName, notNullObject);

            Assert.Equal(validName, sut.Parameters[0].Name);
            Assert.Equal(notNullObject, sut.Parameters[0].Value);
        }

        [Fact]
        public void AddParameterIfNotNull_WithNameValue_DoesNotAddParameterIfNull()
        {
            var sut = new RestRequest();

            sut.AddParameterIfNotNull("validName", null);

            Assert.Empty(sut.Parameters);
        }

        [Fact]
        public void AddParameterIfNotNull_WithNameValueType_AddsParameterIfNotNull()
        {
            var sut = new RestRequest();
            var validName = "validName";
            var notNullObject = new object();

            sut.AddParameterIfNotNull(validName, notNullObject, ParameterType.GetOrPost);

            Assert.Equal(validName, sut.Parameters[0].Name);
            Assert.Equal(notNullObject, sut.Parameters[0].Value);
        }

        [Fact]
        public void AddParameterIfNotNull_WithNameValueType_DoesNotAddParameterIfNull()
        {
            var sut = new RestRequest();

            sut.AddParameterIfNotNull("validName", null, ParameterType.GetOrPost);

            Assert.Empty(sut.Parameters);
        }

        [Fact]
        public void AddParameterIfNotNull_WithNameValueContentTypeAndType_AddsParameterIfNotNull()
        {
            var sut = new RestRequest();
            var validName = "validName";
            var notNullObject = new object();

            sut.AddParameterIfNotNull(validName, notNullObject, null, ParameterType.GetOrPost);

            Assert.Equal(validName, sut.Parameters[0].Name);
            Assert.Equal(notNullObject, sut.Parameters[0].Value);
        }

        [Fact]
        public void AddParameterIfNotNull_WithNameValueContentTypeAndType_DoesNotAddParameterIfNull()
        {
            var sut = new RestRequest();

            sut.AddParameterIfNotNull("validName", null, null, ParameterType.GetOrPost);

            Assert.Empty(sut.Parameters);
        }
    }
}
