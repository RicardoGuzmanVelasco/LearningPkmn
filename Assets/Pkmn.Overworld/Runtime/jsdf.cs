using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pkmn.Overworld.Runtime
{
    public class jsdf : MonoBehaviour
    {
        void Update()
        {
            var direction = WhereIsLookingTowards();
            
            Debug.Log(direction);
        }

        Vector2Int WhereIsLookingTowards()
        {
            if (Input.GetKey(KeyCode.W))
                return Vector2Int.up;
            if (Input.GetKey(KeyCode.S))
                return Vector2Int.down;
            if (Input.GetKey(KeyCode.A)) 
                return Vector2Int.left;
            if (Input.GetKey(KeyCode.D))
                return Vector2Int.right;
            
            return Vector2Int.zero;
        }
    }
}