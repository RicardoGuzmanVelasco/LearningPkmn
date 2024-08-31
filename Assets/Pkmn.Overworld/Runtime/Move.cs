using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Move : MonoBehaviour
    {
        TimeSpan moveCooldown = TimeSpan.Zero;
        
        void Update()
        {
            moveCooldown -= TimeSpan.FromSeconds(Time.deltaTime);
            if (moveCooldown > TimeSpan.Zero)
                return;
            
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                MoveTo(Vector2Int.up);
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
                MoveTo(Vector2Int.down);
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                MoveTo(Vector2Int.left);
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                MoveTo(Vector2Int.right);
        }

        void MoveTo(Vector2Int towards)
        {
            moveCooldown = TimeSpan.FromSeconds(0.5);
            TurnAndMoveTowards(towards);
        }

        void TurnAndMoveTowards(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            transform.position += new Vector3(towards.x, towards.y);
        }
    }
}