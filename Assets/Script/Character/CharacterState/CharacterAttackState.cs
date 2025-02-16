using UnityEngine;

public class CharacterAttackState : ICharacterState
{
    public static readonly CharacterAttackState Instance = new CharacterAttackState();

    private CharacterController player;

    public void OnEnter(CharacterController player)
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