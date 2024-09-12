using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
        void Awake()
        {
            foreach (var something in FindObjectOfType<World>().EverythingAt(GetComponent<Turn>().LookingAt))
            {
                Debug.Log(something);
            }
        }
    }
}