using UnityEngine;

public class CharacterAttackState : ICharacterState
{
    private CharacterController player;

    public CharacterAttackState(CharacterController player)
    {
        this.player = player;
    }

    public void OnEnter()
    {
        Debug.Log("OnAttackState");
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        Debug.Log("UpdateAttackState");
    }
}