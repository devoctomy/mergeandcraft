namespace MergeCraft.Core.Exceptions
{
    public class MergeWorkspaceNotInitialisedException : MergeCraftException
    {
        public MergeWorkspaceNotInitialisedException()
            : base("MergeWorkspace must be initialised before use.")
        {
        }
    }
}
