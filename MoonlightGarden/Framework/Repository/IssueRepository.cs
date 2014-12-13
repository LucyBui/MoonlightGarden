using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Entity.IssueTracking;
using MoonlightGarden.Platform.Factory;
using MoonlightGarden.Platform.Repository;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Repository
{
    public class IssueRepository : RepositoryBase<IssueData>
    {
        public const string PROJECT = "Project";
        public IssueRepository() : base(AppContext.getBean<IssueContext>()) { }
        public IEnumerable<Project> Projects()
        {
            return Fetch<Project>(item => item.RowKey == PROJECT).Values;
        }
        public Project ProjectById(string id)
        {
            IssueData project = Find(item => item.Id == id && item.RowKey == PROJECT);
            return project == null ? null : project.Clone<Project>();
        }
        public int TotalIssueInProject(string projectId)
        {
            return Count(item => item.RowKey == projectId);
        }
        public IEnumerable<Issue> Issues(string projectId)
        {
            return Fetch<Issue>(item => item.RowKey == projectId).Values;
        }
        public void Save(Project project)
        {
            Save(project.Convert<IssueData>(PROJECT, (string)null));
        }
        public void Save(Issue issue)
        {
            Save(issue.Convert<IssueData>(issue.ProjectId, issue.IssueType));
        }
    }
}