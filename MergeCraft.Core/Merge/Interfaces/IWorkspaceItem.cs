using System;
using System.Collections.Generic;
using System.Text;

namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceItem
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
