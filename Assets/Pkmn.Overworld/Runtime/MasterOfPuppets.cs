using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class MasterOfPuppets : MonoBehaviour
    {
        void Awake()
        {
            foreach(var trainer in FindObjectsOfType<Trainer>())
                trainer.JustChallengedRed += DisableFreeWill;
        }

        public void EnableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = true;
        }

        public void DisableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = false;
        }
    }
}