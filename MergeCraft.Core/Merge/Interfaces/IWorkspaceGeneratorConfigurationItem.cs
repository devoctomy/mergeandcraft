namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceGeneratorConfigurationItem
    {
        public string? Id { get; set; }
        public float Probability { get; set; }
        public int Weight { get; set; }
    }
}
