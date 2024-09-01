using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Move : MonoBehaviour
    {
        static readonly TimeSpan MovementTick = TimeSpan.FromSeconds(0.25);
        TimeSpan moveCooldown = TimeSpan.Zero;

        void Update()
        {
            moveCooldown -= TimeSpan.FromSeconds(Time.deltaTime);
            if (moveCooldown > TimeSpan.Zero)
                return;

            var directionToMove = WhereToMove();
            if (directionToMove is not null)
                BlockMovementAndMove(directionToMove.Value);
        }

        static Vector2Int? WhereToMove()
        {
            return Input.WhereToMove();
        }

        void BlockMovementAndMove(Vector2Int towards)
        {
            moveCooldown = MovementTick;
            TurnAndMoveTowards(towards);
        }

        void TurnAndMoveTowards(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            transform.position += new Vector3(towards.x, towards.y);
        }
    }
}