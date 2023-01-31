using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Vectores
{
    public class Player : Character, IMovable
    {
        [SerializeField] private float dashLength = 5.0f;
        [SerializeField] private KeyCode fireKeyCode;
        [SerializeField] private KeyCode crouchKeyCode;
        [SerializeField] private KeyCode dashKeyCode;
        [SerializeField] private float rotationSpeed = 10.0f;
        [SerializeField] private float followTargetOffset = 0.1f;
        [SerializeField] private float speed = 8.0f;
        [SerializeField] private string vAxisName = "Vertical";

        private bool isCrouched = false;

        public bool IsDetected { get; private set; }
        public Vector3 NextPosition { get; set; }

        public float FollowTargetOffset { get => followTargetOffset; }
        public float Speed { get => speed; }
        public float RotationSpeed { get => rotationSpeed; }

        public Transform Self { get => transform; }

        void Start()
        {
            NextPosition = transform.position;
        }


        void Update()
        {
            InputHandler();
        }

        void InputHandler()
        {
            MovementHandler();
            CrouchHandler();
            DashHandler();
        }

        private void CrouchHandler()
        {
            if (Input.GetKeyDown(crouchKeyCode))
            {
                isCrouched = !isCrouched;
                float height = isCrouched ? 0.5f : 1;
                transform.localScale = new Vector3(1, height, 1);
            }
        }

        private void DashHandler()
        {
            if (Input.GetKeyDown(dashKeyCode))
            {
                float vAxis = Input.GetAxis(vAxisName);
                float translation = vAxis + dashLength * Mathf.Sign(vAxis);
                transform.Translate(0, 0, translation);
            }
        }

        private void MovementHandler()
        {
            MoveToTarget(NextPosition);
        }


        public void MoveToTarget(Vector3 target)
        {
            CharacterActions.MoveToTarget(this, target);
        }
        public void LookAtTarget(Vector3 target)
        {
            CharacterActions.LookAtTarget(this, target);
        }
    }
}