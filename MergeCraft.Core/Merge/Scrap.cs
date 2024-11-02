﻿using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class Scrap : IWorkspaceItem, IScrap
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
