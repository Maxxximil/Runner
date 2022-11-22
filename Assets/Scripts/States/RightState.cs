using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class RightState : RunState
    {
        
        public RightState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        { }

        public override void Enter()
        {
            base.Enter();
            rightPos = true;
        }

        public override void Exit()
        {
            base.Exit();
            rightPos = false;
        }
    }
}