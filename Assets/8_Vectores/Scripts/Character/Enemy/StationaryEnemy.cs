using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vectores
{
    public class StationaryEnemy : Enemy, IShooting
    {
        [SerializeField] protected Gun prefabGun;
        [SerializeField] protected Gun gun;
        [SerializeField] protected Transform gunPlaceholder;

        public Gun Gun { get; set; }
        public Gun PrefabGun { get => prefabGun; }

        void Start()
        {
            Gun = Instantiate(prefabGun, gunPlaceholder.position, gunPlaceholder.rotation, gunPlaceholder);
        }


        void Update()
        {
            //ToggleShoot(TargetOnSight);
            if (TargetOnSight)
            {
                LookAtTarget(target.position);
            }
        }

        public void ToggleShoot(bool isActive)
        {
            Gun.IsAutoShooting = isActive;
        }

    }
}