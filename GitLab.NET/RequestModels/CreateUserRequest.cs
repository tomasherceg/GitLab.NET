using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateUserRequest : IRequestModel
    {
        public const string Resource = "users";

        private readonly bool? _admin;
        private readonly string _bio;
        private readonly bool? _canCreateGroup;
        private readonly bool? _confirm;
        private readonly string _email;
        private readonly bool? _external;
        private readonly string _externUid;
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

        public CreateUserRequest(string email,
                                 string password,
                                 string username,
                                 string name,
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
                                 bool? confirm = null,
                                 bool? external = null)
        {
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
            _confirm = confirm;
            _external = external;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.POST);

            request.AddParameter("email", _email);
            request.AddParameter("password", _password);
            request.AddParameter("username", _username);
            request.AddParameter("name", _name);
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
            request.AddParameterIfNotNull("confirm", _confirm);
            request.AddParameterIfNotNull("external", _external);

            return request;
        }
    }
}