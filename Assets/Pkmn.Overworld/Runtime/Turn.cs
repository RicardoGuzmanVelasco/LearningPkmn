using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pkmn.Overworld.Runtime
{
    public class Turn : MonoBehaviour
    {
        public Vector2Int LookingTowards { get; private set; }
        public Vector2Int LookingAt => GetComponent<IsInTheWorld>().Coords + LookingTowards;

        public event Action AboutToTurn = () => { };
        public event Action JustTurned = () => { };
        
        [SerializeField] LookingSprites sprites;
        [SerializeField] Vector2Int beginLookingAt = Vector2Int.down;
        

        void Start()
        {
            LookTowards(beginLookingAt);
        }

        public void LookTowards(Vector2Int newDirection)
        {
            Debug.Assert(newDirection != Vector2Int.zero, this);
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
            LookTowards(beginLookingAt);
        }
    }
}