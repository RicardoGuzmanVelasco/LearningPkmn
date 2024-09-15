using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class MasterOfPuppets : MonoBehaviour
    {
        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                klasdf();
        }

        void klasdf()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = false;
        }
    }
}