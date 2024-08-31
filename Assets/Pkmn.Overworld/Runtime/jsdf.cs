using System;
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
            GetComponentInChildren<SpriteRenderer>().sprite = lookingTowards switch
            {
                Vector2Int v when v == Vector2Int.up => sprites.up,
                Vector2Int v when v == Vector2Int.down => sprites.down,
                Vector2Int v when v == Vector2Int.left => sprites.left,
                Vector2Int v when v == Vector2Int.right => sprites.left,
                _ => throw new ArgumentOutOfRangeException()
            };
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
    
    [Serializable]
    public struct LookingSprites
    {
        public Sprite up;
        public Sprite down;
        public Sprite left;
    }
}