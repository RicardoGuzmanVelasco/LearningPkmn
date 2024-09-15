using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Poison : MonoBehaviour
    {
        [SerializeField] AudioClip poisonSound;
        [SerializeField] internal bool poisoned;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += FeedbackIfPoisoned;
        }

        void FeedbackIfPoisoned()
        {
            if(poisoned)
                GetComponent<AudioSource>().PlayOneShot(poisonSound);
        }
    }
}