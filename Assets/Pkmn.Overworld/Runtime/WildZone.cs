using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Input>().GetComponent<Turn>().JustTurned += HandleAmbush;
            FindObjectOfType<Input>().GetComponent<Move>().JustMoved += HandleAmbush;
        }

        static void HandleAmbush()
        {
            if (FindObjectOfType<World>().Ambush())
                Debug.Log("Un ratolí salvatge va aparèixer!");
        }
    }
}