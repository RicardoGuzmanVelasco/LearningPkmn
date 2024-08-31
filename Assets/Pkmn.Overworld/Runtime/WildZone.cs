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
            if (Encounter())
                Debug.Log("FDsfsdflj");
        }

        static bool Encounter()
        {
            return Random.Range(0, 100) < 10;
        }
    }
}