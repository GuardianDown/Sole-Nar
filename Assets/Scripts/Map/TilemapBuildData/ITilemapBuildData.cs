using System.Collections.Generic;

namespace SoleNar.Map
{
    public interface ITilemapBuildData
    {
        IReadOnlyCollection<ITile> Tiles { get; }
        int Columns { get; }
        int Rows { get; }
    }
}