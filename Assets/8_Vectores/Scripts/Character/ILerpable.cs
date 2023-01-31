using UnityEngine;

namespace Vectores
{
    public interface ILerpable
    {
        public float RotationSpeed { get; }
        public Transform Self { get; }

        public void LookAtTarget(Vector3 target);
    }
}