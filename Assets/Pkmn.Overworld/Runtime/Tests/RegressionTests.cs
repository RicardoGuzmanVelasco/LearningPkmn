using System.Collections;
using System.Diagnostics.Tracing;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
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
            MoveRedTowards(Vector2Int.down);

            yield return new WaitForSeconds(1f);
            
            Assert.AreEqual(redPositionBefore, red.transform.position);
        }
        
        [UnityTest]
        public IEnumerator RedCanGoUp_InStartingPosition()
        {
            yield return SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Single);

            var red = Object.FindObjectOfType<Red>();
            var redPositionBefore = red.transform.position;
            MoveRedTowards(Vector2Int.up);
            
            yield return new WaitForSeconds(1f);
            
            Assert.That(red.transform.position.y, Is.GreaterThan(redPositionBefore.y));
        }

        [UnityTest]
        public IEnumerator Walk_ForAWhile()
        {
            yield return SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Single);

            for (int i = 0; i < 10; i++)
            {
                MoveRedTowards(RandomDirection());
                yield return new WaitForSeconds(.1f);
            }
            
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator RaiseImminentCombat()
        {
            yield return SceneManager.LoadSceneAsync("OneStepFromCombat", LoadSceneMode.Single);

            var mock = new EventCount();
            Object.FindObjectOfType<FASdfasdf>().IsImminent += mock.OnceMore;
            MoveRedTowards(Vector2Int.left);

            yield return new WaitForSeconds(1f);
            
            mock.AssertTimesWere(1);
        }

        [UnityTest]
        public IEnumerator SingleCombatShouldBeRaised_WhenThereAreTwoTrainers()
        {
            yield return SceneManager.LoadSceneAsync("OneStepFromCombat", LoadSceneMode.Single);

            var mock = new EventCount();
            Object.FindObjectOfType<FASdfasdf>().IsImminent += mock.OnceMore;
            MoveRedTowards(Vector2Int.right);

            yield return new WaitForSeconds(1f);
            
            mock.AssertTimesWere(1);
        }

        static void MoveRedTowards(Vector2Int direction)
        {
            var red = Object.FindObjectOfType<Red>();
            red.GetComponent<Move>().MoveTowardsIfIdle(direction);
        }

        static Vector2Int RandomDirection()
        {
            var random = Random.Range(0, 4);
            return random switch
            {
                0 => Vector2Int.up,
                1 => Vector2Int.down,
                2 => Vector2Int.left,
                3 => Vector2Int.right,
            };
        }
    }
}

class EventCount
{
    public int Count { get; private set; }

    public void OnceMore() => Count++;
    
    public void AssertTimesWere(int howMany) => Assert.AreEqual(howMany, Count);
}