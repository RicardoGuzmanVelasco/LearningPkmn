using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Music : MonoBehaviour
    {
        bool firstIsPlaying = false;
        
        public bool IsPlaying(AudioClip clip)
            => GetComponentsInChildren<AudioSource>()[firstIsPlaying ? 0 : 1].clip == clip; 
        
        public void Play(AudioClip theme)
        {
            CrossFadeWith(theme);
            firstIsPlaying = !firstIsPlaying;
        }

        void CrossFadeWith(AudioClip theme)
        {
            SourceToFadeOut().DOFade(0, 1f);
            
            SourceToFadeIn().DOFade(1, 1f);
            SourceToFadeIn().clip = theme;
            SourceToFadeIn().Play();
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