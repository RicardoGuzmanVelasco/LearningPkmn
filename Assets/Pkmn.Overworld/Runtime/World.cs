﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pkmn.Overworld.Runtime
{
    public class World : MonoBehaviour
    {
        public bool IsAmbushAboutToHappen()
            => Random.Range(0f, 1f) < TileAt(RedCoords()).EncounterChance();

        static Vector2Int RedCoords()
            => FindObjectOfType<Red>().WhereIs;

        public Tile TileAt(Vector2Int coords)
            => FindObjectsOfType<Tile>()
                .Single(x => x.GetComponent<IsInTheWorld>().Coords == coords);
 
        public bool IsNavigationable(Vector2Int where)
        {
            return !EverythingAt(where).Any(x => x.GetComponent<IsInTheWorld>().hasMass);
        }
        
        public IEnumerable<Tile> TilesAround(Vector2Int coords)
        {
            return new[]
            {
                coords + Vector2Int.up,
                coords + Vector2Int.down,
                coords + Vector2Int.left,
                coords + Vector2Int.right
            }
            .Select(TileAt);
        }

        public IEnumerable<IsInTheWorld> EverythingAt(Vector2Int coord)
        {
            return FindObjectsOfType<IsInTheWorld>()
                .Where(x => x.Coords == coord);
        }
        
        public Npc WhoIs(Vector2Int coord)
        {
            return EverythingAt(coord)
                .SingleOrDefault(x => x.GetComponent<Npc>() is not null)
                ?.GetComponent<Npc>();
        }

        void OnValidate()
        {
            var allTiles = FindObjectsOfType<Tile>()
                .OrderBy(t => t.Coords.x)
                .ThenBy(t => t.Coords.y)
                .ToArray();
            for (var i = 0; i < allTiles.Length; i++)
                allTiles[i].transform.SetSiblingIndex(i);
        }
    }
}