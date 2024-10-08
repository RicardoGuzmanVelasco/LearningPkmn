﻿using System;
using System.Threading.Tasks;
using UnityEngine;
    
namespace Pkmn.Overworld.Runtime
{
    public class Move : MonoBehaviour
    {
        static readonly TimeSpan MovementTick = TimeSpan.FromSeconds(.333f);
        TimeSpan moveCooldown = TimeSpan.Zero;
        
        public event Action AboutToMove = () => {};
        public event Action JustMoved = () => {};
        public event Action CouldNotAdvance = () => {};
        
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
            AboutToMove.Invoke();

            if(FindObjectOfType<World>().IsNavigationable(Destiny(towards)))
                MoveTo(towards);
            else
                CouldNotAdvance();   
        }

        async void MoveTo(Vector2Int towards)
        {
            transform.position += new Vector3(towards.x, towards.y);
            //Cuando haya animación hay que esperar a la animación antes del evento.
            JustMoved.Invoke();
        }

        Vector2Int Destiny(Vector2Int fadsfasdf)
            => new((int)transform.position.x + fadsfasdf.x, (int)transform.position.y + fadsfasdf.y);
    }
}