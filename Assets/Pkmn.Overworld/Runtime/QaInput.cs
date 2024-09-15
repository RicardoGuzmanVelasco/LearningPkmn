using UnityEngine;

namespace Pkmn.Overworld.Runtime
{
    public class QaInput : MonoBehaviour
    {
        public void Handle()
        {
            HandleFreeWill();
            HandleSpeed();
            HandlePoisonToggle();
        }

        void HandlePoisonToggle()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.V))
                return;

            FindObjectOfType<Poison>().Poisoned = !FindObjectOfType<Poison>().Poisoned;
            LogAbout("poison toggled to " + FindObjectOfType<Poison>().Poisoned);
        }

        static void HandleSpeed()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPlus))
                SpeedUp();
            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadMinus))
                SlowDown();
        }

        static void HandleFreeWill()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                DisableFreeWill();
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
                EnableFreeWill();
        }

        static void SpeedUp()
        {
            Time.timeScale++;
            LogAbout($"Speed up! Time scale: {Time.timeScale}");
        }

        static void SlowDown()
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