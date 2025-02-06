using UnityEngine;

public class CharacterRunState : ICharacterState
{
    private CharacterController player;
    private Rigidbody2D rb;
    private float moveSpeed = 150f;
    private float Horizontal;
    private float Vertical;

    public CharacterRunState(CharacterController player)
    {
        this.player = player;
        rb = player.rb;
    }
    public void OnEnter()
    {
        Debug.Log("RunStateEnter");
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        Horizontal = InputHandler.Instance.HorizontalInput;
        Vertical = InputHandler.Instance.VerticalInput;

        rb.velocity = new Vector2(Horizontal, Vertical) * (moveSpeed * Time.fixedDeltaTime);
    }
}