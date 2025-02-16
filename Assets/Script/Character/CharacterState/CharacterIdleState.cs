using UnityEngine;

public class CharacterIdleState : ICharacterState
{
    public static readonly CharacterIdleState Instance = new CharacterIdleState();

    private CharacterController player;
    private Rigidbody2D rb;
    private Animator animator;


    public void OnEnter(CharacterController player)
    {
        this.player = player;
        rb = player.rb;
        animator = player.animator;

        Debug.Log("IdleStateEnter");
        animator.SetBool("Idle",true);
    }

    public void OnExit()
    {
        animator.SetBool("Idle", false);
        Debug.Log("idle state exit");
    }

    public void OnUpdate()
    {
        animator.SetTrigger("Idle");
        rb.velocity = Vector2.zero;
        Debug.Log("Update");

    }
}