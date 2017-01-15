using System.Collections.Generic;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests
{
    public class PaginatedResultTests
    {
        public PaginatedResultTests()
        {
            _response = new RestResponse<List<object>>();

            _response.Headers.Add(new Parameter
            {
                Name = "X-Page",
                Value = ExpectedPage.ToString()
            });

            _response.Headers.Add(new Parameter
            {
                Name = "X-Prev-Page",
                Value = ExpectedPrevPage.ToString()
            });

            _response.Headers.Add(new Parameter
            {
                Name = "X-Next-Page",
                Value = ExpectedNextPage.ToString()
            });

            _response.Headers.Add(new Parameter
            {
                Name = "X-Per-Page",
                Value = ExpectedPerPage.ToString()
            });

            _response.Headers.Add(new Parameter
            {
                Name = "X-Total-Pages",
                Value = ExpectedTotalPages.ToString()
            });

            _response.Headers.Add(new Parameter
            {
                Name = "X-Total",
                Value = ExpectedTotal.ToString()
            });
        }

        private const uint ExpectedPage = 5;
        private const uint ExpectedPrevPage = 4;
        private const uint ExpectedNextPage = 6;
        private const uint ExpectedPerPage = 20;
        private const uint ExpectedTotalPages = 10;
        private const uint ExpectedTotal = 200;

        private readonly IRestResponse<List<object>> _response;

        [Fact]
        public void Constructor_SetsCurrentPage()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedPage, sut.CurrentPage);
        }

        [Fact]
        public void Constructor_SetsNextPage()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedNextPage, sut.NextPage);
        }

        [Fact]
        public void Constructor_SetsPreviousPage()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedPrevPage, sut.PreviousPage);
        }

        [Fact]
        public void Constructor_SetsResultsPerPage()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedPerPage, sut.ResultsPerPage);
        }

        [Fact]
        public void Constructor_SetsTotalPages()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedTotalPages, sut.TotalPages);
        }

        [Fact]
        public void Constructor_SetsTotalResults()
        {
            var sut = new PaginatedResult<object>(_response);

            Assert.Equal(ExpectedTotal, sut.TotalResults);
        }
    }
}