using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] string conversation;

        public void Speak(Vector2Int towards)
        {
            GetComponent<Turn>().LookTowards(towards);
            Speak();
        }
        public void Speak()
        {
            FindObjectOfType<Popup>().Say(conversation);
        }
    }
}