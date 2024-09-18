
using System;
using Unity.VisualScripting;
using UnityEngine;


public class Player : Character
{
    private void Awake()
    {
        StateMachine = new StateMachine(this);
        StateMachine.Transition<PlayerIdleState>(); // default is idle
    }
}
