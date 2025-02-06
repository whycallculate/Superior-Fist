using System.Transactions;
using UnityEngine;

public class CharacterWalkState : ICharacterState
{
    private CharacterController player;
    private Rigidbody2D rb;
    private float moveSpeed = 100f;
    private float Horizontal;
    private float Vertical;
    

    public CharacterWalkState(CharacterController player)
    {
        this.player = player;
        this.rb = player.rb;
    }

    public void OnEnter()
    {
        Debug.Log("OnWalkState");
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