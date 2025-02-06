using UnityEngine;

public class CharacterIdleState : ICharacterState
{
    private CharacterController player;
    private Rigidbody2D rb;
    public CharacterIdleState(CharacterController player)
    {
        this.player = player;
        rb = player.rb;
    }
    public void OnEnter()
    {
        Debug.Log("IdleStateEnter");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        rb.velocity = Vector2.zero;

    }
}