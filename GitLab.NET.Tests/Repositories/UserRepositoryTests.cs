using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class UserRepositoryTests
    {
        public UserRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Block_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Block(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Block_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Block(0);

            _requestFactory.Received().Create("users/{id}/block", Method.Put);
        }

        [Fact]
        public async Task Create_AdminIsSet_AddsAdminParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", admin: expected);

            _request.Received().AddParameterIfNotNull("admin", expected);
        }

        [Fact]
        public async Task Create_BioIsSet_AddsBioParameter()
        {
            const string expected = "bio";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", bio: expected);

            _request.Received().AddParameterIfNotNull("bio", expected);
        }

        [Fact]
        public async Task Create_CanCreateGroupIsSet_AddsCanCreateGroupParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", canCreateGroup: expected);

            _request.Received().AddParameterIfNotNull("can_create_group", expected);
        }

        [Fact]
        public async Task Create_ConfirmIsSet_AddsConfirmParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", confirm: expected);

            _request.Received().AddParameterIfNotNull("confirm", expected);
        }

        [Fact]
        public async Task Create_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(null, "password", "username", "name"));
        }

        [Fact]
        public async Task Create_ExternalIsSet_AddsExternalParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", external: expected);

            _request.Received().AddParameterIfNotNull("external", expected);
        }

        [Fact]
        public async Task Create_ExternUidIsSet_AddsExternUidParameter()
        {
            const string expected = "externUid";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", externUid: expected);

            _request.Received().AddParameterIfNotNull("extern_uid", expected);
        }

        [Fact]
        public async Task Create_LinkedInIsSet_AddsLinkedInParameter()
        {
            const string expected = "linkedIn";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", linkedIn: expected);

            _request.Received().AddParameterIfNotNull("linkedin", expected);
        }

        [Fact]
        public async Task Create_LocationIsSet_AddsLocationParameter()
        {
            const string expected = "location";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", location: expected);

            _request.Received().AddParameterIfNotNull("location", expected);
        }

        [Fact]
        public async Task Create_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create("email", "password", "username", null));
        }

        [Fact]
        public async Task Create_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create("email", null, "username", "name"));
        }

        [Fact]
        public async Task Create_ProjectsLimitIsSet_AddsProjectsLimitParameter()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", projectsLimit: expected);

            _request.Received().AddParameterIfNotNull("projects_limit", expected);
        }

        [Fact]
        public async Task Create_ProviderIsSet_AddsProviderParameter()
        {
            const string expected = "provider";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", provider: expected);

            _request.Received().AddParameterIfNotNull("provider", expected);
        }

        [Fact]
        public async Task Create_SkypeIsSet_AddsSkypeParameter()
        {
            const string expected = "skype";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", expected);

            _request.Received().AddParameterIfNotNull("skype", expected);
        }

        [Fact]
        public async Task Create_TwitterIsSet_AddsTwitterParameter()
        {
            const string expected = "twitter";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", twitter: expected);

            _request.Received().AddParameterIfNotNull("twitter", expected);
        }

        [Fact]
        public async Task Create_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create("email", "password", null, "name"));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsEmailParameter()
        {
            const string expected = "email";
            var sut = new UserRepository(_requestFactory);

            await sut.Create(expected, "password", "username", "name");

            _request.Received().AddParameter("email", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", expected);

            _request.Received().AddParameter("name", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsPasswordParameter()
        {
            const string expected = "password";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", expected, "username", "name");

            _request.Received().AddParameter("password", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsUsernameParameter()
        {
            const string expected = "username";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", expected, "name");

            _request.Received().AddParameter("username", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name");

            _requestFactory.Received().Create("users", Method.Post);
        }

        [Fact]
        public async Task Create_WebsiteUrlIsSet_AddsWebsiteUrlParameter()
        {
            const string expected = "websiteUrl";
            var sut = new UserRepository(_requestFactory);

            await sut.Create("email", "password", "username", "name", websiteUrl: expected);

            _request.Received().AddParameterIfNotNull("website_url", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Delete(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Delete(0);

            _requestFactory.Received().Create("users/{id}", Method.Delete);
        }

        [Fact]
        public async Task Find_IdOverload_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Find(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Find_IdOverload_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Find(0);

            _requestFactory.Received().Create("users/{id}", Method.Get);
        }

        [Fact]
        public async Task Find_UsernameOverload_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(null));
        }

        [Fact]
        public async Task Find_UsernameOverload_ValidParameters_AddsUsernameParameter()
        {
            const string expected = "username";
            var sut = new UserRepository(_requestFactory);

            await sut.Find(expected);

            _request.Received().AddParameter("username", expected);
        }

        [Fact]
        public async Task Find_UsernameOverload_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Find("username");

            _requestFactory.Received().Create("users", Method.Get);
        }

        [Fact]
        public async Task GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(uint.MinValue));
        }

        [Fact]
        public async Task GetAll_PageIsSet_AddsPageParameter()
        {
            const uint expected = 5;
            var sut = new UserRepository(_requestFactory);

            await sut.GetAll(expected);

            _request.Received().AddParameter("page", expected);
        }

        [Fact]
        public async Task GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MinValue));
        }

        [Fact]
        public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
        {
            const uint expected = 5;
            var sut = new UserRepository(_requestFactory);

            await sut.GetAll(resultsPerPage: expected);

            _request.Received().AddParameter("per_page", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.GetAll();

            _requestFactory.Received().Create("users", Method.Get);
        }

        [Fact]
        public async Task GetCurrent_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.GetCurrent();

            _requestFactory.Received().Create("user", Method.Get);
        }

        [Fact]
        public async Task Search_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.Search("search", uint.MinValue));
        }

        [Fact]
        public async Task Search_PageIsSet_AddsPageParameter()
        {
            const uint expected = 5;
            var sut = new UserRepository(_requestFactory);

            await sut.Search("search", expected);

            _request.Received().AddParameter("page", expected);
        }

        [Fact]
        public async Task Search_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => sut.Search("search", resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task Search_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => sut.Search("search", resultsPerPage: uint.MinValue));
        }

        [Fact]
        public async Task Search_ResultsPerPageIsSet_AddsPerPageParameter()
        {
            const uint expected = 5;
            var sut = new UserRepository(_requestFactory);

            await sut.Search("search", resultsPerPage: expected);

            _request.Received().AddParameter("per_page", expected);
        }

        [Fact]
        public async Task Search_SearchQueryIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Search(null));
        }

        [Fact]
        public async Task Search_ValidParameters_AddsSearchParameter()
        {
            const string expected = "search";
            var sut = new UserRepository(_requestFactory);

            await sut.Search(expected);

            _request.Received().AddParameter("search", expected);
        }

        [Fact]
        public async Task Search_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Search("search");

            _requestFactory.Received().Create("users", Method.Get);
        }

        [Fact]
        public async Task Unblock_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Unblock(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Unblock_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Unblock(0);

            _requestFactory.Received().Create("users/{id}/unblock", Method.Put);
        }

        [Fact]
        public async Task Update_AdminIsSet_AddsAdminParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, admin: expected);

            _request.Received().AddParameterIfNotNull("admin", expected);
        }

        [Fact]
        public async Task Update_BioIsSet_AddsBioParameter()
        {
            const string expected = "bio";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, bio: expected);

            _request.Received().AddParameterIfNotNull("bio", expected);
        }

        [Fact]
        public async Task Update_CanCreateGroupIsSet_AddsCanCreateGroupParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, canCreateGroup: expected);

            _request.Received().AddParameterIfNotNull("can_create_group", expected);
        }

        [Fact]
        public async Task Update_EmailIsSet_AddsEmailParameter()
        {
            const string expected = "email";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, expected);

            _request.Received().AddParameterIfNotNull("email", expected);
        }

        [Fact]
        public async Task Update_ExternalIsSet_AddsExternalParameter()
        {
            const bool expected = true;
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, external: expected);

            _request.Received().AddParameterIfNotNull("external", expected);
        }

        [Fact]
        public async Task Update_ExternUidIsSet_AddsExternUidParameter()
        {
            const string expected = "externUid";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, externUid: expected);

            _request.Received().AddParameterIfNotNull("extern_uid", expected);
        }

        [Fact]
        public async Task Update_IsSet_AddsParameter()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, projectsLimit: expected);

            _request.Received().AddParameterIfNotNull("projects_limit", expected);
        }

        [Fact]
        public async Task Update_LinkedInIsSet_AddsLinkedInParameter()
        {
            const string expected = "linkedIn";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, linkedIn: expected);

            _request.Received().AddParameterIfNotNull("linkedin", expected);
        }

        [Fact]
        public async Task Update_LocationIsSet_AddsLocationParameter()
        {
            const string expected = "location";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, location: expected);

            _request.Received().AddParameterIfNotNull("location", expected);
        }

        [Fact]
        public async Task Update_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public async Task Update_PasswordIsSet_AddsPasswordParameter()
        {
            const string expected = "password";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, password: expected);

            _request.Received().AddParameterIfNotNull("password", expected);
        }

        [Fact]
        public async Task Update_ProviderIsSet_AddsProviderParameter()
        {
            const string expected = "provider";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, provider: expected);

            _request.Received().AddParameterIfNotNull("provider", expected);
        }

        [Fact]
        public async Task Update_SkypeIsSet_AddsSkypeParameter()
        {
            const string expected = "skype";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, skype: expected);

            _request.Received().AddParameterIfNotNull("skype", expected);
        }

        [Fact]
        public async Task Update_TwitterIsSet_AddsTwitterParameter()
        {
            const string expected = "twitter";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, twitter: expected);

            _request.Received().AddParameterIfNotNull("twitter", expected);
        }

        [Fact]
        public async Task Update_UsernameIsSet_AddsUsernameParameter()
        {
            const string expected = "username";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, username: expected);

            _request.Received().AddParameterIfNotNull("username", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new UserRepository(_requestFactory);

            await sut.Update(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0);

            _requestFactory.Received().Create("users/{id}", Method.Put);
        }

        [Fact]
        public async Task Update_WebsiteUrlIsSet_AddsWebsiteUrlParameter()
        {
            const string expected = "websiteUrl";
            var sut = new UserRepository(_requestFactory);

            await sut.Update(0, websiteUrl: expected);

            _request.Received().AddParameterIfNotNull("website_url", expected);
        }
    }
}