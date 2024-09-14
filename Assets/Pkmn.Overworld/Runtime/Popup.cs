using System;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Popup : MonoBehaviour
    {
        [SerializeField] AudioClip okSound;
        
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
            GetComponentInChildren<TMP_Text>().text = conversation.First();
            GetComponent<CanvasGroup>().alpha = 1;

            FindObjectOfType<Input>().enabled = false;
        }

        public void ShutUp()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            FindObjectOfType<Input>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(okSound);
        }
    }
}