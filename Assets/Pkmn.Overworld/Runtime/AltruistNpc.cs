using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class AltruistNpc : MonoBehaviour, IReply
    {
        [SerializeField] string itemName;
        
        public void Reply(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            Debug.Log("I'm an altruist NPC, I'm giving you a " + itemName);
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;
    }
}