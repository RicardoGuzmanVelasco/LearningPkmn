using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Poison : MonoBehaviour
    {
        const int PoisonCooldownSteps = 4;
        int currentCooldown;
        
        [SerializeField] AudioClip poisonSound;
        internal bool Poisoned;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += FeedbackIfPoisoned;
        }

        void FeedbackIfPoisoned()
        {
            if (!Poisoned)
                return;

            currentCooldown++;
            
            if (currentCooldown % PoisonCooldownSteps == 0)
                GetComponent<AudioSource>().PlayOneShot(poisonSound);
        }
    }
}