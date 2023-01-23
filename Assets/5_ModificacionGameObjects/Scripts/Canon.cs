using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModificacionGameObjects
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKeyCode;
        [SerializeField] private KeyCode doubleShootKeyCode;
        [SerializeField] private KeyCode tripleShootKeyCode;
        [SerializeField] private KeyCode quadrupleShootKeyCode;

        [SerializeField] private Ball prefabBall;
        [SerializeField] private Transform ballOrigin;

        [SerializeField] private float SpawnRate = 0.25f;

        private float nextSpawnTimestamp = 0f;

        private void Update()
        {
            if (Time.time >= nextSpawnTimestamp)
            {
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
                else if (Input.GetKeyDown(tripleShootKeyCode))
                {
                    TripleShoot();
                    SetNextSpawnTimestamp();
                }
                else if (Input.GetKeyDown(quadrupleShootKeyCode))
                {
                    QuadrupleShoot();
                    SetNextSpawnTimestamp();
                }

            }
        }

        private void Shoot()
        {
            Debug.Log("Shoot");
            Instantiate(prefabBall, ballOrigin, false);
        }

        private void DoubleShoot()
        {
            Debug.Log("Shoot Shoot");
            Ball firstBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(-0.25f, 0f, 0f), Quaternion.identity, ballOrigin);
            Ball secondBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(+0.25f, 0f, 0f), Quaternion.identity, ballOrigin);
        }

        private void TripleShoot()
        {
            Debug.Log("Shoot Shoot Shoot");
            Ball firstBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(0f, 0.25f, 0f), Quaternion.identity, ballOrigin);
            Ball secondBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(-0.25f, -0.15f, 0f), Quaternion.identity, ballOrigin);
            Ball thirdBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(0.25f, -0.15f, 0f), Quaternion.identity, ballOrigin);
        }

        private void QuadrupleShoot()
        {
            Debug.Log("Shoot Shoot Shoot Shoot");
            Ball firstBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(-0.3f, 0f, 0f), Quaternion.identity, ballOrigin);
            Ball secondBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity, ballOrigin);
            Ball thirdBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(0.3f, 0f, 0f), Quaternion.identity, ballOrigin);
            Ball fourthBall = Instantiate(prefabBall, ballOrigin.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity, ballOrigin);
        }

        private void SetNextSpawnTimestamp()
        {
            nextSpawnTimestamp = Time.time + SpawnRate;
        }

    }
}