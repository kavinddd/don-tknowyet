using UnityEngine;

public class CharacterState : IState
{
    protected Character Character;
    public CharacterState() { }
    public void SetCharacter(Character c)
    {
        if (Character != null)
        {
            Debug.LogError("Cannot overide character on a character state once initialized");
            return;
        }
        this.Character = c;
    }
    public virtual void FixedUpdate()
    {
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void Update()
    {
    }
}