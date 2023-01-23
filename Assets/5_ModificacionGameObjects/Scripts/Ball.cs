using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModificacionGameObjects
{
    public class Ball : MonoBehaviour
    {


        [SerializeField] private float speed;
        [SerializeField] private Vector3 direction;
        [SerializeField] private int damage;

        [SerializeField] private float lifetime;

        private void Start()
        {
            Ball.Destroy(gameObject, lifetime);
        }


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            this.transform.position += direction * speed * Time.deltaTime;
        }



    }
}
