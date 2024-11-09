using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class FASdfasdf : MonoBehaviour
    {
        bool challenged = false;
        public event Action IsImminent = () => { };

        public void ChallengeRed()
        {
            if (challenged)
                return;
            challenged = true;
            
            IsImminent();
        }
    }
}