using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class MergerService : IMergerService<Component>
    {
        public Component Merge(
            Component source,
            Component destination,
            ComponentBom bom)
        {
            if(source.Id == destination.Id)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentException("Components can only be merged with components of the same type.");
            }
        }
    }
}
