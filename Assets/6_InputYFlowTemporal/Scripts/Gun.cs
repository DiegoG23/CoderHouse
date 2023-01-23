using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InputYFlowTemporal
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKeyCode;
        [SerializeField] private KeyCode doubleShootKeyCode;
        [SerializeField] private KeyCode doubleScaleKeyCode;
        [SerializeField] private Bullet prefabBullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float SpawnRate = 0.75f;

        private float bulletSizeMultiplier = 1;
        private float nextSpawnTimestamp = 0f;
        private bool isAutoShooting = false;

        public bool IsAutoShooting { get => isAutoShooting; set => isAutoShooting = value; }

        private void Update()
        {
            CheckDoubleSizeBullets();
            if (Time.time >= nextSpawnTimestamp)
            {
                if (IsAutoShooting)
                {
                    Shoot();
                    SetNextSpawnTimestamp();
                }
                /*
                if (Input.GetKeyDown(shootKeyCode))
                {
                    Shoot();
                    SetNextSpawnTimestamp();
                }
                else if (Input.GetKeyDown(doubleShootKeyCode))
                {
                    DoubleShoot();
                    SetNextSpawnTimestamp();
                }
                */
            }
        }

        private void CheckDoubleSizeBullets()
        {
            if (Input.GetKeyDown(doubleScaleKeyCode))
            {
                DoubleSizeBullets();
            }
        }

        private void DoubleSizeBullets()
        {
            bulletSizeMultiplier *= 2;
        }

        public void Shoot()
        {
            Debug.Log("Shoot");
            //gunPrefab, gunPlaceholder.position, gunPlaceholder.rotation,
            Bullet bullet = Instantiate(prefabBullet, spawnPoint.position, spawnPoint.rotation);
            bullet.gameObject.transform.localScale *= bulletSizeMultiplier;

        }
        private void DoubleShoot()
        {
            Debug.Log("Shoot Shoot");
            Bullet bullet0 = Instantiate(prefabBullet, spawnPoint.position + new Vector3(-0.25f, 0f, 0f), Quaternion.identity, spawnPoint);
            bullet0.gameObject.transform.localScale *= bulletSizeMultiplier;
            Bullet bullet1 = Instantiate(prefabBullet, spawnPoint.position + new Vector3(+0.25f, 0f, 0f), Quaternion.identity, spawnPoint);
            bullet1.gameObject.transform.localScale *= bulletSizeMultiplier;
        }

        private void SetNextSpawnTimestamp()
        {
            nextSpawnTimestamp = Time.time + SpawnRate;
        }

    }
}