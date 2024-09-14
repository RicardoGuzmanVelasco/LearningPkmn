﻿using System;
using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Heels : MonoBehaviour
    {
        static readonly Vector3 HeelsHeight = Vector3.one * .5f;

        void Awake()
        {
            PutOnYourHeels();
        }

        void PutOnYourHeels()
        {
            var spritePos = GetComponentsInChildren<SpriteRenderer>().Single().transform;
            spritePos.position += HeelsHeight;
        }
    }
}