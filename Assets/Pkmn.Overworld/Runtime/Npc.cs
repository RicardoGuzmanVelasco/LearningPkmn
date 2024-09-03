using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] string conversation;
        
        public override string ToString()
        {
            return name;
        }

        public void Speak()
        {
            FindObjectOfType<Popup>().Say(conversation);
        }
    }
}