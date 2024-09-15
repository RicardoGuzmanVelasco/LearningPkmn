using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Repel : MonoBehaviour
    {
        int remainingSteps;

        public bool IsActive => remainingSteps > 0;

        void Awake()
        {
            FindObjectOfType<Red>().GetComponent<Move>().JustMoved += Step;
        }

        public void Spray()
        {
            Debug.Log("Repel sprayed!");
            remainingSteps = 5;
        }

        public void Step()
        {
            if (remainingSteps == 0)
                return;
            
            FadeRepel();
            WoreOffRepel();
        }

        void WoreOffRepel()
        {
            if (remainingSteps == 0)
            {
                FindObjectOfType<Popup>().Say("Repel effect wore off!");                
            }
        }

        void FadeRepel()
        {
            if (remainingSteps > 0)
                remainingSteps--;
            Debug.Log($"Repel steps left: {remainingSteps}");
        }
    }
}