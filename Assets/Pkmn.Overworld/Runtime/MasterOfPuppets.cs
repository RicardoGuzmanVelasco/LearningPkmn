using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class MasterOfPuppets : MonoBehaviour
    {
        public void EnableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = true;
            
            foreach (var moveByFreeWill in FindObjectsOfType<MoveByFreeWill>())
                moveByFreeWill.enabled = true;
        }

        public void DisableFreeWill()
        {
            foreach (var turnByFreeWill in FindObjectsOfType<TurnByFreeWill>())
                turnByFreeWill.enabled = false;
            
            foreach (var moveByFreeWill in FindObjectsOfType<MoveByFreeWill>())
                moveByFreeWill.enabled = false;
        }
    }
}