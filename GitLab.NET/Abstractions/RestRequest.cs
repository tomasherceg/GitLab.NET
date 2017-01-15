using System;
using System.Threading.Tasks;

namespace GitLab.NET.Abstractions
{
    internal class RestRequest : IRequest
    {
        private readonly Method method;
        private string _resource;

        public void AddParameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void AddParameterIfNotNull(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void AddUrlSegment(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void AddUrlSegmentIfNotNull(string name, object value)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<T>> Execute<T>() where T : new()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<byte[]>> ExecuteBytes()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<string>> ExecuteContent()
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResult<T>> ExecutePaginated<T>() where T : new()
        {
            throw new NotImplementedException();
        }
    }
}