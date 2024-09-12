using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pkmn.Overworld.Runtime
{
    public class TurnByFreeWill : MonoBehaviour
    {
        void Awake()
        {
            Debug.Assert(GetComponent<Turn>());
        }

        IEnumerator Start()
        {
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                GetComponent<Turn>().LookTowards(RandomDirection());
            }
        }

        static Vector2Int RandomDirection()
        {
            return Random.Range(0, 4) switch
            {
                0 => Vector2Int.up,
                1 => Vector2Int.down,
                2 => Vector2Int.left,
                3 => Vector2Int.right,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}