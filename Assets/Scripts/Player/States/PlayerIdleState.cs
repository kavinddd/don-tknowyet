using System;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

class PlayerIdleState : CharacterState
{
    public override void OnEnter()
    {
        GameInput.Instance.OnMove += HandleMove;
    }

    private void HandleMove(object sender, EventArgs e)
    {
        Character.StateMachine.Transition<PlayerMoveState>();
    }

    public override void Update()
    {
        Debug.Log("PlayerIdleState - Idling");
    }
    public override void OnExit()
    {
        GameInput.Instance.OnMove -= HandleMove;
        Debug.Log("PlayerIdleState - Exit");
    }
}

