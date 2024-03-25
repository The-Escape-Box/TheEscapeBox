using UnityEngine;

namespace Script.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform groundCheck;
        public LayerMask groundMask;
        public float JumpHeight;

        public float movementSpeed = 12;
        public float gravity = -0.98f;
        public float groundDistance = 0.4f;

        private Vector3 _velocity;
        private bool _isGrounded;
        
        // Update is called once per frame
        void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * movementSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                if (_isGrounded)
                {
                    _velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
                }
            }

            _velocity.y += gravity * Time.deltaTime;

            controller.Move(_velocity * Time.deltaTime);
        }
    }
    
}
