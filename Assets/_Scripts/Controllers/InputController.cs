using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


namespace WildBall.Inputs
{
    public class InputController : MonoBehaviour
    { 
        private float moveForward;
        private float moveSides;
        private float rotate;

        private bool inGame = true;

        public UnityEvent<float, float> PlayerMoved;
        public UnityEvent<float> PlayerRotated;
        public UnityEvent PlayerJumped;

        public UnityEvent<float> CameraRotated;

        public UnityEvent InteractionActivated;

        private void Update()
        {
            if (inGame)
            {
                if (Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON))
                    PlayerJumped?.Invoke();
                if (Input.GetButtonDown(GlobalStringVars.INTERACTION_BUTTON))
                    InteractionActivated?.Invoke();
            }
        }

        void FixedUpdate()
        {
            if (inGame)
            {
                moveForward = Input.GetAxisRaw(GlobalStringVars.VERTICAL_AXIS);
                moveSides = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
                PlayerMoved?.Invoke(moveForward, moveSides);

                rotate = Input.GetAxis(GlobalStringVars.VIEW_AXIS);
                PlayerRotated?.Invoke(rotate);

                //движение камеры мышкой

            }

        }

        public void DisableGameInput()
        {
            inGame = false;
        }

        public void EnableGameInput()
        {
            inGame = true;
        }

    }

}
