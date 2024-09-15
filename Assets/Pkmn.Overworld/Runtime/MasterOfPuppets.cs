using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class MasterOfPuppets : MonoBehaviour
    {
        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                DisableFreeWill();
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
                EnableFreeWill();
        }

        void EnableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = true;
            LogAbout("Free will enabled");
        }

        void DisableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = false;
            LogAbout("Free will disabled");
        }

        void LogAbout(string msg)
        {
            Debug.Log($"[MasterOfPuppets] {msg}");
        }

    }
}