using System.Threading.Tasks;
using RestSharp;

namespace GitLab.NET
{
    /// <summary> Executes RESTful requests and returns the results. </summary>
    public interface IRequestExecutor
    {
        /// <summary> Executes a request synchronously and returns its result. </summary>
        /// <typeparam name="T"> The type to deserialize the response to. </typeparam>
        /// <param name="requestModel"> The IRestRequest to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse{T}" /> instance containing the results of the request. </returns>
        IRestResponse<T> Execute<T>(IRequestModel requestModel, bool authenticate = true) where T : new();

        /// <summary> Executes a request asynchronously and returns its result. </summary>
        /// <typeparam name="T"> The type to deserialize the response to. </typeparam>
        /// <param name="requestModel"> The IRestRequest to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse{T}" /> instance containing the results of the request. </returns>
        Task<IRestResponse<T>> ExecuteAsync<T>(IRequestModel requestModel, bool authenticate = true) where T : new();

        /// <summary> Executes a request synchronously and returns its result. </summary>
        /// <param name="requestModel"> The IRestRequest to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse" /> instance containing the results of the request. </returns>
        IRestResponse Execute(IRequestModel requestModel, bool authenticate = true);

        /// <summary> Executes a request asynchronously and returns its result. </summary>
        /// <param name="requestModel"> The IRestRequest to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse" /> instance containing the results of the request. </returns>
        Task<IRestResponse> ExecuteAsync(IRequestModel requestModel, bool authenticate = true);
    }
}