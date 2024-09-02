using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Music : MonoBehaviour
    {
        bool firstIsPlaying = false;
        
        public bool IsPlaying(AudioClip clip)
            => GetComponentsInChildren<AudioSource>().First().clip == clip || GetComponentsInChildren<AudioSource>().Last().clip == clip; 
        
        public void Play(AudioClip theme)
        {
            var sourceToFadeOut = firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().First()
                : GetComponentsInChildren<AudioSource>().Last();
            var sourceToFadeIn = firstIsPlaying
                ? GetComponentsInChildren<AudioSource>().Last()
                : GetComponentsInChildren<AudioSource>().First();
            
            sourceToFadeOut.DOFade(0, .25f);
            sourceToFadeIn.DOFade(1, .25f);
            sourceToFadeIn.clip = theme;
            sourceToFadeIn.Play();
            
            firstIsPlaying = !firstIsPlaying;
        }
    }
}