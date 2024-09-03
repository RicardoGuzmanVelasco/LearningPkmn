using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] string conversation;

        public void Speak()
        {
            FindObjectOfType<Popup>().Say(conversation);
        }
    }
}