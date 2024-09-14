using System;
using UnityEngine;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;

namespace Pkmn.Overworld.Runtime
{
    public class TurnOrMoveInput : MonoBehaviour
    {
        Vector2Int whereIsTryingToMoveTo;
        TimeSpan forHowLongIsTryingToMoveToTheSameDirection;
        
        internal void Handle()
        {
            var direction = WhereToMove();
            if (direction is not null)
                GetComponent<Move>().MoveTowardsIfIdle(direction.Value);
        }

        Vector2Int? WhereToMove()
        {
            if(forHowLongIsTryingToMoveToTheSameDirection < TimeSpan.FromSeconds(0.2))
                return null;
            
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
            Debug.Log(whereIsTryingToMoveTo + " " + forHowLongIsTryingToMoveToTheSameDirection);

            UpdateWhereIsTryingToMoveTo();
            ResetIfJustReleased();
        }

        void ResetIfJustReleased()
        {
            if (!GetKeyUp(UpArrow) && !GetKeyUp(DownArrow) && !GetKeyUp(LeftArrow) && !GetKeyUp(RightArrow))
                return;
            
            whereIsTryingToMoveTo = Vector2Int.zero;
            forHowLongIsTryingToMoveToTheSameDirection = TimeSpan.Zero;
        }

        void UpdateWhereIsTryingToMoveTo()
        {
            if(whereIsTryingToMoveTo == alskdj())
                forHowLongIsTryingToMoveToTheSameDirection += TimeSpan.FromSeconds(Time.deltaTime);
            else
            {
                forHowLongIsTryingToMoveToTheSameDirection = TimeSpan.Zero;
                whereIsTryingToMoveTo = alskdj();
            }
        }

        Vector2Int alskdj()
        {
            return GetKey(UpArrow) ? Vector2Int.up :
                GetKey(DownArrow) ? Vector2Int.down :
                GetKey(LeftArrow) ? Vector2Int.left :
                GetKey(RightArrow) ? Vector2Int.right :
                Vector2Int.zero;
        }
    }
}