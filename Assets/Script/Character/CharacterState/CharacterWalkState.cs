using System.Transactions;
using UnityEngine;

public class CharacterWalkState : ICharacterState
{
    public static readonly CharacterWalkState Instance = new CharacterWalkState();

    private CharacterController player;
    private Rigidbody2D rb;
    private float moveSpeed = 100f;
    private float Horizontal;
    private float Vertical;

    public void OnEnter(CharacterController player)
    {
        this.player = player;
        rb = player.rb;
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        Horizontal = InputHandler.Instance.HorizontalInput;
        Vertical = InputHandler.Instance.VerticalInput;

        rb.velocity = new Vector2(Horizontal , Vertical ) * (moveSpeed * Time.fixedDeltaTime);
    }
}