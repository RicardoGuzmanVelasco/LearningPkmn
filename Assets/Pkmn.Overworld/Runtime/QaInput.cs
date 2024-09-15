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

            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPlus))
                SpeedUp();
            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadMinus))
                SlowDown();
        }

        void SpeedUp()
        {
            Time.timeScale++;
            LogAbout($"Speed up! Time scale: {Time.timeScale}");
        }
        
        void SlowDown()
        {
            Time.timeScale--;
            LogAbout($"Slow down! Time scale: {Time.timeScale}");
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