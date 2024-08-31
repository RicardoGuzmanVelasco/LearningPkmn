using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class World : MonoBehaviour
    {
        public bool Encounter()
        {
            return Random.Range(0, 100) < 10;
        }
    }
}