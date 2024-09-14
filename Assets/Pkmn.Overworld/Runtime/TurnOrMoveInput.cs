using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class TurnOrMoveInput : MonoBehaviour
    {
        internal void HandleMovement()
        {
            var direction = WhereToMove();
            if (direction is not null)
                GetComponent<Move>().MoveTowardsIfIdle(direction.Value);
        }

        static Vector2Int? WhereToMove()
        {
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                return Vector2Int.up;
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
                return Vector2Int.down;
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                return Vector2Int.left;
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                return Vector2Int.right;

            return null;
        }
    }
}