using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public interface IReply
    {
        void Reply(Vector2Int towards);
        Vector2Int Coords { get; }
    }
}