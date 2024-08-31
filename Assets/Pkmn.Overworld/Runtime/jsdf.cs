using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pkmn.Overworld.Runtime
{
    public class jsdf : MonoBehaviour
    {
        Vector2Int lookingTowards = Vector2Int.down;

        [SerializeField]
        LookingSprites sprites;

        public Vector2Int LookingTowards
        {
            set { lookingTowards = value; }
            get { return lookingTowards; }
        }

        void Update()
        {
            lookingTowards = WhereIsLookingTowards() ?? lookingTowards;
            ChangeSprite();
        }

        void ChangeSprite()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites.Of(lookingTowards);
            GetComponentInChildren<SpriteRenderer>().flipX = sprites.MustFlip(lookingTowards);
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