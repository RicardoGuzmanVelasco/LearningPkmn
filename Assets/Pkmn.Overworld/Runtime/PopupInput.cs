using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class PopupInput : MonoBehaviour
    {
        void Awake()
        {
            enabled = false;
        }

        void Update()
        {
            HandlePopup();
        }

        void HandlePopup()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Space))
                return;

            if(FindObjectOfType<Popup>().IsActive)
                FindObjectOfType<Popup>().SayMoreOrShutUp();
        }
    }
}