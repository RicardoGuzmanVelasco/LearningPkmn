using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
        void Awake()
        {
            var imin = GetComponent<IsInTheWorld>().Coords;
            var imlookingat = GetComponent<Turn>().LookingTowards;
            var infrontOf = FindObjectOfType<World>().EverythingAt(imin + imlookingat);
            
            foreach (var something in infrontOf)
            {
                Debug.Log(something);
            }
        }
    }
}