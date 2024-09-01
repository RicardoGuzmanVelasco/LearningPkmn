using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Red>().JustTurned += HandleAmbush;
            FindObjectOfType<Red>().JustMoved += HandleAmbush;
        }

        static void HandleAmbush()
        {
            if (FindObjectOfType<Encounter>().WillHappen())
                Debug.Log("Un ratolí salvatge va aparèixer!");
        }
    }
}