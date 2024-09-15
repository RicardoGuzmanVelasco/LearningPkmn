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
        Stack<string> whatToSay = new();
        
        void Awake()
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public bool IsActive => GetComponent<CanvasGroup>().alpha > 0;

        public void Say(params string[] conversation)
        {
            Assert.IsNotNull(conversation);
            
            whatToSay = new(conversation.Reverse());
            
            GetComponentInChildren<TMP_Text>().text = whatToSay.Pop();
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
            Say(whatToSay.Pop());
            GetComponent<AudioSource>().PlayOneShot(okSound);
        }

        void ShutUp()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            FindObjectOfType<Input>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(okSound);
            FindObjectOfType<MasterOfPuppets>().EnableFreeWill();
        }
    }
}