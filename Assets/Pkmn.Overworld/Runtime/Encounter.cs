using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Encounter : MonoBehaviour
    {
        public bool WillHappen()
        {
            return FindObjectOfType<World>().Ambush();
        }
    }
}