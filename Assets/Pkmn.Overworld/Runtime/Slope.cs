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
                JumpOver();
            else
                GetComponent<IsInTheWorld>().hasMass = true;

            DeDóndeVieneRed = FindObjectOfType<Red>().CoordInFront;
        }

        void JumpOver()
        {
            GetComponent<IsInTheWorld>().hasMass = false;
            FindObjectOfType<Red>().transform.position = FindObjectOfType<Red>().transform.position + Vector3.down;
        }

        bool RedIsAboutToStepIn()
        {
            return FindObjectOfType<Red>().CoordInFront == GetComponent<IsInTheWorld>().Coords;
        }
    }
}