using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class LeftState : RunState
    {
        
        public LeftState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        { }

        public override void Enter()
        {
            base.Enter();
            leftPos = true;
        }

        public override void Exit()
        {
            base.Exit();
            leftPos = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            character.ChangeLine(new Vector3(-3.0f, 0.0f, 0.0f));
            stateMachine.ChangeState(character.runing);
        }
    }
}
