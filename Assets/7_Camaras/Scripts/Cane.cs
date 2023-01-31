using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camaras
{
    internal class Cane : MonoBehaviour
    {
        private CaneStates caneState = CaneStates.Up;

        public void ToggleCane()
        {
            switch (caneState)
            {
                case CaneStates.Up:
                    caneState = CaneStates.Down;
                    break;
                case CaneStates.Down:
                    caneState = CaneStates.Up;
                    break;
                default:
                    break;
            }
        }
    }
}