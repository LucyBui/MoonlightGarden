using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Platform.Factory;
using System;

namespace MoonlightGarden.Framework.Service
{
    public class IssueService
    {
        private IssueRepository repository = AppContext.getBean<IssueRepository>();
        public Issue GetById(string id)
        {
            return repository.FindOne<Issue>(id);
        }
        public Issue Generate(string projectId, string parentId)
        {
            return new Issue(projectId, parentId);
        }
        public Issue Create(Issue issue)
        {
            int totalIssue = repository.TotalIssueInProject(issue.ProjectId);
            issue.Id = String.Format("{0}-{1}", issue.ProjectId, totalIssue + 1);
            repository.Save(issue);
            return issue;
        }
    }
}