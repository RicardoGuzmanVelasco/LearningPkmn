using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Slope : MonoBehaviour
    {
        Vector2Int DeDóndeVieneRed;

        void Awake()
        {
            DeDóndeVieneRed = FindObjectOfType<Red>().WhereIs;

            FindObjectOfType<Red>().AboutToMove += sdgasdgasdg;
        }

        void sdgasdgasdg()
        {
            if (!RedIsAboutToStepIn())
            {
                DeDóndeVieneRed = FindObjectOfType<Red>().CoordInFront;
                return;
            }

            if (DeDóndeVieneRed - FindObjectOfType<Red>().CoordInFront == Vector2Int.down)
                GetComponent<IsInTheWorld>().hasMass = true;
            else if (DeDóndeVieneRed - FindObjectOfType<Red>().CoordInFront == Vector2Int.up)
                GetComponent<IsInTheWorld>().hasMass = false;
            else
                GetComponent<IsInTheWorld>().hasMass = true;

            DeDóndeVieneRed = FindObjectOfType<Red>().CoordInFront;
        }

        bool RedIsAboutToStepIn()
        {
            return FindObjectOfType<Red>().CoordInFront == GetComponent<IsInTheWorld>().Coords;
        }
    }
}