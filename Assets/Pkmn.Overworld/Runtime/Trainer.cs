﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour, IReply
    {
        [SerializeField] string[] conversation;
        [SerializeField] AudioClip challengeTheme;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += LookForRed;
            GetComponent<Turn>().JustTurned += LookForRed;
            Assert.IsNotNull(GetComponent<Npc>());
        }
        
        void OnDestroy()
        {
            if (FindObjectOfType<Red>())
                FindObjectOfType<Red>().JustMoved -= LookForRed;
            GetComponent<Turn>().JustTurned -= LookForRed;
        }  
        
        public void Reply(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;

        void LookForRed()
        {
            if (ImSeeingRed())
                ChallengeRed();
        }

        bool ImSeeingRed()
        {
            return FindObjectOfType<World>()
                .EverythingAt(GetComponent<Turn>().LookingAt)
                .Any(x => x.GetComponent<Red>());
        }

        void ChallengeRed()
        {
            FindObjectOfType<Popup>().Say(conversation);
            FindObjectOfType<Music>().PlayInterrupting(challengeTheme);
            NotTrainerAnymore();
            FindObjectOfType<FASdfasdf>().ChallengeRed();
        }

        void NotTrainerAnymore()
        {
            Destroy(this);
            GetComponent<Npc>().enabled = true;
        }
    }
}