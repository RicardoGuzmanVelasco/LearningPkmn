using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Red : MonoBehaviour
    {
        public Vector2Int WhereIs => GetComponent<Being>().Coords;
        
        public event Action JustTurned
        {
            add => GetComponent<Turn>().JustTurned += value;
            remove => GetComponent<Turn>().JustTurned -= value;
        }
        public event Action JustMoved
        {
            add => GetComponent<Move>().JustMoved += value;
            remove => GetComponent<Move>().JustMoved -= value;
        }
    }
}