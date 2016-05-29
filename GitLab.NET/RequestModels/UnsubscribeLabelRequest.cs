﻿using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UnsubscribeLabelRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/labels/{labelId}/subscription";
        
        private readonly string _labelName;
        private readonly uint _projectId;

        public UnsubscribeLabelRequest(uint projectId, string labelName)
        {
            _projectId = projectId;
            _labelName = labelName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.DELETE);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("labelId", _labelName, ParameterType.UrlSegment);
            return result;
        }
    }
}