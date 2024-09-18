using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class StateMachine
{
    public Character character;
    public IState CurrentState { get; private set; }
    private Dictionary<Type, IState> StateMap = new();

    public StateMachine(Character character)
    {
        this.character = character;
    }

    public void Transition<T>() where T : CharacterState, new()
    {
        if (typeof(T) == CurrentState?.GetType()) return;
        CurrentState?.OnExit();

        IState newState = GetStateOrCreate<T>();
        CurrentState = newState;
        CurrentState.OnEnter();
    }

    private IState GetStateOrCreate<T>() where T : CharacterState, new()
    {
        Type type = typeof(T);
        if (!StateMap.TryGetValue(type, out IState state))
        {
            state = new T();
            StateMap[type] = state;
        }

        return state;
    }
}