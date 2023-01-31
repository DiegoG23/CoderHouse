using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vectores
{
    public class BossEnemy : Enemy, IShooting, IMovable
    {
        [SerializeField] protected Gun prefabGun;
        [SerializeField] private Transform gunPlaceholder;
        [SerializeField] private EnemyState state = EnemyState.ALERT;

        [SerializeField] private float followTargetOffset = 2.0f;
        [SerializeField] private float speed = 8.0f;

        public Gun Gun { get; set; }
        public Gun PrefabGun { get => prefabGun; }

        public float FollowTargetOffset { get => followTargetOffset; }
        public float Speed { get => speed; }

        void Start()
        {
            Gun = Instantiate(prefabGun, gunPlaceholder.position, gunPlaceholder.rotation, gunPlaceholder);
        }

        void Update()
        {
            HandleState();
            /*
            ToggleShoot(TargetOnSight);
            if (TargetOnSight)
            {
                LookAtPosition(Target);
                MoveToTarget(Target);
            }
            */
        }

        private void HandleState()
        {
            switch (state)
            {
                case EnemyState.IDLE:
                    DoNothing();
                    break;
                case EnemyState.SHOOTING:
                    LookAtTarget(target.position);
                    ToggleShoot(TargetOnSight);
                    break;
                case EnemyState.ALERT:
                    LookAtTarget(target.position);
                    break;
                case EnemyState.PURSUIT:
                    MoveToTarget(target.position);
                    break;
                default:
                    DoNothing();
                    break;
            }
        }
        public void ToggleShoot(bool isActive)
        {
            Gun.IsAutoShooting = isActive;
        }


        public void MoveToTarget(Vector3 target)
        {
            CharacterActions.MoveToTarget(this, target);
        }

        public void DoNothing()
        {
            ToggleShoot(false);
            Debug.Log("DOING NOTHING");
        }
    }
}