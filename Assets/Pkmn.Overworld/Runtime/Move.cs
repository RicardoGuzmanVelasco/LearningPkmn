﻿using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Move : MonoBehaviour
    {
        static readonly TimeSpan MovementTick = TimeSpan.FromSeconds(0.25);
        TimeSpan moveCooldown = TimeSpan.Zero;
        
        public event Action JustMoved = () => {};
        
        public void MoveTowardsIfIdle(Vector2Int direction)
        {
            moveCooldown -= TimeSpan.FromSeconds(Time.deltaTime);
            if (moveCooldown > TimeSpan.Zero)
                return;
            
            BlockMovementAndMove(direction);
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
            JustMoved();

            if(!FindObjectOfType<World>().IsNavigationable(ADfjk(towards)))
                Debug.Log("hhhnng");
        }
        
        Vector2Int ADfjk(Vector2Int fadsfasdf)
        {
            return new Vector2Int((int)transform.position.x + fadsfasdf.x, (int)transform.position.y + fadsfasdf.y);
        }
    }
}