using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pkmn.Overworld.Runtime
{
    public class World : MonoBehaviour
    {
        public bool IsAmbushAboutToHappen()
            => Random.Range(0f, 1f) < At(RedCoords()).EncounterChance();

        static Vector2Int RedCoords()
            => FindObjectOfType<Red>().WhereIs;

        Tile At(Vector2Int coords)
            => FindObjectsOfType<Tile>()
                .Single(x => x.GetComponent<Being>().Coords == coords);
 
        public bool IsNavigationable(Vector2Int where)
        {
            var beingsAt = BeingsAt(where);
            return !beingsAt.Any(x => x.GetComponent<Being>().hasMass);
        }

        IEnumerable<Being> BeingsAt(Vector2Int coord)
        {
            return FindObjectsOfType<Being>()
                .Where(x => x.Coords == coord);
        }

        void OnValidate()
        {
            var allTiles = FindObjectsOfType<Tile>()
                .OrderBy(t => t.GetComponent<Being>().Coords.x)
                .ThenBy(t => t.GetComponent<Being>().Coords.y)
                .ToArray();
            for (var i = 0; i < allTiles.Length; i++)
                allTiles[i].transform.SetSiblingIndex(i);
        }
    }
}