using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camaras
{

    public class GameController : MonoBehaviour
    {
        //TODO: Hacer Singleton

        [SerializeField] public KeyCode modeToggleKeyCode;

        public ViewModes viewMode = ViewModes.NAVIGATING;


        private void Start()
        {
        }

        private void Update()
        {
            ViewModeHandler();
        }

        private void ViewModeHandler()
        {
            if (Input.GetKeyDown(modeToggleKeyCode))
            {
                switch (viewMode)
                {
                    case ViewModes.FISHING:
                        viewMode = ViewModes.NAVIGATING;
                        break;
                    case ViewModes.NAVIGATING:
                        viewMode = ViewModes.FISHING;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}