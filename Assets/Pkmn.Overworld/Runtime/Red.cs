using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Red : MonoBehaviour
    {
        public Vector2Int WhereIs => GetComponent<IsInTheWorld>().Coords;
        public Vector2Int CoordInFront => WhereIs + GetComponent<Turn>().LookingTowards;
        
        public event Action JustTurned
        {
            add => GetComponent<Turn>().AboutToTurn += value;
            remove => GetComponent<Turn>().AboutToTurn -= value;
        }
        public event Action AboutToMove
        {
            add => GetComponent<Move>().AboutToMove += value;
            remove => GetComponent<Move>().AboutToMove -= value;
        }
        public event Action JustMoved
        {
            add => GetComponent<Move>().JustMoved += value;
            remove => GetComponent<Move>().JustMoved -= value;
        }
    }
}