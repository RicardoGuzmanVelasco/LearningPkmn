using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class FASdfasdf : MonoBehaviour
    {
        public event Action IsImminent = () => { };

        public void ChallengeRed()
        {
            IsImminent();
        }
    }
}