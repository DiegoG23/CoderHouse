using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camaras
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private CinemachineVirtualCamera navigationCamera;
        [SerializeField] private CinemachineVirtualCamera fishingCamera;

        private CinemachineVirtualCamera[] cameras = new CinemachineVirtualCamera[2];

        private void Start()
        {
            cameras[0] = navigationCamera;
            cameras[1] = fishingCamera;
        }

        private void Update()
        {
            if (Input.GetKeyDown(gameController.modeToggleKeyCode))
            {
                if (gameController.viewMode == ViewModes.NAVIGATING)
                {
                    TurnOnCamera(navigationCamera);
                }
                else
                {
                    TurnOnCamera(fishingCamera);
                }
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