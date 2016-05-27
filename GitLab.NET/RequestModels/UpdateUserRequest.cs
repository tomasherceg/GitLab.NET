using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UpdateUserRequest : IRequestModel
    {
        public const string Resource = "users/{id}";

        private readonly bool? _admin;
        private readonly string _bio;
        private readonly bool? _canCreateGroup;
        private readonly string _email;
        private readonly bool? _external;
        private readonly string _externUid;
        private readonly uint _id;
        private readonly string _linkedIn;
        private readonly string _location;
        private readonly string _name;
        private readonly string _password;
        private readonly uint? _projectsLimit;
        private readonly string _provider;
        private readonly string _skype;
        private readonly string _twitter;
        private readonly string _username;
        private readonly string _websiteUrl;

        public UpdateUserRequest(uint id,
                                 string email = null,
                                 string password = null,
                                 string username = null,
                                 string name = null,
                                 string skype = null,
                                 string linkedIn = null,
                                 string twitter = null,
                                 string websiteUrl = null,
                                 uint? projectsLimit = null,
                                 string externUid = null,
                                 string provider = null,
                                 string bio = null,
                                 string location = null,
                                 bool? admin = null,
                                 bool? canCreateGroup = null,
                                 bool? external = null)
        {
            _id = id;
            _email = email;
            _password = password;
            _username = username;
            _name = name;
            _skype = skype;
            _linkedIn = linkedIn;
            _twitter = twitter;
            _websiteUrl = websiteUrl;
            _projectsLimit = projectsLimit;
            _externUid = externUid;
            _provider = provider;
            _bio = bio;
            _location = location;
            _admin = admin;
            _canCreateGroup = canCreateGroup;
            _external = external;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.PUT);

            request.AddParameter("id", _id, ParameterType.UrlSegment);
            request.AddParameterIfNotNull("email", _email);
            request.AddParameterIfNotNull("password", _password);
            request.AddParameterIfNotNull("username", _username);
            request.AddParameterIfNotNull("name", _name);
            request.AddParameterIfNotNull("skype", _skype);
            request.AddParameterIfNotNull("linkedin", _linkedIn);
            request.AddParameterIfNotNull("twitter", _twitter);
            request.AddParameterIfNotNull("website_url", _websiteUrl);
            request.AddParameterIfNotNull("projects_limit", _projectsLimit);
            request.AddParameterIfNotNull("extern_uid", _externUid);
            request.AddParameterIfNotNull("provider", _provider);
            request.AddParameterIfNotNull("bio", _bio);
            request.AddParameterIfNotNull("location", _location);
            request.AddParameterIfNotNull("admin", _admin);
            request.AddParameterIfNotNull("can_create_group", _canCreateGroup);
            request.AddParameterIfNotNull("external", _external);

            return request;
        }
    }
}