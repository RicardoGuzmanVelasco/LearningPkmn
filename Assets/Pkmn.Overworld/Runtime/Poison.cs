using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Poison : MonoBehaviour
    {
        [SerializeField] internal bool poisoned;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += FeedbackIfPoisoned;
        }

        void FeedbackIfPoisoned()
        {
            if(poisoned)
                Debug.Log("tktk");
        }
    }
}