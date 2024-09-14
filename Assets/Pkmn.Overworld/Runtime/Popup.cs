using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Popup : MonoBehaviour
    {
        [SerializeField] AudioClip okSound;
        Stack<string> whatToSay = new();
        
        void Awake()
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public bool IsActive => GetComponent<CanvasGroup>().alpha > 0;

        public void Say(string what)
        {
            GetComponentInChildren<TMP_Text>().text = what;
            GetComponent<CanvasGroup>().alpha = 1;

            FindObjectOfType<Input>().enabled = false;
        }
        
        public void Say(string[] conversation)
        {
            whatToSay = new(conversation.Reverse());
            
            GetComponentInChildren<TMP_Text>().text = whatToSay.Pop();
            GetComponent<CanvasGroup>().alpha = 1;
            FindObjectOfType<Input>(true).enabled = false;
        }

        public void SayMoreOrShutUp()
        {
            if (whatToSay.Any())
                SayMore();
            else
                ShutUp();
            
        }

        void SayMore()
        {
            Say(whatToSay.Pop());
            GetComponent<AudioSource>().PlayOneShot(okSound);
        }

        void ShutUp()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            FindObjectOfType<Input>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(okSound);
        }
    }
}