﻿using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
     public class AudioFeedback : MonoBehaviour
    {
        [SerializeField] AudioClip couldNotAdvance;
        
        void Awake()
        {
            GetComponent<Move>().CouldNotAdvance += Play(couldNotAdvance);
        }

        Action Play(AudioClip sound)
        {
            return () => GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}