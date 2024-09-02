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
            
            FindObjectOfType<Red>().JustMoved += alsjkf;
        }

        void alsjkf()
        {
            if(RedIsNotHere())
            {
                DeDóndeVieneRed = FindObjectOfType<Red>().WhereIs;
                return;
            }
            
            if(DeDóndeVieneRed - FindObjectOfType<Red>().WhereIs == Vector2Int.down)
                Debug.Log("Subir");
            else if (DeDóndeVieneRed - FindObjectOfType<Red>().WhereIs == Vector2Int.up)
                Debug.Log("Bajar");
            else
                Debug.Log("Vengo de lado");
            DeDóndeVieneRed = FindObjectOfType<Red>().WhereIs;
        }

        bool RedIsNotHere()
        {
            return FindObjectOfType<Red>().WhereIs != GetComponent<IsInTheWorld>().Coords;
        }
    }
}