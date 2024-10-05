using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class AltruistNpc : MonoBehaviour, IReply
    {
        [SerializeField] string[] conversationBeforeGivingYou;
        [SerializeField] string itemName;
        
        public void Reply(Vector2Int towards)
        {
            var itemMsg = "You received " + itemName + "!";
            var allMsgs = conversationBeforeGivingYou.Concat(new[] {itemMsg});
            GetComponent<Npc>().Speak(towards, allMsgs.ToArray());
            Destroy(this);
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;
    }
}