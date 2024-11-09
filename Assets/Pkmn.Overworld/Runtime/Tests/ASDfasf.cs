using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Pkmn.Overworld.Runtime.Tests
{
    public class ASDfasf
    {
        [UnityTest]
        public IEnumerator ASDfssssasDF()
        {
            yield return SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Single);
            Assert.IsNotNull(Object.FindObjectOfType<Red>());
        }
    }
}