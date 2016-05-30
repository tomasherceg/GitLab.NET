namespace GitLab.NET.Abstractions
{
    internal class RequestFactory : IRequestFactory
    {
        private readonly IClientFactory _clientFactory;

        public RequestFactory(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IRequest Create(string resource, Method method, bool authenticate = true)
        {
            var client = _clientFactory.Create(authenticate);
            return new Request(resource, method, client);
        }
    }
}