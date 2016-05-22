﻿using RestSharp;

namespace GitLabAPI.NET.Factories
{
    public interface IRestRequestFactory
    {
        IRestRequest Create(Method method = Method.GET);
    }
}