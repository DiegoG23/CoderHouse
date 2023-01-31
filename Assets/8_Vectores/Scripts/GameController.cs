
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vectores
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                LayerMask layerMask = LayerMask.GetMask("Water");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f, layerMask))
                {
                    player.NextPosition = hit.point;
                    Debug.DrawLine(player.transform.position, hit.point, Color.red, 10f);
                }
            }
        }

    }
}