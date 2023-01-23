using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera1;
        [SerializeField] private CinemachineVirtualCamera camera2;
        [SerializeField] private CinemachineVirtualCamera[] cameras;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TurnOnCamera(camera2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TurnOnCamera(camera2);
            }
        }

        private void TurnOnCamera(CinemachineVirtualCamera camera)
        {
            foreach (CinemachineVirtualCamera cam in cameras)
            {
                cam.gameObject.SetActive(cam == camera);
            }
        }
    }
}