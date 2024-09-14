using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pkmn.Overworld.Runtime
{
    public class TurnByFreeWill : MonoBehaviour
    {
        [SerializeField] Vector2Int[] whereabouts = 
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

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

        Vector2Int RandomDirection()
        {
            return whereabouts[Random.Range(0, whereabouts.Length)];
        }
    }
}