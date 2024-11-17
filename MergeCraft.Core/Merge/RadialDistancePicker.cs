using MergeCraft.Core.Data;
using MergeCraft.Core.Merge.Interfaces;
using System;
using System.Collections.Generic;

namespace MergeCraft.Core.Merge
{
    public class RadialDistancePicker : IRadialDistancePicker
    {
        public Location? PickEmpty(
            MergeWorkspace workspace,
            Location location,
            int radius)
        {
            List<Location> validPositions = new List<Location>();

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int newX = location.X + x;
                    int newY = location.Y + y;

                    if (newX >= 0 && newX < workspace.Width &&
                        newY >= 0 && newY < workspace.Height &&
                        Math.Sqrt(x * x + y * y) <= radius &&
                        !(newX == location.X && newY == location.Y))
                    {
                        Location potentialLocation = new Location(newX, newY);

                        if (workspace.Get(potentialLocation) == null)
                        {
                            validPositions.Add(potentialLocation);
                        }
                    }
                }
            }

            Random random = new Random();
            return validPositions.Count > 0 ?
                validPositions[random.Next(validPositions.Count)] :
                null;
        }
    }
}
