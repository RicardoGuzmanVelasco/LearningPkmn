using System;
using UnityEngine;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;

namespace Pkmn.Overworld.Runtime
{
    public class TurnOrMoveInput : MonoBehaviour
    {
        Vector2Int whereIsTryingToMoveTo;
        internal void Handle()
        {
            var direction = WhereToMove();
            if (direction is not null)
                GetComponent<Move>().MoveTowardsIfIdle(direction.Value);
        }

        static Vector2Int? WhereToMove()
        {
            if (GetKey(UpArrow))
                return Vector2Int.up;
            if (GetKey(DownArrow))
                return Vector2Int.down;
            if (GetKey(LeftArrow))
                return Vector2Int.left;
            if (GetKey(RightArrow))
                return Vector2Int.right;

            return null;
        }

        void Update()
        {
            Debug.Log(whereIsTryingToMoveTo);

            UpdateWhereIsTryingToMoveTo();
            ResetIfJustReleased();
        }

        void ResetIfJustReleased()
        {
            if(GetKeyUp(UpArrow) || GetKeyUp(DownArrow) || GetKeyUp(LeftArrow) || GetKeyUp(RightArrow))
                whereIsTryingToMoveTo = Vector2Int.zero;
        }

        void UpdateWhereIsTryingToMoveTo()
        {
            if (GetKey(UpArrow))
                whereIsTryingToMoveTo = Vector2Int.up;
            else if (GetKey(DownArrow))
                whereIsTryingToMoveTo = Vector2Int.down;
            else if (GetKey(LeftArrow))
                whereIsTryingToMoveTo = Vector2Int.left;
            else if (GetKey(RightArrow))
                whereIsTryingToMoveTo = Vector2Int.right;
        }
    }
}