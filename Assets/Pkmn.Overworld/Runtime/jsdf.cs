using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pkmn.Overworld.Runtime
{
    public class jsdf : MonoBehaviour
    {
        Vector2Int lookingTowards = Vector2Int.down;

        [SerializeField]
        LookingSprites sprites;
        
        void Update()
        {
            lookingTowards = WhereIsLookingTowards() ?? lookingTowards;
            ChangeSprite();
        }

        void ChangeSprite()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites.Of(lookingTowards);
            GetComponentInChildren<SpriteRenderer>().flipX = lookingTowards == Vector2Int.right;
        }

        Vector2Int? WhereIsLookingTowards()
        {
            if (Input.GetKey(KeyCode.W))
                return Vector2Int.up;
            if (Input.GetKey(KeyCode.S))
                return Vector2Int.down;
            if (Input.GetKey(KeyCode.A)) 
                return Vector2Int.left;
            if (Input.GetKey(KeyCode.D))
                return Vector2Int.right;

            return null;
        }

    }
}