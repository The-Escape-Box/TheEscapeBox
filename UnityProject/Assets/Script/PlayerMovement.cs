using System;
using UnityEngine;

namespace Script
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

        Vector3 velocity;
        bool isGrounded;
        
        private Animator anim;
        
        private int _hIdles;
        private int _hWalk;
        private int _hWalkRight;
        private int _hWalkLeft;
        private int _hWalkBack;
        private int _hShoot;
        private int _hJump;

        private void Start()
        {
            anim = GetComponent<Animator>();

            // Set up hash IDs for animation states
            _hIdles = Animator.StringToHash("Idle");
            _hWalk = Animator.StringToHash("Walk");
            _hWalkLeft = Animator.StringToHash("WalkLeft");
            _hWalkRight = Animator.StringToHash("WalkRight");
            _hWalkBack = Animator.StringToHash("WalkBack");
        }

        // Update is called once per frame
        void Update()
        {
            HandleAnimations();
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * movementSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump pressed. Grounded: " + isGrounded);
                if (isGrounded)
                {
                    velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
                }
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        private void HandleAnimations()
        {
            if (!Input.anyKey)
            {
                anim.SetBool(_hIdles, true);
                anim.SetBool(_hWalk, false);
                anim.SetBool(_hWalkLeft, false);
                anim.SetBool(_hWalkRight, false);
                anim.SetBool(_hWalkBack, false);
                return;
            }
            
            anim.SetBool(_hIdles, false);
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool(_hWalk, true);
                anim.SetBool(_hWalkLeft, false);
                anim.SetBool(_hWalkRight, false);
                anim.SetBool(_hWalkBack, false);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool(_hWalk, false);
                anim.SetBool(_hWalkLeft, true);
                anim.SetBool(_hWalkRight, false);
                anim.SetBool(_hWalkBack, false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetBool(_hWalk, false);
                anim.SetBool(_hWalkLeft, false);
                anim.SetBool(_hWalkRight, true);
                anim.SetBool(_hWalkBack, false);            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool(_hWalk, false);
                anim.SetBool(_hWalkLeft, false);
                anim.SetBool(_hWalkRight, false);
                anim.SetBool(_hWalkBack, true);            }
        }
    }
    
}
