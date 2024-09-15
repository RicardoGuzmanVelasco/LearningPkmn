using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
            if (PoisonMakesEffectNow())
                MakePoisonEffect();
        }

        void MakePoisonEffect()
        {
            GetComponent<AudioSource>().PlayOneShot(poisonSound);
            FindObjectsOfType<Image>().Single(x => x.name == "PoisonEffect").DOFade(1, .0825f).SetLoops(4, LoopType.Yoyo);
        }

        bool PoisonMakesEffectNow()
        {
            return currentCooldown % PoisonCooldownSteps == 0;
        }
    }
}