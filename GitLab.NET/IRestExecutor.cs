using System.Threading.Tasks;
using RestSharp;

namespace GitLab.NET
{
    public interface IRestExecutor
    {
        /// <summary>
        ///     Executes a request synchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        IRestResponse<T> Execute<T>(IRequestModel requestModel) where T : new();

        /// <summary>
        ///     Executes a request asynchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        Task<IRestResponse<T>> ExecuteAsync<T>(IRequestModel requestModel) where T : new();
    }
}