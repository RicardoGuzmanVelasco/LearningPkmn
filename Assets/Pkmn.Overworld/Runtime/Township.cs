using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    internal class Township : MonoBehaviour
    {
        [SerializeField] string mapArea;
        static string currentMapArea = "";
        
        void Awake()
        {
            FindObjectOfType<Red>().JustMoved += ToastIfNewZone;
        }

        void ToastIfNewZone()
        {
            if (RedIsNotHere())
                return;

            if (currentMapArea == mapArea)
                return;

            Debug.Log("Welcome to " + mapArea);
            currentMapArea = mapArea;
        }
        
        bool RedIsNotHere()
        {
            return FindObjectOfType<Red>().WhereIs != GetComponent<IsInTheWorld>().Coords;
        }
    }
}