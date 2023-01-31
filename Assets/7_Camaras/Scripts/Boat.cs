using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camaras
{
    public class Boat : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private float speed = 8.0f;
        [SerializeField] private float rotationSpeed = 300.0f;
        [SerializeField] private KeyCode lineKeyCode;

        private Cane cane;
        private CaneStates caneState = CaneStates.Up;
        private bool isFishing = false;

        public bool IsFishing { get => isFishing; }

        void Start()
        {
            cane = transform.GetComponentInChildren<Cane>();
            cane.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            InputHandler();
        }

        void InputHandler()
        {
            ModeHandler();
            if(isFishing)
            {
                LineHandler();
            }
            else
            {
                MovementHandler();
            }
        }


        void ModeHandler()
        {
            if (Input.GetKeyDown(gameController.modeToggleKeyCode))
            {
                caneState = CaneStates.Up;
                isFishing = !isFishing;
                cane.gameObject.SetActive(isFishing);
                Debug.Log("Mode changed: " + (isFishing? "FISHING": "NAVIGATING"));
            }
        }


        private void LineHandler()
        {
            if (Input.GetKeyDown(lineKeyCode))
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
                Debug.Log("Line State: " + caneState);
            }
        }

        void MovementHandler()
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 'speed' meters per second instead of 'speed' meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Translate(0, 0, translation);

            // Rotate around our y-axis
            transform.Rotate(0, rotation, 0);

        }
    }
}