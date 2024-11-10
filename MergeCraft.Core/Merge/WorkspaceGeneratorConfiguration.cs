﻿using MergeCraft.Core.Merge.Interfaces;
using System.Collections.Generic;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorConfiguration : IWorkspaceGeneratorConfiguration<IWorkspaceGeneratorConfigurationItem>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalWeight { get; set; }
        public List<IWorkspaceGeneratorConfigurationItem>? Items { get; set; }
    }
}
