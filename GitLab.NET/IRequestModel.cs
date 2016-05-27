using RestSharp;

namespace GitLab.NET
{
    /// <summary>
    /// Provides a simple wrapper to create <see cref="IRestRequest" />s from a model.
    /// </summary>
    public interface IRequestModel
    {
        /// <summary>
        /// Creates an <see cref="IRestRequest" /> instance.
        /// </summary>
        /// <returns>An <see cref="IRestRequest" /> representing the model.</returns>
        IRestRequest GetRequest();
    }
}