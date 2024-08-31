using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] bool isHighGrass;
        public bool IsWildZone => isHighGrass;

        public float EncounterChance() => isHighGrass ? 0.1f : 0;
    }
}