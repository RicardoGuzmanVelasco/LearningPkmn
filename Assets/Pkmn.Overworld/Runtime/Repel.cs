using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Repel : MonoBehaviour
    {
        int steps = 0;

        void Awake()
        {
            FindObjectOfType<Input>().GetComponent<Move>().JustMoved += Step;
        }

        public void Spray()
        {
            Debug.Log("Repel sprayed!");
            steps = 5;
        }

        public void Step()
        {
            if (steps > 0)
                steps--;
            Debug.Log($"Repel steps left: {steps}");
        }
    }
}