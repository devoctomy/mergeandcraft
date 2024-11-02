namespace MergeCraft.Core.Craft.Interfaces
{
    public interface IComponent
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public MergeRequirement? MergeRequirement { get; set; }
}
}
