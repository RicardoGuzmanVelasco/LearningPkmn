﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pkmn.Overworld.Runtime
{
    public class Input : MonoBehaviour
    {
        void Update()
        {
            HandleDialogue();
            HandleMovement();
            HandleTurn();
            HandleRepel();
        }

        void HandleDialogue()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Space))
                return;

            var inFrontOfRed = FindObjectOfType<Red>().CoordInFront;
            SpeakIfAnyone(inFrontOfRed);
        }

        static void SpeakIfAnyone(Vector2Int inFrontOfRed)
        {
            var who = FindObjectOfType<World>().WhoIs(inFrontOfRed);
            if (who is null)
                return;

            var coordsOfNpc = who.GetComponent<IsInTheWorld>().Coords;
            var coordsOfRed = FindObjectOfType<Red>().WhereIs;

            who.Speak(coordsOfRed - coordsOfNpc);
        }

        void HandleRepel()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                FindObjectOfType<Repel>().Spray();
        }

        void HandleMovement()
        {
            var direction = WhereToMove();
            if (direction is not null)
                GetComponent<Move>().MoveTowardsIfIdle(direction.Value);
        }

        void HandleTurn()
        {
            var direction = WhereToLook();
            if (direction is not null)
                GetComponent<Turn>().LookTowards(direction.Value);
        }

        Vector2Int? WhereToLook()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                return Vector2Int.up;
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                return Vector2Int.down;
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                return Vector2Int.left;
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                return Vector2Int.right;

            return null;
        }

        static Vector2Int? WhereToMove()
        {
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                return Vector2Int.up;
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
                return Vector2Int.down;
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                return Vector2Int.left;
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                return Vector2Int.right;

            return null;
        }
    }
}