using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vectores
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKeyCode;
        [SerializeField] private KeyCode doubleShootKeyCode;
        [SerializeField] private KeyCode doubleScaleKeyCode;
        [SerializeField] private Bullet prefabBullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float SpawnRate = 1f;

        private float nextSpawnTimestamp = 0f;
        private bool isAutoShooting = false;

        public bool IsAutoShooting { get => isAutoShooting; set => isAutoShooting = value; }

        private void Update()
        {
            if (Time.time >= nextSpawnTimestamp)
            {
                if (IsAutoShooting)
                {
                    Shoot();
                    SetNextSpawnTimestamp();
                }
            }
        }


        public void Shoot()
        {
            Debug.Log("Shoot");
            Bullet bullet = Instantiate(prefabBullet, spawnPoint.position, spawnPoint.rotation);
        }

        private void SetNextSpawnTimestamp()
        {
            nextSpawnTimestamp = Time.time + SpawnRate;
        }

    }
}