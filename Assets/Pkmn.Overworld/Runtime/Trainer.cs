using System;
using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
        [SerializeField] AudioClip challengeTheme;
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += LookForRed;
            GetComponent<Turn>().JustTurned += LookForRed;
        }

        void OnDestroy()
        {
            FindObjectOfType<Red>().JustMoved -= LookForRed;
            GetComponent<Turn>().JustTurned -= LookForRed;
        }

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
            FindObjectOfType<Popup>().Say("Combatem, si us plau!");
            FindObjectOfType<Music>().Play(challengeTheme);
        }
    }
}