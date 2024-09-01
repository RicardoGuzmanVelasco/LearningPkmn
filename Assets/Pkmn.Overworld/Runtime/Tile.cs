using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] bool isHighGrass;
        
        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords; 

        public float EncounterChance() => isHighGrass ? 0.1f : 0;

        void OnValidate()
        {
            name = GetComponent<IsInTheWorld>().Coords.ToString();
        }
    }
}