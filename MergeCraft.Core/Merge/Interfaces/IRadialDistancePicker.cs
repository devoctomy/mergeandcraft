using MergeCraft.Core.Data;

namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IRadialDistancePicker
    {
        public Location? PickEmpty(
            MergeWorkspace workspace,
            Location location,
            int radius);
    }
}
