using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Being : MonoBehaviour
    {
        public Vector2Int Coords => EnsureCoords();

        Vector2Int EnsureCoords()
        {
            var coords = transform.position;
            var intCoords = new Vector2Int((int)coords.x, (int)coords.y);
            if (coords.x != intCoords.x || coords.y != intCoords.y)
                throw new NotSupportedException();

            return intCoords;
        }
    }
}