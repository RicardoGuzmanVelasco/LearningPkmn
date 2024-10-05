using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pkmn.Overworld.Runtime
{
    internal class Popup : MonoBehaviour
    {
        [SerializeField] AudioClip okSound;
        [SerializeField] AudioClip itemReceivedSound;
        Stack<string> whatToSay = new();
        
        void Awake()
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public bool IsActive => GetComponent<CanvasGroup>().alpha > 0;

        public void Say(params string[] conversation)
        {
            Assert.IsNotNull(conversation);
            Assert.IsTrue(conversation.Length > 0);
            
            whatToSay = new(conversation.Reverse());
            
            UpdateView(whatToSay.Pop());
        }

        void UpdateView(string what)
        {
            if (what.Contains("You received"))
            {
                FindObjectOfType<Music>().PlayInterruptingWithSound(itemReceivedSound);
            }
            
            GetComponentInChildren<TMP_Text>().text = what;
            GetComponent<CanvasGroup>().alpha = 1;
            FindObjectOfType<Input>(true).enabled = false;
            FindObjectOfType<PopupInput>(true).enabled = true;
            FindObjectOfType<MasterOfPuppets>().DisableFreeWill();
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
            UpdateView(whatToSay.Pop());
            GetComponent<AudioSource>().PlayOneShot(okSound);
        }

        void ShutUp()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            FindObjectOfType<Input>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(okSound);
            FindObjectOfType<MasterOfPuppets>().EnableFreeWill();
            
            FindObjectOfType<Music>().ResumeAfterInterruption();
        }
    }
}