using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
        void Update()
        {
            foreach (var something in FindObjectOfType<World>().EverythingAt(GetComponent<Turn>().LookingAt))
            {
                if (something.GetComponent<Red>())
                    Debug.Log("Jo veure Red");
            }
        }
    }
}