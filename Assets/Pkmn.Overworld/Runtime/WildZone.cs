using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Input>().GetComponent<Turn>().JustTurned += FDsfsdflj;
        }

        static void FDsfsdflj()
        {
            if (FindObjectOfType<World>().Ambush())
                Debug.Log("Un ratolí salvatge va aparèixer!");
        }
    }
}