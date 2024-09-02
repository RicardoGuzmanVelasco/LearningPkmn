using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class TownshipToast : MonoBehaviour
    {
        void Start()
        {
            GetComponent<RectTransform>()
                .DOMoveY(200, 1)
                .SetRelative(true)
                .Complete();
        }

        public void WelcomeTo(string where)
        {
            GetComponentInChildren<TMP_Text>().text = where;
            
            GetComponent<RectTransform>().DOComplete();
            GetComponent<RectTransform>()
                .DOMoveY(-200, 1)
                .SetRelative(true)
                .SetEase(Ease.OutQuint)
                .SetLoops(2, LoopType.Yoyo);
        }
    }
}