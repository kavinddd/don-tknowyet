using System;
using UnityEngine;
using static GameInput;
class PlayerMoveState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("PlayerMoveState - Enter");
        GameInput.Instance.OnStopMoving += HandleStopMoving;
        GameInput.Instance.OnMove += HandleMove;
    }

    private void HandleMove(object sender, OnMoveArgs e)
    {
        Vector2 newPlayerPosition = CalculateNewPlayerPosition(e.normalizedMovement);
        Character.RigidBody.MovePosition(newPlayerPosition);
    }

    private void HandleStopMoving(object sender, EventArgs e)
    {
        Character.StateMachine.Transition<PlayerIdleState>();
    }

    public override void Update()
    {
        Debug.Log("PlayerMoveState - moving");
    }
    public override void OnExit()
    {
        Debug.Log("PlayerMoveState - Exit");

        GameInput.Instance.OnStopMoving -= HandleStopMoving;
        GameInput.Instance.OnMove -= HandleMove;
    }
    private Vector2 CalculateNewPlayerPosition(Vector2 normalizedMovement)
    {
        // Vector2 movement = GameInput.Instance.GetNormalizedMovement();
        Vector2 newPosition = Character.RigidBody.position + Character.PlayerSO.moveSpeed * Character.PlayerSO.movementSpeedModifer * Time.deltaTime * normalizedMovement;
        return newPosition;
    }
}