using System.Threading.Tasks;

namespace GitLab.NET.Abstractions
{
    public interface IRequest
    {
        void AddParameter(string name, object value);
        void AddParameterIfNotNull(string name, object value);
        void AddUrlSegment(string name, object value);
        void AddUrlSegmentIfNotNull(string name, object value);
        Task<RequestResult<T>> ExecuteAsync<T>() where T : new();
        Task<RequestResult<byte[]>> ExecuteBytesAsync();
        Task<RequestResult<string>> ExecuteContentAsync();
        Task<PaginatedResult<T>> ExecutePaginatedAsync<T>() where T : new();
    }
}