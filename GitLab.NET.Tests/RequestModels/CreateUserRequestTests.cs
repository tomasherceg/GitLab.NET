using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateUserRequestTests
    {
        [Fact]
        public void GetRequest_AddsEmailParameter()
        {
            const string expected = "email";
            var expectedParameter = new Parameter
            {
                Name = "email",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest(expected, "password", "username", "name");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsNameParameter()
        {
            const string expected = "name";
            var expectedParameter = new Parameter
            {
                Name = "name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsPasswordParameter()
        {
            const string expected = "password";
            var expectedParameter = new Parameter
            {
                Name = "password",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", expected, "username", "name");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsUsernameParameter()
        {
            const string expected = "username";
            var expectedParameter = new Parameter
            {
                Name = "username",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", expected, "name");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AdminIsSet_AddsParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "admin",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", admin: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_BioIsSet_AddsParameter()
        {
            const string expected = "bio";
            var expectedParameter = new Parameter
            {
                Name = "bio",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", bio: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_CanCreateGroupIsSet_AddsParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "can_create_group",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", canCreateGroup: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ConfirmIsSet_AddsParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "confirm",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", confirm: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ExternalIsSet_AddsParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "external",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", external: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ExternUidIsSet_AddsParameter()
        {
            const string expected = "extern_uid";
            var expectedParameter = new Parameter
            {
                Name = "extern_uid",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", externUid: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_LinkedInIsSet_AddsParameter()
        {
            const string expected = "linkedin";
            var expectedParameter = new Parameter
            {
                Name = "linkedin",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", linkedIn: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_LocationIsSet_AddsParameter()
        {
            const string expected = "location";
            var expectedParameter = new Parameter
            {
                Name = "location",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", location: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ProjectsLimitIsSet_AddsParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "projects_limit",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", projectsLimit: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ProviderIsSet_AddsParameter()
        {
            const string expected = "provider";
            var expectedParameter = new Parameter
            {
                Name = "provider",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", provider: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateUserRequest("email", "password", "username", "name");

            var result = sut.GetRequest();

            Assert.Equal(CreateUserRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateUserRequest("email", "password", "username", "name");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }

        [Fact]
        public void GetRequest_SkypeIsSet_AddsParameter()
        {
            const string expected = "skype";
            var expectedParameter = new Parameter
            {
                Name = "skype",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_TwitterIsSet_AddsParameter()
        {
            const string expected = "twitter";
            var expectedParameter = new Parameter
            {
                Name = "twitter",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", twitter: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_WebsiteUrlIsSet_AddsParameter()
        {
            const string expected = "website_url";
            var expectedParameter = new Parameter
            {
                Name = "website_url",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateUserRequest("email", "password", "username", "name", websiteUrl: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}