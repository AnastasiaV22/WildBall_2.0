using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float turnSpeed = 20f;
        [SerializeField, Range(0, 20)] private float jumpForce = 10f;

        [SerializeField] private float maxSpeed = 50f;

        private Rigidbody playerRB;

        private bool isGrounded = true;

        private float deceleration = 1;

        private void Awake()
        {
            InputController inputController = FindObjectOfType<InputController>();

            inputController.PlayerMoved.AddListener(MoveCharacter);
            inputController.PlayerRotated.AddListener(RotateCharacter);
            inputController.PlayerJumped.AddListener(PlayerJump);

            playerRB = GetComponent<Rigidbody>();
            playerRB.maxAngularVelocity = maxSpeed;
        }

        // -1 назад, 1 вперед
        public void MoveCharacter(float vertDirection, float horDirection)
        {
            if (vertDirection > 0)
            {
                deceleration = 1;
            }
            else if (vertDirection < 0)
            {
                deceleration = 0.5f;
            }

            if (!isGrounded)
            {
                deceleration /= 2;
            }
            
            playerRB.AddForce(transform.forward * vertDirection * speed * deceleration, ForceMode.Force);
            
            if (horDirection != 0)
            {
                playerRB.AddForce(transform.right * horDirection * speed, ForceMode.Force);
            }
        }

        public void RotateCharacter(float rotation)
        {
            if (rotation != 0 && playerRB.velocity.magnitude <= maxSpeed)
            {
                Quaternion deltaRotation = Quaternion.Euler(0, rotation * turnSpeed * Time.fixedDeltaTime, 0);
                playerRB.MoveRotation(playerRB.rotation * deltaRotation);
            }

        }

        public void PlayerJump()
        {
            if (isGrounded)
            {
                isGrounded = false;

                Debug.Log("gr false");
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!isGrounded && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Debug.Log("gr true");
                isGrounded = true;
            }
        }


#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResetValues()
        {
            speed = 10f;
        }
#endif

    }

}
