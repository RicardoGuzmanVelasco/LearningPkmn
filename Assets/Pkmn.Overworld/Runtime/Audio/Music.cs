using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Music : MonoBehaviour
    {
        [SerializeField] AudioClip themeToBeginWith;
        AudioClip interruptedTheme;

        void Awake()
        {
            Play(themeToBeginWith);
        }

        public bool IsPlaying(AudioClip clip)
            => CurrentlyPlaying().clip == clip;

        AudioSource CurrentlyPlaying()
        {
            return GetComponentsInChildren<AudioSource>()[0];
        }

        public void PlayInterrupting(AudioClip theme)
        {
            interruptedTheme = CurrentlyPlaying().clip;
            SwapClipWith(theme);
        }
        
        public void PlayInterruptingWithSound(AudioClip itemReceivedSound)
        {
            PlayInterrupting(itemReceivedSound);
            CurrentlyPlaying().loop = false;
        }

        public void ResumeAfterInterruption()
        {
            if (interruptedTheme == null)
                return;
            
            SwapClipWith(interruptedTheme);
            interruptedTheme = null;
            
            CurrentlyPlaying().loop = true;
        }
        
        public void Play(AudioClip theme)
        {
            CrossFadeWith(theme);
        }

        void SwapClipWith(AudioClip theme)
        {
            Source().clip = theme;
            Source().Play();
        }
        
        void CrossFadeWith(AudioClip theme)
        {
            Source().DOFade(0, 1f).OnComplete(() =>
            {
                Source().volume = 1;
                Source().clip = theme;
                Source().Play();
            });
        }

        AudioSource Source()
        {
            return GetComponentsInChildren<AudioSource>().First();
        }
    }
}