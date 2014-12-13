using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Entity.IssueTracking;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Platform.Factory;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Service
{
    public class ProjectService
    {
        private IssueRepository repository = AppContext.getBean<IssueRepository>();
        public IEnumerable<Project> All()
        {
            return repository.Projects();
        }
        public Project GetById(string id)
        {
            return repository.ProjectById(id);
        }
        public IEnumerable<Issue> GetIssues(string projectId)
        {
            return repository.Issues(projectId);
        }
        public Project Create(Project project)
        {
            repository.Save(project);
            return project;
        }
    }
}