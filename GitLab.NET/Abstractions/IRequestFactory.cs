namespace GitLab.NET.Abstractions
{
    public interface IRequestFactory
    {
        IRequest Create(string resource, Method method, bool authenticate = true);
    }
}