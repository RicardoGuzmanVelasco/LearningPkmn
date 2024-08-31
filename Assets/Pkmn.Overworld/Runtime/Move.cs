using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Move : MonoBehaviour
    {
        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
                MoveTo(Vector2Int.up);
            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
                MoveTo(Vector2Int.down);
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                MoveTo(Vector2Int.left);
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                MoveTo(Vector2Int.right);
        }

        void MoveTo(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            transform.position += new Vector3(towards.x, towards.y);
        }
    }
}