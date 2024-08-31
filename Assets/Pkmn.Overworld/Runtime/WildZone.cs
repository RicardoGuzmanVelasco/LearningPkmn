using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Turn>().JustTurned += () => Debug.Log("Just turned");
        }
    }
}