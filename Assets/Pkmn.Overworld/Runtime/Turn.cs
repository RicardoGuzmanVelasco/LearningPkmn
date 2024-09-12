using System;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Turn : MonoBehaviour
    {
        public Vector2Int LookingTowards { get; private set; }
        public Vector2Int LookingAt => GetComponent<IsInTheWorld>().Coords + LookingTowards;

        public event Action AboutToTurn = () => { };
        public event Action JustTurned = () => { };
        
        [SerializeField]
        LookingSprites sprites;

        void Start()
        {
            LookTowards(Vector2Int.down);
        }

        public void LookTowards(Vector2Int newDirection)
        {
            if (newDirection == LookingTowards)
                return;
            
            AboutToTurn();
            LookingTowards = newDirection;
            ChangeSprite();
            JustTurned();
        }

        void ChangeSprite()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites.Of(LookingTowards);
            GetComponentInChildren<SpriteRenderer>().flipX = sprites.MustFlip(LookingTowards);
        }

        void OnValidate()
        {
            LookTowards(Vector2Int.down);
        }
    }
}