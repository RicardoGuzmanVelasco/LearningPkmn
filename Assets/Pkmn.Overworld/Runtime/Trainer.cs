using System;
using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Trainer : MonoBehaviour
    {
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
            Debug.Log("jaklsjdf");
        }
    }
}