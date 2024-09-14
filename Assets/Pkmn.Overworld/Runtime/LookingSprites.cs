using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    [Serializable]
    public struct LookingSprites
    {
        public Sprite up;
        public Sprite down;
        public Sprite left;

        public Sprite Of(Vector2Int direction)
            => direction switch
            {
                _ when direction == Vector2Int.up => up,
                _ when direction == Vector2Int.down => down,
                _ when direction == Vector2Int.left => left,
                _ when direction == Vector2Int.right => left,
                _ => throw new ArgumentOutOfRangeException(direction.ToString())
            };

        public bool MustFlip(Vector2Int direction)
            => direction == Vector2Int.right;
    }
}