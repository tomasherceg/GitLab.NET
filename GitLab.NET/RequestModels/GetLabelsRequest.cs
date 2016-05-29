﻿using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetLabelsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/labels";

        private readonly uint _projectId;

        public GetLabelsRequest(uint projectId)
        {
            _projectId = projectId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            return result;
        }
    }
}