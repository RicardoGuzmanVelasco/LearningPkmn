using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Music : MonoBehaviour
    {
        bool firstIsPlaying = false;
 
        [SerializeField] AudioClip themeToBeginWith;

        void Awake()
        {
            Play(themeToBeginWith);
        }

        public bool IsPlaying(AudioClip clip)
            => GetComponentsInChildren<AudioSource>()[firstIsPlaying ? 0 : 1].clip == clip;

        public void PlayInterrupting(AudioClip theme)
        {
            SwapClipWith(theme);
            firstIsPlaying = !firstIsPlaying;
        }
        public void Play(AudioClip theme)
        {
            CrossFadeWith(theme);
            firstIsPlaying = !firstIsPlaying;
        }

        void SwapClipWith(AudioClip theme)
        {
            SourceToFadeOut().volume = 0;
            SourceToFadeIn().volume = 1;
            
            SourceToFadeIn().clip = theme;
            SourceToFadeIn().Play();
        }
        
        void CrossFadeWith(AudioClip theme)
        {
            SourceToFadeOut().DOFade(0, 1f);

            SourceToFadeIn().volume = 1;
            SourceToFadeIn().clip = theme;
            SourceToFadeIn().PlayDelayed(1);
        }

        AudioSource SourceToFadeIn()
        {
            return firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().Last()
                : GetComponentsInChildren<AudioSource>().First();
        }

        AudioSource SourceToFadeOut()
        {
            return firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().First()
                : GetComponentsInChildren<AudioSource>().Last();
        }
    }
}