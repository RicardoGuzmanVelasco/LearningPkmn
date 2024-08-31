using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pkmn.Overworld.Runtime
{
    public class Turn : MonoBehaviour
    {
        Vector2Int lookingTowards = Vector2Int.down;

        public event Action JustTurned = () => { };
        
        [SerializeField]
        LookingSprites sprites;

        void Update()
        {
            var newDirection = WhereIsLookingTowards() ?? lookingTowards;
            if (newDirection != lookingTowards)
                JustTurned();
            
            lookingTowards = newDirection;
            ChangeSprite();
        }

        void ChangeSprite()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites.Of(lookingTowards);
            GetComponentInChildren<SpriteRenderer>().flipX = sprites.MustFlip(lookingTowards);
        }

        Vector2Int? WhereIsLookingTowards()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                return Vector2Int.up;
            if (Input.GetKey(KeyCode.DownArrow))
                return Vector2Int.down;
            if (Input.GetKey(KeyCode.LeftArrow)) 
                return Vector2Int.left;
            if (Input.GetKey(KeyCode.RightArrow))
                return Vector2Int.right;

            return null;
        }

    }
}