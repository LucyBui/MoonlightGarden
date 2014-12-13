using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Framework.Enumeration;

namespace MoonlightGarden.Framework.Domain.IssueTracking
{
    public class Project : OutputData
    {
        public IssueStatus Status { get; set; }
    }
}