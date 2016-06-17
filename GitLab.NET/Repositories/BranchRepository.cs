using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
	/// <summary> Provides GitLab Branch access in a repository pattern. </summary>
	public class BranchRepository : RepositoryBase
	{
		/// <summary> Creates a new <see cref="BranchRepository" /> instance. </summary>
		/// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
		public BranchRepository(IRequestFactory requestFactory) : base(requestFactory) { }

		/// <summary> Creates a branch. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <param name="branchName"> The name of the new branch. </param>
		/// <param name="refName"> The name of the branch or commit SHA to create the branch from. </param>
		/// <returns> A <see cref="RequestResult{Branch}" /> representing the results of the request. </returns>
		public async Task<RequestResult<Branch>> Create(uint projectId, string branchName, string refName)
		{
			if (branchName == null)
				throw new ArgumentNullException(nameof(branchName));

			if (refName == null)
				throw new ArgumentNullException(nameof(refName));

			var request = RequestFactory.Create("projects/{projectId}/repository/branches", Method.Post);

			request.AddUrlSegment("projectId", projectId);
			request.AddParameter("branch_name", branchName);
			request.AddParameter("ref", refName);

			return await request.Execute<Branch>();
		}

		/// <summary> Deletes a branch. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <param name="branchName"> The name of the branch. </param>
		/// <returns> A <see cref="RequestResult{Branch}" /> representing the results of the request. </returns>
		public async Task<RequestResult<Branch>> Delete(uint projectId, string branchName)
		{
			if (branchName == null)
				throw new ArgumentNullException(nameof(branchName));

			var request = RequestFactory.Create("projects/{projectId}/repository/branches/{branchName}", Method.Delete);

			request.AddUrlSegment("projectId", projectId);
			request.AddUrlSegment("branchName", branchName);

			return await request.Execute<Branch>();
		}

		/// <summary> Gets a branch by its name. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <param name="branchName"> The name of the branch. </param>
		/// <returns> A <see cref="RequestResult{Branch}" /> representing the results of the request. </returns>
		public async Task<RequestResult<Branch>> Find(uint projectId, string branchName)
		{
			if (branchName == null)
				throw new ArgumentNullException(nameof(branchName));

			var request = RequestFactory.Create("projects/{projectId}/repository/branches/{branchName}", Method.Get);

			request.AddUrlSegment("projectId", projectId);
			request.AddUrlSegment("branchName", branchName);

			return await request.Execute<Branch>();
		}

		/// <summary> Gets all branches for the specified project. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <returns>
		///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Branch}" /> representing the results of the
		///     request.
		/// </returns>
		public async Task<RequestResult<List<Branch>>> GetAll(uint projectId)
		{
			var request = RequestFactory.Create("projects/{projectId}/repository/branches", Method.Get);

			request.AddUrlSegment("projectId", projectId);

			return await request.Execute<List<Branch>>();
		}

		/// <summary> Protects a branch. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <param name="branchName"> The name of the branch. </param>
		/// <returns> A <see cref="RequestResult{Branch}" /> representing the results of the request. </returns>
		public async Task<RequestResult<Branch>> Protect(uint projectId, string branchName)
		{
			if (branchName == null)
				throw new ArgumentNullException(nameof(branchName));

			var request = RequestFactory.Create("projects/{projectId}/repository/branches/{branchName}/protect", Method.Put);

			request.AddUrlSegment("projectId", projectId);
			request.AddUrlSegment("branchName", branchName);

			return await request.Execute<Branch>();
		}

		/// <summary> Unprotects a branch. </summary>
		/// <param name="projectId"> The ID of the project. </param>
		/// <param name="branchName"> The name of the branch. </param>
		/// <returns> A <see cref="RequestResult{Branch}" /> representing the results of the request. </returns>
		public async Task<RequestResult<Branch>> Unprotect(uint projectId, string branchName)
		{
			if (branchName == null)
				throw new ArgumentNullException(nameof(branchName));

			var request = RequestFactory.Create("projects/{projectId}/repository/branches/{branchName}/unprotect", Method.Put);

			request.AddUrlSegment("projectId", projectId);
			request.AddUrlSegment("branchName", branchName);

			return await request.Execute<Branch>();
		}
	}
}