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
            FindObjectOfType<Input>().GetComponent<Move>().JustMoved += ChangeThemeIfRedIsHere;
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
            return FindObjectOfType<Input>().GetComponent<Being>().Coords != GetComponent<Being>().Coords;
        }
    }
}