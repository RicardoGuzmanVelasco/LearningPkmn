using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Input : MonoBehaviour
    {
        void Update()
        {
           var direction = WhereIsLookingTowards();
           if(direction is not null)
               GetComponent<Turn>().LookTowards(direction.Value);
        }
        
        Vector2Int? WhereIsLookingTowards()
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
                return Vector2Int.up;
            if (UnityEngine.Input.GetKey(KeyCode.S))
                return Vector2Int.down;
            if (UnityEngine.Input.GetKey(KeyCode.A)) 
                return Vector2Int.left;
            if (UnityEngine.Input.GetKey(KeyCode.D))
                return Vector2Int.right;

            return null;
        }
    }
}