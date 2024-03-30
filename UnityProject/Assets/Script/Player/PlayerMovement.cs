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
        public float gravity = -9.81f; // Standard gravity value
        public float groundDistance = 0.4f;
        private bool _isGrounded;

        private Vector3 _velocity;

        // Update is called once per frame
        private void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f; // Reset vertical velocity when grounded
            }

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var move = transform.right * x + transform.forward * z;
            controller.Move(move * movementSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && _isGrounded) // Only jump when grounded
            {
                _velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime; // Apply gravity
            controller.Move(_velocity * Time.deltaTime);
        }
    }
}
