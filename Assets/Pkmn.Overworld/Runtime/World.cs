using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class World : MonoBehaviour
    {
        public bool Ambush()
            => Random.Range(0f, 1f) < At(RedCoords()).EncounterChance();

        static Vector2Int RedCoords()
            => FindObjectOfType<Runtime.Input>().GetComponent<Being>().Coords;

        Tile At(Vector2Int coords)
            => FindObjectsOfType<Tile>()
                .Single(x => x.GetComponent<Being>().Coords == coords);

        public bool IsNavigationable(Vector2Int where)
        {
            return !BeingsAt(where).Any(x => x.GetComponent<Being>().hasMass);
        }

        IEnumerable<Being> BeingsAt(Vector2Int coord)
        {
            return FindObjectsOfType<Being>()
                .Where(x => x.Coords == coord);
        }
    }
}