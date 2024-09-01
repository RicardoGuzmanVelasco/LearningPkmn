using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Input : MonoBehaviour
    {
        void Update()
        {
            HandleMovement();
            HandleTurn();
            HandleRepel();
        }

        void HandleRepel()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                FindObjectOfType<Repel>().Spray();
        }

        void HandleMovement()
        {
            var direction = WhereToMove();
            if(direction is not null)
                GetComponent<Move>().MoveTowardsIfIdle(direction.Value);
        }

        void HandleTurn()
        {
            var direction = WhereToLook();
            if(direction is not null)
                GetComponent<Turn>().LookTowards(direction.Value);
        }

        Vector2Int? WhereToLook()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                return Vector2Int.up;
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                return Vector2Int.down;
            if (UnityEngine.Input.GetKeyDown(KeyCode.A)) 
                return Vector2Int.left;
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                return Vector2Int.right;

            return null;
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