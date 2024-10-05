using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class WildZone : MonoBehaviour
    {
        [SerializeField] AudioClip rattataSound;

        void Awake()
        {
            FindObjectOfType<Red>().JustTurned += HandleAmbush;
            FindObjectOfType<Red>().JustMoved += HandleAmbush;
        }

        void HandleAmbush()
        {
            if (FindObjectOfType<Encounter>().WillHappen())
            {
                GetComponent<AudioSource>().clip = rattataSound;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}