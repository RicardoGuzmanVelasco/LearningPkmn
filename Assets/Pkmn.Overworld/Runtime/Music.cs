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
            var sourceToFadeOut = firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().First()
                : GetComponentsInChildren<AudioSource>().Last();
            var sourceToFadeIn = firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().Last()
                : GetComponentsInChildren<AudioSource>().First();
            
            sourceToFadeOut.DOFade(0, 1f);
            sourceToFadeIn.DOFade(1, 1f);
            sourceToFadeIn.clip = theme;
            sourceToFadeIn.Play();
            
            firstIsPlaying = !firstIsPlaying;
        }
    }
}