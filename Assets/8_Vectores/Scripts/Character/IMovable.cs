﻿using UnityEngine;

namespace Vectores
{
    public interface IMovable : ILerpable
    {
        public float FollowTargetOffset { get; }
        public float Speed { get; }
        public void MoveToTarget(Vector3 target);


    }
}