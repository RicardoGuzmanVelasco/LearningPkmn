using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Pkmn.Overworld.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveByFreeWill : MonoBehaviour
{
    [SerializeField] Vector2Int[] route;

    List<Vector2Int> currentRoute;
    int step = 0;

    Vector2Int NextStep => currentRoute[step];

    IEnumerator Start()
    {
        currentRoute = new(route);
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
        if(step == currentRoute.Count)
        {
            step = 0;
            currentRoute = new(currentRoute.Select(x => x * -1).Reverse());
        }

        if (!GetComponent<Move>().CanMove(NextStep))
            return;
        
        GetComponent<Move>().MoveTowardsIfIdle(NextStep);
        step++;
    }
}
