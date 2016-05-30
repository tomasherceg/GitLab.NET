using System.Threading.Tasks;

namespace GitLab.NET.Abstractions
{
    public interface IRequest
    {
        void AddParameter(string name, object value);
        void AddParameterIfNotNull(string name, object value);
        void AddUrlSegment(string name, object value);
        RequestResult<T> Execute<T>() where T : new();
        Task<RequestResult<T>> ExecuteAsync<T>() where T : new();
        PaginatedResult<T> ExecutePaginated<T>() where T : new();
        Task<PaginatedResult<T>> ExecutePaginatedAsync<T>() where T : new();
    }
}