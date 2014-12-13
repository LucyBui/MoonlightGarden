using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Utils;

namespace MoonlightGarden.Framework.Domain.IssueTracking
{
    public class Issue : OutputData
    {
        public IssueStatus Status { get; set; }
        public IssueType IssueType { get; set; }
        public string ProjectId { get; set; }
        public string ParentId { get; set; }
        public Issue() { }
        public Issue(string projectId, string parentId)
        {
            this.Status = IssueStatus.Open;
            this.IssueType = parentId.IsNullOrEmpty() ? IssueType.Story : IssueType.Task;
            this.ProjectId = projectId;
            this.ParentId = parentId;
        }
        
        
    }
}