using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class AltruistNpc : MonoBehaviour, IReply
    {
        public void Reply(Vector2Int towards)
        {
            Debug.Log("doy destello");
        }

        public Vector2Int Coords => GetComponent<IsInTheWorld>().Coords;
    }
}