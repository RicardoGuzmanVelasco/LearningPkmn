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