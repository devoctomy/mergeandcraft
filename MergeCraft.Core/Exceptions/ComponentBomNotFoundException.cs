namespace MergeCraft.Core.Exceptions
{
    public class ComponentBomNotFoundException : MergeCraftException
    {
        public string Id { get; }

        public ComponentBomNotFoundException(string id)
            : base($"Bom not found for component '{id}'.")
        {
            Id = id;
        }
    }
}
