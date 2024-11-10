using System.Collections.Generic;

namespace MergeCraft.Core.IO.Interfaces
{
    public interface IWorkspaceGeneratorConfiguration<T> where T : class, IWorkspaceGeneratorConfigurationIItem
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalWeight { get; set; }
        public List<T> Items { get; }
    }
}
