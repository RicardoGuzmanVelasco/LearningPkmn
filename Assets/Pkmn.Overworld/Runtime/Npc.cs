using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pkmn.Overworld.Runtime
{
    public class Npc : MonoBehaviour, IReply
    {
        [SerializeField] public string[] conversation;

        public void Reply(Vector2Int towards)
        {
            Speak(towards, conversation);
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;

        internal void Speak(Vector2Int towards, string[] whatToSay)
        {
            GetComponent<Turn>().LookTowards(towards);
            FindObjectOfType<Popup>().Say(whatToSay);
        }
    }
}