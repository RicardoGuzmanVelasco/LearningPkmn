using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
        void Awake() => FindObjectOfType<Red>().JustMoved += LookForRed;
        void OnDestroy() => FindObjectOfType<Red>().JustMoved -= LookForRed;

        void LookForRed()
        {
            foreach (var something in FindObjectOfType<World>().EverythingAt(GetComponent<Turn>().LookingAt))
            {
                if (something.GetComponent<Red>())
                    Debug.Log("Jo veure Red");
            }
        }
    }
}