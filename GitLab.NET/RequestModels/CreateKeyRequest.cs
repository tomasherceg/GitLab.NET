﻿using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateKeyRequest : IRequestModel
    {
        public const string ForCurrentUserResource = "user/keys";
        public const string ForSpecifiedUserResource = "users/{userId}/keys";
        private readonly string _key;
        private readonly string _title;

        private readonly uint? _userId;

        public CreateKeyRequest(string title, string key, uint? userId = null)
        {
            _title = title;
            _key = key;
            _userId = userId;
        }

        public IRestRequest GetRequest()
        {
            if (_userId != null)
            {
                var request = new RestRequest(ForSpecifiedUserResource, Method.POST);
                request.AddParameter("userId", _userId, ParameterType.UrlSegment);
                request.AddParameter("title", _title);
                request.AddParameter("key", _key);
                return request;
            }
            else
            {
                var request = new RestRequest(ForCurrentUserResource, Method.POST);
                request.AddParameter("title", _title);
                request.AddParameter("key", _key);
                return request;
            }
        }
    }
}