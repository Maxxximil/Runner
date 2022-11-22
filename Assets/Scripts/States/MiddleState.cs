using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class MiddleState : RunState
    {

        public MiddleState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        { }

        public override void Enter()
        {
            base.Enter();
            middlePos = true;
        }

        public override void Exit()
        {
            base.Exit();
            middlePos = false;
        }
    }
}
