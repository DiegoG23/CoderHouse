using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Vectores
{
    public static class CharacterActions
    {

        public static void LookAtTarget(ILerpable character, Vector3 target)
        {
            if (character != null)
            {

                Vector3 vectorToPosition = target - character.Self.position;
                Quaternion newRotation = Quaternion.LookRotation(vectorToPosition);
                character.Self.rotation = Quaternion.Lerp(character.Self.rotation, newRotation, Time.deltaTime * character.RotationSpeed);
            }
        }

        public static void MoveToTarget(IMovable character, Vector3 target)
        {
            if (character != null)
            {
                Vector3 vectorToNextPosition = target - character.Self.position;
                if (vectorToNextPosition.magnitude > character.FollowTargetOffset)
                {
                    CharacterActions.LookAtTarget(character, target);
                    character.Self.position = Vector3.MoveTowards(character.Self.position, target, character.Speed * Time.deltaTime);
                }
            }
        }
    }
}