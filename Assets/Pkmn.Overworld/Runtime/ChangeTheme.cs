using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class ChangeTheme : MonoBehaviour
    {
        [SerializeField] AudioClip theme;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += ChangeThemeIfRedIsHere;
        }

        void ChangeThemeIfRedIsHere()
        {
            if(RedIsNotHere())
                return;

            if (FindObjectOfType<Music>().IsPlaying(theme))
                return;
                
            FindObjectOfType<Music>().Play(theme);
        }

        bool RedIsNotHere()
        {
            return FindObjectOfType<Red>().WhereIs != GetComponent<IsInTheWorld>().Coords;
        }
    }
}