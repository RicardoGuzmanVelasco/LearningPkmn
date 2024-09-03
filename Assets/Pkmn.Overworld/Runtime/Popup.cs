using TMPro;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Popup : MonoBehaviour
    {
        public void Say(string what)
        {
            GetComponentInChildren<TMP_Text>().text = what;
        }
    }
}