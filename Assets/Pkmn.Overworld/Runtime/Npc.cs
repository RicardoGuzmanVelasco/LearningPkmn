﻿using System;
using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Npc : MonoBehaviour, IReply
    {
        [SerializeField] string[] conversasddtion;

        public void Reply(Vector2Int towards)
        {
            Speak(towards);
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;

        void Speak(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            FindObjectOfType<Popup>().Say(conversasddtion.Single());
        }
    }
}