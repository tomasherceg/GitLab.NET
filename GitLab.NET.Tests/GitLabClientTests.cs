using System;
using NUnit.Framework;

namespace GitLab.NET.Tests
{
	public class GitLabClientTests
	{
		private static readonly Uri ValidHostUri = new Uri("https://host.com");

		[Test]
		public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new GitLabClient(null));
		}

		[Test]
		public void Constructor_ValidParameters_SetsBranches()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Branches);
		}

		[Test]
		public void Constructor_ValidParameters_SetsBuilds()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Builds);
		}

		[Test]
		public void Constructor_ValidParameters_SetsBuildTriggers()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.BuildTriggers);
		}

		[Test]
		public void Constructor_ValidParameters_SetsBuildVariables()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.BuildVariables);
		}

		[Test]
		public void Constructor_ValidParameters_SetsCommits()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Commits);
		}

		[Test]
		public void Constructor_ValidParameters_SetsDeployKeys()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.DeployKeys);
		}

		[Test]
		public void Constructor_ValidParameters_SetsEmails()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Emails);
		}

		[Test]
		public void Constructor_ValidParameters_SetsFiles()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Files);
		}

		[Test]
		public void Constructor_ValidParameters_SetsGitLabLicense()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.GitLabLicense);
		}

		[Test]
		public void Constructor_ValidParameters_SetsGitLabSettings()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.GitLabSettings);
		}

		[Test]
		public void Constructor_ValidParameters_SetsIssues()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Issues);
		}

		[Test]
		public void Constructor_ValidParameters_SetsKeys()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Keys);
		}

		[Test]
		public void Constructor_ValidParameters_SetsLabels()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Labels);
		}

		[Test]
		public void Constructor_ValidParameters_SetsLicenses()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Licenses);
		}

		[Test]
		public void Constructor_ValidParameters_SetsMergeRequests()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.MergeRequests);
		}

		[Test]
		public void Constructor_ValidParameters_SetsMilestones()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Milestones);
		}

		[Test]
		public void Constructor_ValidParameters_SetsNamespaces()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Namespaces);
		}

		[Test]
		public void Constructor_ValidParameters_SetsProjectSnippets()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.ProjectSnippets);
		}

		[Test]
		public void Constructor_ValidParameters_SetsRepositories()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Repositories);
		}

		[Test]
		public void Constructor_ValidParameters_SetsRunners()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Runners);
		}

		[Test]
		public void Constructor_ValidParameters_SetsSession()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Session);
		}

		[Test]
		public void Constructor_ValidParameters_SetsSystemHooks()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.SystemHooks);
		}

		[Test]
		public void Constructor_ValidParameters_SetsTags()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Tags);
		}

		[Test]
		public void Constructor_ValidParameters_SetsUsers()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.NotNull(sut.Users);
		}

		[Test]
		public void PrivateToken_ReturnsCorrectValue()
		{
			const string privateToken = "privateToken";
			var sut = new GitLabClient(ValidHostUri)
			{
				PrivateToken = privateToken
			};

			Assert.AreEqual(privateToken, sut.PrivateToken);
		}

		[Test]
		public void SetPrivateToken_ValueIsNull_ThrowsArgumentNullException()
		{
			var sut = new GitLabClient(ValidHostUri);

			Assert.Throws<ArgumentNullException>(() => sut.PrivateToken = null);
		}
	}
}