using NSubstitute;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
    public class GitLabSettingsRepositoryTests
    {
        public GitLabSettingsRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
            _sut = new GitLabSettingsRepository(_requestFactory);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;
        private readonly GitLabSettingsRepository _sut;

        [Test]
        public async Task Get_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.Get();

            _requestFactory.Received().Create("application/settings", Method.Get);
        }

        [Test]
        public async Task Set_AfterSignOutPathIsSet_AddsAfterSignOutPathParameter()
        {
            const string expected = "afterSignOutPath";

            await _sut.Set(afterSignOutPath: expected);

            _request.Received().AddParameterIfNotNull("after_sign_out_path", expected);
        }

        [Test]
        public async Task Set_DefaultBranchProtectionIsSet_AddsDefaultBranchProtectionParameter()
        {
            const uint expected = 0;

            await _sut.Set(defaultBranchProtection: expected);

            _request.Received().AddParameterIfNotNull("default_branch_protection", expected);
        }

        [Test]
        public async Task Set_DefaultProjectVisibilityIsSet_AddsDefaultProjectVisibilityParameter()
        {
            const uint expected = 0;

            await _sut.Set(defaultProjectVisibility: expected);

            _request.Received().AddParameterIfNotNull("default_project_visibility", expected);
        }

        [Test]
        public async Task Set_DefaultProjectsLimitIsSet_AddsDefaultProjectsLimitParameter()
        {
            const uint expected = 0;

            await _sut.Set(defaultProjectsLimit: expected);

            _request.Received().AddParameterIfNotNull("default_projects_limit", expected);
        }

        [Test]
        public async Task Set_DefaultSnippetVisibilityIsSet_AddsDefaultSnippetVisibilityParameter()
        {
            const uint expected = 0;

            await _sut.Set(defaultSnippetVisibility: expected);

            _request.Received().AddParameterIfNotNull("default_snippet_visibility", expected);
        }

        [Test]
        public async Task Set_GravatarEnabledIsSet_AddsGravatarEnabledParameter()
        {
            const bool expected = true;

            await _sut.Set(gravatarEnabled: expected);

            _request.Received().AddParameterIfNotNull("gravatar_enabled", expected);
        }

        [Test]
        public async Task Set_HomePageUrlIsSet_AddsHomePageUrlParameter()
        {
            const string expected = "homePageUrl";

            await _sut.Set(homePageUrl: expected);

            _request.Received().AddParameterIfNotNull("home_page_url", expected);
        }

        [Test]
        public async Task Set_MaxAttachmentSizeIsSet_AddsMaxAttachmentSizeParameter()
        {
            const uint expected = 0;

            await _sut.Set(maxAttachmentSize: expected);

            _request.Received().AddParameterIfNotNull("max_attachment_size", expected);
        }

        [Test]
        public async Task Set_RestrictedSignupDomainsIsSet_AddsRestrictedSignupDomainsParameter()
        {
            var expected = new[]
            {
                "domain1",
                "domain2"
            };

            await _sut.Set(restrictedSignupDomains: expected);

            _request.Received().AddParameterIfNotNull("restricted_signup_domains", expected);
        }

        [Test]
        public async Task Set_RestrictedVisbilityLevelsIsSet_AddsRestrictedVisibilityLevelsParameter()
        {
            var expected = new uint[]
            {
                0,
                1
            };

            await _sut.Set(restrictedVisbilityLevels: expected);

            _request.Received().AddParameterIfNotNull("restricted_visibility_levels", expected);
        }

        [Test]
        public async Task Set_SessionExpireDelayIsSet_AddsSessionExpireDelayParameter()
        {
            const uint expected = 0;

            await _sut.Set(sessionExpireDelay: expected);

            _request.Received().AddParameterIfNotNull("session_expire_delay", expected);
        }

        [Test]
        public async Task Set_SigninTextIsSet_AddsSignInTextParameter()
        {
            const string expected = "signinText";

            await _sut.Set(signinText: expected);

            _request.Received().AddParameterIfNotNull("sign_in_text", expected);
        }

        [Test]
        public async Task Set_SigninEnabledIsSet_AddsSigninEnabledParameter()
        {
            const bool expected = true;

            await _sut.Set(signinEnabled: expected);

            _request.Received().AddParameterIfNotNull("signin_enabled", expected);
        }

        [Test]
        public async Task Set_SignupEnabledIsSet_AddsSignupEnabledParameter()
        {
            const bool expected = true;

            await _sut.Set(signupEnabled: expected);

            _request.Received().AddParameterIfNotNull("signup_enabled", expected);
        }

        [Test]
        public async Task Set_UserOauthApplicationsIsSet_AddsUserOauthApplicationsParameter()
        {
            const bool expected = true;

            await _sut.Set(userOauthApplications: expected);

            _request.Received().AddParameterIfNotNull("user_oauth_applications", expected);
        }

        [Test]
        public async Task Set_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.Set();

            _requestFactory.Received().Create("application/settings", Method.Put);
        }
    }
}
