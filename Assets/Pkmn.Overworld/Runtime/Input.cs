using System.Linq;
using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class Input : MonoBehaviour
    {
        void Update()
        {
            HandleDialogue();
            FindObjectOfType<TurnOrMoveInput>().Handle();
            HandleRepel();
            new QaInput().Handle();
        }

        void HandleDialogue()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Space))
                return;

            var inFrontOfRed = FindObjectOfType<Red>().CoordInFront;
            var noActivePopup = FindObjectsOfType<Popup>().All(x => !x.IsActive);
            
            if (noActivePopup)
                SpeakIfAnyone(inFrontOfRed);
        }

        static void SpeakIfAnyone(Vector2Int inFrontOfRed)
        {
            var who = FindObjectOfType<World>().WhoIs(inFrontOfRed);
            if (who is null)
                return;

            var coordsOfNpc = who.Coords;
            var coordsOfRed = FindObjectOfType<Red>().WhereIs;

            who.Reply(coordsOfRed - coordsOfNpc);
        }

        void HandleRepel()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                FindObjectOfType<Repel>().Spray();
        }
    }
}