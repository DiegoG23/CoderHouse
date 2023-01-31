using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputYFlowTemporal
{
    public class Clone : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private float speed = 8.0f;
        [SerializeField] private float dashLength = 5.0f;
        [SerializeField] private float rotationSpeed = 300.0f;
        [SerializeField] private KeyCode fireKeyCode;
        [SerializeField] private KeyCode crouchKeyCode;
        [SerializeField] private KeyCode dashKeyCode;
        [SerializeField] private string vAxisName = "Vertical";
        [SerializeField] private string hAxisName = "Horizontal";

        private Gun gun;
        private bool isCrouched = false;
        private bool isDetected = false;


        // Start is called before the first frame update
        void Start()
        {
            this.gun = this.GetComponentInChildren<Gun>();
        }

        // Update is called once per frame
        void Update()
        {
            InputHandler();
        }

        void InputHandler()
        {
            MovementHandler();
            ShootHandler();
            CrouchHandler();
            DashHandler();
        }

        void ShootHandler()
        {
            if (Input.GetKeyDown(fireKeyCode))
            {
                if (gun != null)
                {
                    gun.Shoot();

                }
            }
        }

        void CrouchHandler()
        {
            if (Input.GetKeyDown(crouchKeyCode))
            {
                isCrouched = !isCrouched;
                float height = isCrouched ? 0.5f : 1;
                transform.localScale = new Vector3(1, height, 1);
            }
        }

        void DashHandler()
        {
            if (Input.GetKeyDown(dashKeyCode))
            {
                float vAxis = Input.GetAxis(vAxisName);
                float translation = vAxis + dashLength * Mathf.Sign(vAxis);
                transform.Translate(0, 0, translation);
            }
        }

        void MovementHandler()
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float translation = Input.GetAxis(vAxisName) * speed;
            float rotation = Input.GetAxis(hAxisName) * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Translate(0, 0, translation);

            // Rotate around our y-axis
            transform.Rotate(0, rotation, 0);

        }
    }
}