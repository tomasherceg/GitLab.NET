using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace GitLab.NET.Abstractions
{
    internal class Request : IRequest
    {
        private readonly IRestRequest _request;
        private readonly IRestClient _client;

        public Request(string resource, Method method, IRestClient client)
        {
            _client = client;
            switch (method)
            {
                case Method.Delete:
                    _request = new RestRequest(resource, RestSharp.Method.DELETE);
                    break;
                case Method.Get:
                    _request = new RestRequest(resource, RestSharp.Method.GET);
                    break;
                case Method.Head:
                    _request = new RestRequest(resource, RestSharp.Method.HEAD);
                    break;
                case Method.Merge:
                    _request = new RestRequest(resource, RestSharp.Method.MERGE);
                    break;
                case Method.Options:
                    _request = new RestRequest(resource, RestSharp.Method.OPTIONS);
                    break;
                case Method.Patch:
                    _request = new RestRequest(resource, RestSharp.Method.PATCH);
                    break;
                case Method.Post:
                    _request = new RestRequest(resource, RestSharp.Method.POST);
                    break;
                case Method.Put:
                    _request = new RestRequest(resource, RestSharp.Method.PUT);
                    break;
            }
        }

        public void AddParameter(string name, object value)
        {
            _request.AddParameter(name, value);
        }

        public void AddParameterIfNotNull(string name, object value)
        {
            if (value != null)
                _request.AddParameter(name, value);
        }

        public void AddUrlSegment(string name, object value)
        {
            _request.AddParameter(name, value, ParameterType.UrlSegment);
        }

        public RequestResult<T> Execute<T>() where T : new()
        {
            var result = _client.Execute<T>(_request);
            return new RequestResult<T>(result);
        }

        public async Task<RequestResult<T>> ExecuteAsync<T>() where T : new()
        {
            var result = await _client.ExecuteTaskAsync<T>(_request);
            return new RequestResult<T>(result);
        }

        public PaginatedResult<T> ExecutePaginated<T>() where T : new()
        {
            var result = _client.Execute<List<T>>(_request);
            return new PaginatedResult<T>(result);
        }

        public async Task<PaginatedResult<T>> ExecutePaginatedAsync<T>() where T : new()
        {
            var result = await _client.ExecuteTaskAsync<List<T>>(_request);
            return new PaginatedResult<T>(result);
        }
    }
}