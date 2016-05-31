namespace GitLab.NET.Abstractions
{
    /// <summary> Provides a factory pattern for creating requests. </summary>
    public interface IRequestFactory
    {
        /// <summary> Creates a new <see cref="IRequest" /> instance. </summary>
        /// <param name="resource"> The resource to use for this request. </param>
        /// <param name="method"> The method to use for this request. </param>
        /// <param name="authenticate"> Whether or not to use authentication for this request. </param>
        /// <returns> A new instance of <see cref="IRequest" />. </returns>
        IRequest Create(string resource, Method method, bool authenticate = true);
    }
}