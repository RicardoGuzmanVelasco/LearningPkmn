using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Pkmn.Overworld.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveByFreeWill : MonoBehaviour
{
    IEnumerator Start()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            if(!enabled)
                continue;
            
            GetComponent<Move>().MoveTowardsIfIdle(Vector2Int.left);
        }
    }
}
