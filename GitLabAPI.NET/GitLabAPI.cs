using GitLabAPI.NET.Factories;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET
{
    public class GitLabAPI
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();

        private Uri baseUri = new Uri("https://gitlab.com" + apiPath);
        private const string apiPath = "/api/v3";
        private string privateToken;

        public GitLabAPI(string privateToken)
        {
            if (string.IsNullOrEmpty(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            this.privateToken = privateToken;
        }

        public GitLabAPI(string privateToken, Uri hostUri) : this(privateToken)
        {
            baseUri = new Uri(hostUri, apiPath);
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = RestClientFactory.Create();
            client.BaseUrl = baseUri;

            // Add the private token to every request
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);

            var response = client.Execute<T>(request);

            return response.Data;
        }

        private async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = RestClientFactory.Create();
            client.BaseUrl = baseUri;

            // Add the private token to every request
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);

            var response = await client.ExecuteTaskAsync<T>(request);

            return response.Data;
        }
    }
}
