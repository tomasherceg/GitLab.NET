using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using System;
using Xunit;

namespace GitLab.NET.Tests.RequestHelpers
{
    public class GetUsers_Tests
    {
        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_SearchIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidSearch)
        {
            Assert.Throws<ArgumentException>("search", () => new GetUsers(invalidSearch, 0, 0));
        }

        [Fact]
        public void Constructor_SearchIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("search", () => new GetUsers(null, 0, 0));
        }

        [Fact]
        public void GetRequest_SearchIsSet_AddsParameter()
        {
            var searchName = "search";
            var searchValue = "searchValue";
            var sut = new GetUsers(searchValue, 0, 0);
            var expected = new Parameter() { Name = searchName, Value = searchValue };

            var result = sut.GetRequest();

            Assert.Contains(expected, result.Parameters, new ParameterEqualityComparer());
        }
    }
}
