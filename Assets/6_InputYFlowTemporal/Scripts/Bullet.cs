using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InputYFlowTemporal
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private int damage = 10;
        [SerializeField] private float lifetime = 8f;


        private void Start()
        {
            lifetime += Time.time;
            //Ball.Destroy(gameObject, lifetime);
        }


        private void Update()
        {
            Move();
            Countdown();
        }

        private void Move()
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void Countdown()
        {
            if (lifetime <= Time.time)
            {
                KillBullet();
            }
        }

        private void KillBullet()
        {
            Destroy(gameObject);
        }



    }
}