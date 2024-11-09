using MergeCraft.Core.Data;

namespace MergeCraft.Core.Exceptions
{
    public class LocationOutOfBoundsException : MergeCraftException
    {
        public LocationOutOfBoundsException(
            Location location,
            int width,
            int height)
            : base($"Location {location} out of bounds of {width} x {height}.")
        {
        }
    }
}
