using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class RedAudioFeedback : MonoBehaviour
    {
        [SerializeField] AudioClip couldNotAdvance;
        void Awake()
        {
            GetComponent<Move>().CouldNotAdvance += () => GetComponent<AudioSource>().PlayOneShot(couldNotAdvance);
        }
    }
}