using UnityEngine;
public abstract class Character : MonoBehaviour
{
    public PlayerSO PlayerSO;
    public Rigidbody2D RigidBody;
    public StateMachine StateMachine;

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }
}