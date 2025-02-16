using UnityEngine;
public class CharacterDodgeState : ICharacterState
{
    public static readonly CharacterDodgeState Instance = new CharacterDodgeState();
    public void OnEnter(CharacterController player)
    {
        Debug.Log("OnDodgeState");
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }
}