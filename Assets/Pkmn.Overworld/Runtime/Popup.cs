using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Popup : MonoBehaviour
    {
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

        public void ShutUp()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            FindObjectOfType<Input>().enabled = true;
        }
    }
}