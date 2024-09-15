using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class QaInput : MonoBehaviour
    {
        public void Handle()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                DisableFreeWill();
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
                EnableFreeWill();
        }

        static void EnableFreeWill()
        {
            FindObjectOfType<MasterOfPuppets>().EnableFreeWill();
            LogAbout("Free will enabled");
        }

        static void DisableFreeWill()
        {
            FindObjectOfType<MasterOfPuppets>().DisableFreeWill();
            LogAbout("Free will disabled");
        }
        
        static void LogAbout(string what)
        {
            Debug.Log($"[QA] {what}");
        }
    }
}