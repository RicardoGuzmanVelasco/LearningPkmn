using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        void Awake()
        {
            FindObjectOfType<Turn>().JustTurned += () => FDsfsdflj();
        }

        static void FDsfsdflj()
        {
            if (FindObjectOfType<World>().Encounter())
                Debug.Log("FDsfsdflj");
        }
    }
}