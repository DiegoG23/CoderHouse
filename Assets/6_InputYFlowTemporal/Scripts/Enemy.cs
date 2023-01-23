using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InputYFlowTemporal
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private float speed = 7.0f;
        [SerializeField] private float rotationSpeed = 300.0f;
        [SerializeField] private float dashLength = 5.0f;
        [SerializeField] private Gun gunPrefab;
        [SerializeField] private Transform gunPlaceholder;
        [SerializeField] private Transform target;

        private Gun gun;
        private bool playerOnSight = true;


        void Start()
        {
            gun = Instantiate(gunPrefab, gunPlaceholder.position, gunPlaceholder.rotation, gunPlaceholder);
        }

        // Update is called once per frame
        void Update()
        {
            ToggleShoot(playerOnSight);
            if (playerOnSight)
            {
                FaceTarget();
            }
        }

        void ToggleShoot(bool isActive)
        {
            gun.IsAutoShooting = isActive;
        }

        private void FaceTarget()
        {
            transform.LookAt(target);
        }

    }
}