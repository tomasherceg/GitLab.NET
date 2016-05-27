using System.Threading.Tasks;
using RestSharp;

namespace GitLab.NET
{
    /// <summary>
    /// Executes RESTful requests and returns the results.
    /// </summary>
    public interface IRequestExecutor
    {
        /// <summary>
        ///     Executes a request synchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <param name="authenticate">Whether or not to use the provided authenticator for this request.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        IRestResponse<T> Execute<T>(IRequestModel requestModel, bool authenticate = true) where T : new();

        /// <summary>
        ///     Executes a request asynchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <param name="authenticate">Whether or not to use the provided authenticator for this request.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        Task<IRestResponse<T>> ExecuteAsync<T>(IRequestModel requestModel, bool authenticate = true) where T : new();
    }
}