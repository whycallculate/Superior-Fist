using UnityEngine;
public class CharacterDodgeState : ICharacterState
{
    public CharacterDodgeState(CharacterController player)
    {

    }
    public void OnEnter()
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