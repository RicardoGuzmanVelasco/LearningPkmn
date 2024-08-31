using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class World : MonoBehaviour
    {
        public bool Ambush() => 
            PlayerIsOverWildZone() &&
            Random.Range(0, 100) < 10;

        bool PlayerIsOverWildZone() => true;
    }
}