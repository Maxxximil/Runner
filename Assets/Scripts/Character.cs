using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterController _charController;
        public StateMachine movementSM;
        public RunState runing;
        public RightState right;
        public MiddleState middle;
        public LeftState left;

        private bool _isGrounded;
        private Rigidbody _rb;

        private void Start()
        {
            _charController = GetComponent<CharacterController>();
            _rb = GetComponent<Rigidbody>();

            movementSM = new StateMachine();

            runing = new RunState(this, movementSM);
            right = new RightState(this, movementSM);
            left = new LeftState(this, movementSM);
            middle = new MiddleState(this, movementSM);

            runing.middlePos = true;

            movementSM.Initialize(runing);
        }

        private void Update()
        {
            movementSM.CurrentState.HandleInput();

            movementSM.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            movementSM.CurrentState.PhysicUpdate();
        }

        public void Move(float speed)
        {
            Vector3 movement = new Vector3(0, 0, speed);
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            _charController.Move(movement);
        }

        public void ChangeLine(Vector3 val)
        {
            //transform.position += val;
            Debug.Log("Change Line" + val.x);
            _rb.AddForce(val * runing.speed);
        }

    }
}
