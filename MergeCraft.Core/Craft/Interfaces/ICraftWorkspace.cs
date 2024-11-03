﻿using MergeCraft.Core.Collections.ReadOnly;
using MergeCraft.Core.Data;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Craft.Interfaces
{
    public interface ICraftWorkspace<T> where T : class?, IWorkspaceItem, IComponent<T>
    {
        public int Width { get; }
        public int Height { get; }
        public ReadOnly2DArray<T?> Workspace { get; }

        bool Put(
            T component,
            Location location);
        bool Move(
            Location from,
            Location to);
    }
}