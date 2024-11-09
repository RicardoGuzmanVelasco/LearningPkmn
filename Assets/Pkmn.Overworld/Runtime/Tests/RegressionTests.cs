using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Pkmn.Overworld.Runtime.Tests
{
    public class RegressionTests
    {
        [UnityTest]
        public IEnumerator RedCannotGoDown_InStartingPosition()
        {
            yield return SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Single);

            var red = Object.FindObjectOfType<Red>();
            var redPositionBefore = red.transform.position;
            red.GetComponent<Move>().MoveTowardsIfIdle(Vector2Int.down);
            
            yield return new WaitForSeconds(1f);
            
            Assert.AreEqual(redPositionBefore, red.transform.position);
        }
    }
}