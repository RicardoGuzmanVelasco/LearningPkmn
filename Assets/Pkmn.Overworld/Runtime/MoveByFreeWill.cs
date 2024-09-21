using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Pkmn.Overworld.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveByFreeWill : MonoBehaviour
{
    [SerializeField] Vector2Int[] route;

    int step = 0;
    
    IEnumerator Start()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            if(!enabled)
                continue;
            
            MoveInRoute();
        }
    }

    void MoveInRoute()
    {
        if(step == route.Length)
            return;
        
        GetComponent<Move>().MoveTowardsIfIdle(route[step]);
        step++;
    }
}
