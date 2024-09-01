using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class lkajsdf : MonoBehaviour
    {
        [SerializeField] string theme;
        static string currentTheme;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += ChangeThemeIfRedIsHere;
        }

        void ChangeThemeIfRedIsHere()
        {
            if(RedIsNotHere())
                return;

            if (theme == currentTheme)
                return;
                
            Debug.Log("new song: " + theme);
            currentTheme = theme;
        }

        bool RedIsNotHere()
        {
            return FindObjectOfType<Red>().WhereIs != GetComponent<Being>().Coords;
        }
    }
}