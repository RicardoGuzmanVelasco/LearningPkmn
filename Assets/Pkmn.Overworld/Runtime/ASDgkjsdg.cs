using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class ASDgkjsdg : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Turn>().JustTurned += () => Debug.Log("Just turned");
        }
    }
}