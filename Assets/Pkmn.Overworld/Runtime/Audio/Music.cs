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
            Debug.Log(interruptedTheme.name);
            SwapClipWith(theme);
        }

        public void ResumeAfterInterruption()
        {
            if (interruptedTheme == null)
                return;
            
            SwapClipWith(interruptedTheme);
            interruptedTheme = null;
        }
        
        public void Play(AudioClip theme)
        {
            CrossFadeWith(theme);
        }

        void SwapClipWith(AudioClip theme)
        {
            SourceToFadeIn().clip = theme;
            SourceToFadeIn().Play();
        }
        
        void CrossFadeWith(AudioClip theme)
        {
            SourceToFadeOut().DOFade(0, 1f).OnComplete(() =>
            {
                SourceToFadeIn().volume = 1;
                SourceToFadeIn().clip = theme;
                SourceToFadeIn().Play();
            });
        }

        AudioSource SourceToFadeIn()
        {
            return GetComponentsInChildren<AudioSource>().First();
        }

        AudioSource SourceToFadeOut()
        {
            return GetComponentsInChildren<AudioSource>().First();
        }
    }
}