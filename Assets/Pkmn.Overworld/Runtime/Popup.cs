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

        public void Say(string what)
        {
            GetComponent<CanvasGroup>()
                .DOFade(1, 1)
                .SetEase(Ease.OutQuint)
                .SetLoops(2, LoopType.Yoyo);
            GetComponentInChildren<TMP_Text>().text = what;
        }
    }
}