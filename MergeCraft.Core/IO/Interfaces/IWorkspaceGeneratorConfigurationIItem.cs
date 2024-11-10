namespace MergeCraft.Core.IO.Interfaces
{
    public interface IWorkspaceGeneratorConfigurationIItem
    {
        public string? Id { get; set; }
        public float Probability { get; set; }
        public int Weight { get; set; }
    }
}
