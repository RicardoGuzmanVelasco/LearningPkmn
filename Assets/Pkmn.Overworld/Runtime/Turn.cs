using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pkmn.Overworld.Runtime
{
    public class Turn : MonoBehaviour
    {
        Vector2Int lookingTowards;

        public event Action JustTurned = () => { };
        
        [SerializeField]
        LookingSprites sprites;

        void Start()
        {
            LookTowards(Vector2Int.down);
        }

        public void LookTowards(Vector2Int newDirection)
        {
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
    }
}