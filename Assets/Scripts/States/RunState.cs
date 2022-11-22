using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class RunState : State
    {
        [SerializeField] public float speed = 10.0f;

        public bool leftPos;
        public bool rightPos;
        public bool middlePos;
        private bool leftArrow;
        private bool rightArrow;
        private bool upArrow;

        public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        { }

        public override void Enter()
        {
            base.Enter();
           
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            leftArrow = Input.GetKey(KeyCode.LeftArrow);
            rightArrow = Input.GetKey(KeyCode.RightArrow);
            upArrow = Input.GetKey(KeyCode.UpArrow);
        }

        public override void PhysicUpdate()
        {
            base.PhysicUpdate();
            character.Move(speed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(leftArrow && rightPos)
            {
                stateMachine.ChangeState(character.middle);
            }
            if(leftArrow && middlePos)
            {
                stateMachine.ChangeState(character.left);
            }
            if(rightArrow && leftPos)
            {
                stateMachine.ChangeState(character.middle);
            }
            if (rightArrow && middlePos)
            {
                stateMachine.ChangeState(character.middle);
            }
        }
    }
}